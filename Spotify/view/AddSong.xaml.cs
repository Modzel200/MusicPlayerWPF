using System.Security;
using System.Windows;
using Spotify.logic;

namespace Spotify.view;

public partial class AddSong : Window
{
    private Playlista _playlista;
    public AddSong(Playlista playlista)
    {
        InitializeComponent();
        _playlista = playlista;
    }

    private void Submit_OnClick(object sender, RoutedEventArgs e)
    {
        _playlista.dodajUtwor(new Utwor(tytul.Text,new Autor("Robert",autor.Text),int.Parse(rok.Text),sciezka.Text));
    }
}