using System.IO;
using System.Security;
using System.Windows;
using Spotify.logic;

namespace Spotify.view;

public partial class AddSong : Window
{
    private Playlista _playlista;
    private Utwor utworProto;
    public AddSong(Playlista playlista)
    {
        InitializeComponent();
        _playlista = playlista;
        utworProto = new Utwor("template", new Autor("template", "template"), 996, "../../../songs/");
        tytul.Text = utworProto.getTytul();
        autor.Text = utworProto.autorUtworu.imie +" "+ utworProto.autorUtworu.nazwisko;
        rok.Text = utworProto.rokWydania.ToString();
        sciezka.Text = utworProto.sciezka.ToString();
    }

    private void Submit_OnClick(object sender, RoutedEventArgs e)
    {
        string newDir = "../../../songs/";
        Utwor utwor = utworProto.Clone() as Utwor;
        utwor.AddPath(tytul.Text);
        utwor.nazwa = tytul.Text;
        File.Copy(sciezka.Text,newDir+tytul.Text+".wav");
        _playlista.dodajUtwor(utwor);
        
    }
}