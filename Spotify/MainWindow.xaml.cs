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
using Spotify.logic;
using Spotify.view;
using Spotify.VIew;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
    public MainWindow()
    {
        Playlista playProto = new Playlista("Template");
        biblioteka = Biblioteka.GetInstance();
        if (File.Exists("test.json"))
        {
            string jsonString = File.ReadAllText("test.json");
            // var deserialized = JsonConvert<Biblioteka>(jsonString);
            var deserialized = JsonConvert.DeserializeObject<Biblioteka>(jsonString);
            biblioteka = deserialized;
        }
        InitializeComponent();
        originator = new Originator();
        savedStates = new List<Memento>();
        player = Player.getInstance();
        isPlaying = false;
        refresh();
    }

    public void refresh()
    {
        playlistList.Items.Clear();
        foreach (var i in biblioteka.getPlaylisty())
        {
            playlistList.Items.Add(i.getNazwa());
        }
        originator.State = JsonSerializer.Serialize<Biblioteka>(biblioteka);
        File.WriteAllText("test.json",originator.State);
        savedStates.Add(originator.SaveState());
    }

    private void CreateNewPlaylistButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddPlaylist addPlaylist = new AddPlaylist(biblioteka);
        addPlaylist.Show();
    }

    private void moveToPlaylist(object sender, SelectionChangedEventArgs e)
    {
        if (playlistList.SelectedIndex >= 0)
        {
            songsTitle.Text = biblioteka.getPlaylista(playlistList.SelectedIndex).getNazwa();
            songsList.Items.Clear();
            playlist = biblioteka.getPlaylista(playlistList.SelectedIndex);
            foreach (var i in playlist.getLista())
            {
                songsList.Items.Add(i.getTytul() +" "+i.getAutor().getNazwisko());
            }
        }
    }

    private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
    {
        refresh();
    }

    private void loadSong(object sender, RoutedEventArgs e)
    {
        songToPlay = playlist.getUtwor(songsList.SelectedIndex);
    }

    private void CreateNewSongButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddSong addSong = new AddSong(playlist);
        addSong.Show();
    }

    private void PlayButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (isPlaying == false)
        {
            player.play(songToPlay.getSciezka());
            isPlaying = true;
            //playPauseImg.Source = "/../../../img/play.png";
            playPauseImg.Source = new BitmapImage(new Uri(@"/img/stop.png", UriKind.Relative));
        }
        else
        {
            isPlaying = false;
            player.stop();
            playPauseImg.Source = new BitmapImage(new Uri(@"/img/play.png", UriKind.Relative));
        }

    }
}