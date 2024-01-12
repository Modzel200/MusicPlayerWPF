using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;
using Spotify.logic;

namespace Spotify.VIew;

public partial class AddPlaylist : Window
{
    public Biblioteka biblioteka;
    public AddPlaylist(Biblioteka biblioteka)
    {
        InitializeComponent();
        this.biblioteka = biblioteka;
    }

    private void CreatePlaylistButton_OnClick(object sender, RoutedEventArgs e)
    {
        biblioteka.addPlaylista(new Playlista(playlistName.Text));
    }
}