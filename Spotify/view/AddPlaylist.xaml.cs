using System.IO;
using System.Net;
using System.Text.Json;
using System.Windows;
using Spotify.logic;

namespace Spotify.VIew;

public partial class AddPlaylist : Window
{
    public Biblioteka biblioteka;
    private Playlista proto;
    public AddPlaylist(Biblioteka biblioteka)
    {
        proto = new Playlista("template");
        InitializeComponent();
        playlistName.Text = proto.getNazwa().ToString();
        this.biblioteka = biblioteka;
        
    }

    private void CreatePlaylistButton_OnClick(object sender, RoutedEventArgs e)
    {
        if(playlistName.Text.Length >0 && biblioteka.listaPlaylist.FirstOrDefault(x => x.nazwa == playlistName.Text) == null)
        {
            Playlista input = new Playlista("template");
            input.nazwa = playlistName.Text;
            biblioteka.addPlaylista(input);
            this.Close();
        }
    }
}