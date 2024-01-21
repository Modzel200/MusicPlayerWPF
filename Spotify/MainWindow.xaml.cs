using System.ComponentModel;
using System.IO;
using System.IO.Packaging;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.Text.Json;
using Spotify.logic;
using Spotify.view;
using Spotify.VIew;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Text.Json.Serialization;
using NAudio.Wave;
using System.Data;

namespace Spotify;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Biblioteka biblioteka;
    public Player player;
    public static MainWindow mainWindow;
    public Playlista playlist;
    public Utwor songToPlay;
    public Originator originator;
    public List<Memento> savedStates;
    public bool isPlaying;
    private Observer observer;
    private Context context;
    public MainWindow()
    {
        Playlista playProto = new Playlista("Template");
        biblioteka = Biblioteka.GetInstance();
        context = new Context();
        if (File.Exists("test.json"))
        {
            string jsonString = File.ReadAllText("test.json");
            // var deserialized = JsonConvert<Biblioteka>(jsonString);
            var deserialized = JsonConvert.DeserializeObject<Biblioteka>(jsonString);
            biblioteka = deserialized;
        }
        InitializeComponent();
        shuffle.Source = new BitmapImage(new Uri(@"/img/mix.png", UriKind.Relative));
        stop.Source = new BitmapImage(new Uri(@"/img/pause.png", UriKind.Relative));
        delete.Source = new BitmapImage(new Uri(@"/img/minus.png", UriKind.Relative));
        upsong.Source = new BitmapImage(new Uri(@"/img/up.png", UriKind.Relative));
        downsong.Source = new BitmapImage(new Uri(@"/img/down.png", UriKind.Relative));
        observer = new Observer(UpdateUI);
        biblioteka.RegisterObserver(observer);
        foreach (Playlista playlista in biblioteka.getPlaylisty())
        {
            playlista.RegisterObserver(observer);
        }

        originator = new Originator();
        savedStates = new List<Memento>();
        player = Player.getInstance();
        isPlaying = false;
        UpdateUI();
    }

    public void save()
    {
        originator.State = JsonSerializer.Serialize<Biblioteka>(biblioteka, new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });
        File.WriteAllText("test.json", originator.State);
        savedStates.Add(originator.SaveState());
    }

    private void CreateNewPlaylistButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddPlaylist addPlaylist = new AddPlaylist(biblioteka);
        
        addPlaylist.Show();
        addPlaylist.Closed += AddPlaylist_Closed;
    }

    private void AddPlaylist_Closed(object sender, EventArgs e)
    {
        Playlista temp = biblioteka.getPlaylista(biblioteka.getPlaylisty().Count-1);
        temp.RegisterObserver(observer);
    }

    private void RemovePlaylistButton_OnClick(object sender, RoutedEventArgs e)
    {
        biblioteka.removePlaylista(biblioteka.getPlaylista(playlistList.SelectedIndex));
    }

    private void upPlaylistPosition_OnClick(object sender, RoutedEventArgs e)
    {
        biblioteka.upPosition(playlistList.SelectedIndex);
    }
    private void downPlaylistPosition_OnClick(object sender, RoutedEventArgs e)
    {
        biblioteka.downPosition(playlistList.SelectedIndex);
    }

    private void UpSongButton_OnClick(object sender, RoutedEventArgs e)
    {
        Playlista playlista = biblioteka.getPlaylista(playlistList.SelectedIndex);
        playlista.upPosition(songsList.SelectedIndex);
    }
    private void DownSongButton_OnClick(object sender, RoutedEventArgs e)
    {
        Playlista playlista = biblioteka.getPlaylista(playlistList.SelectedIndex);
        playlista.downPosition(songsList.SelectedIndex);
    }

    private void moveToPlaylist(object sender, SelectionChangedEventArgs e)
    {
        if (playlistList.SelectedIndex >= 0)
        {

                songsList.SelectedIndex = -1;
                songsTitle.Text = biblioteka.getPlaylista(playlistList.SelectedIndex).getNazwa();
                songsList.Items.Clear();
                playlist = biblioteka.getPlaylista(playlistList.SelectedIndex);
                foreach (var i in playlist.getLista())
                {
                    songsList.Items.Add(i.getTytul());
                }
            
        }
    }

    private void loadSong(object sender, RoutedEventArgs e)
    {
        if(songsList.SelectedIndex < 0)
        {
            return;
        }
        songToPlay = playlist.getUtwor(songsList.SelectedIndex);
        List<string> autorDoPokazania = songToPlay.autorUtworu.getInfo();
        autorPseudo.Text = autorDoPokazania[0];
        autorHidName.Visibility = Visibility.Hidden;
        autorHidSur.Visibility = Visibility.Hidden;
        autorHidNar.Visibility = Visibility.Hidden;
        autorHidOpis.Visibility = Visibility.Hidden;
        autorImie.Text = "";
        autorNazwisko.Text = "";
        autorNarodowosc.Text = "";
        autorOpis.Text = "";
        DetailsButton.Content = "Pokaż szczegóły";
    }
    private void ShowDetailsAutor(object sender, RoutedEventArgs e)
    {
        if(songsList.SelectedIndex < 0)
        {
            return;
        }
        songToPlay = playlist.getUtwor(songsList.SelectedIndex);
        if(songToPlay == null)
        {
            return;
        }
        AutorCaleInfo detailsUser = new AutorCaleInfo(songToPlay.autorUtworu, biblioteka);
        List<string> details = detailsUser.getInfo();
        if (string.Compare(DetailsButton.Content.ToString(), "Pokaż szczegóły") == 0)
        {
            autorHidName.Visibility = Visibility.Visible;
            autorHidSur.Visibility = Visibility.Visible;
            autorHidNar.Visibility = Visibility.Visible;
            autorHidOpis.Visibility = Visibility.Visible;
            autorImie.Text = details[1];
            autorNazwisko.Text = details[2];
            autorNarodowosc.Text = details[3];
            autorOpis.Text = details[4];
            DetailsButton.Content = "Schowaj szczegóły";
        } else
        {
            AutorBezSzczegolow withoutDetails = (AutorBezSzczegolow)detailsUser.GetAutor();
            autorPseudo.Text = withoutDetails.getInfo()[0];
            autorHidName.Visibility = Visibility.Hidden;
            autorHidSur.Visibility = Visibility.Hidden;
            autorHidNar.Visibility = Visibility.Hidden;
            autorHidOpis.Visibility = Visibility.Hidden;
            autorImie.Text = "";
            autorNazwisko.Text = "";
            autorNarodowosc.Text = "";
            autorOpis.Text = "";
            DetailsButton.Content = "Pokaż szczegóły";
        }
        
    }

    private void CreateNewSongButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddSong addSong = new AddSong(playlist, biblioteka);
        addSong.Show();
    }


    private bool uiButtonClicked = false;

    private void PlayButton_OnClick(object sender, RoutedEventArgs e)
    {

        if (isPlaying == false)
        {
            if (songToPlay != null)
            {
                WaveOutEvent waveOut = player.play(songToPlay.getSciezka());

                waveOut.PlaybackStopped += (s, args) =>
                {

                    if (!uiButtonClicked)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            if (playlist.getUtwor(songsList.SelectedIndex +1 )==null)
                            {
                                PauseButton_OnClick(sender, e);
                            }
                            else
                            {
                                NextButton_OnClick(s, e);
                            }
                            
                        });
                    }
                    uiButtonClicked = false;
                };
                
                isPlaying = true;
                playPauseImg.Source = new BitmapImage(new Uri(@"/img/stop.png", UriKind.Relative));
            }
        }
        else
        {
            isPlaying = false;
            player.pause();
            playPauseImg.Source = new BitmapImage(new Uri(@"/img/play.png", UriKind.Relative));
        }

        UpdateUI();
    }

    private void NextButton_OnClick(object sender, RoutedEventArgs e)
    {
        uiButtonClicked = true;
        PauseButton_OnClick(sender, e);

        if (songsList.SelectedIndex >= 0)
        {
            songsList.SelectedIndex += 1;
            loadSong(sender, e);
            PlayButton_OnClick(sender, e);
        }
    }

    private void PrevButton_OnClick(object sender, RoutedEventArgs e)
    {
        uiButtonClicked = true;
        PauseButton_OnClick(sender, e);

        if (songsList.SelectedIndex >= 0)
        {
            songsList.SelectedIndex -= 1;
            loadSong(sender, e);
            PlayButton_OnClick(sender, e);
        }
    }


    private void PauseButton_OnClick(Object sender, RoutedEventArgs e)
    {
        uiButtonClicked = true;
        playPauseImg.Source = new BitmapImage(new Uri(@"/img/play.png", UriKind.Relative));
        player.stop();
        isPlaying = false;
        UpdateUI();
    }


    private void RandomSongButton_OnClick(Object sender, RoutedEventArgs e)
    {
        if (isPlaying == false && playlist != null)
        {
            playlist.wymieszaj();
        }
    }

    private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        double newValue = e.NewValue;

        player.AdjustVolume(newValue);
    }

    private void DeleteSongButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (playlistList != null && songsList.SelectedIndex >= 0)
        {

            playlist.usunUtwor(songsList.SelectedIndex);
            playlistList.SelectedIndex=-1;

        }
    }




    private void UpdateUI()
    {
        int index = playlistList.SelectedIndex;
        int songIndex = songsList.SelectedIndex;
        playlistList.Items.Clear();
        foreach (var i in biblioteka.getPlaylisty())
        {
            playlistList.Items.Add(i.getNazwa());
        }
        if (index >= 0)
        {
            if(biblioteka.getPlaylista(index) == null)
            {
                playlistList.SelectedIndex = -1;
                songsList.SelectedIndex = -1;
                songsList.Items.Clear();
                return;
            }
            songsTitle.Text = biblioteka.getPlaylista(index).getNazwa();
            songsList.Items.Clear();
            playlist = biblioteka.getPlaylista(index);
            foreach (var i in playlist.getLista())
            {
                songsList.Items.Add(i.getTytul());
            }
        }
        save();
        playlistList.SelectedIndex = index;
        songsList.SelectedIndex = songIndex;

    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ComboBoxItem typeItem = (ComboBoxItem)sortChange.SelectedItem;
        if(typeItem == null)
        {
            return;
        }
        if (typeItem.Content.ToString() == "Autor")
        {
            Playlista playlista = biblioteka.getPlaylista(playlistList.SelectedIndex);
            if(playlista == null)
            {
                sortChange.SelectedIndex = -1;
                return;
            }
            context.SetStrategy(new AutorSort(),playlista.getLista());
            playlista.listaUtworow = context.Sort();
            UpdateUI();
        }
        if (typeItem.Content.ToString() == "Utwor")
        {
            Playlista playlista = biblioteka.getPlaylista(playlistList.SelectedIndex);
            if (playlista == null)
            {
                sortChange.SelectedIndex = -1;
                return;
            }
            context.SetStrategy(new TitleSort(), playlista.getLista());
            playlista.listaUtworow = context.Sort();
            UpdateUI();
        }
    }
}