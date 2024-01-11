using System.ComponentModel;
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
using Spotify.logic;
using Spotify.view;
using Spotify.VIew;

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
    public MainWindow()
    {
        InitializeComponent();
        biblioteka = Biblioteka.GetInstance();
        player = Player.getInstance();
        refresh();
    }

    public void refresh()
    {
        playlistList.Items.Clear();
        foreach (var i in biblioteka.getPlaylisty())
        {
            playlistList.Items.Add(i.getNazwa());
        }
        
    }

    private void CreateNewPlaylistButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddPlaylist addPlaylist = new AddPlaylist();
        addPlaylist.Show();
    }

    private void moveToPlaylist(object sender, SelectionChangedEventArgs e)
    {
        songsTitle.Text = biblioteka.getPlaylista(playlistList.SelectedIndex).getNazwa();
        songsList.Items.Clear();
        playlist = biblioteka.getPlaylista(playlistList.SelectedIndex);
        foreach (var i in playlist.getLista())
        {
            songsList.Items.Add(i.getTytul() +" "+i.getAutor().getNazwisko());
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
        player.play(songToPlay.getSciezka());
    }
}