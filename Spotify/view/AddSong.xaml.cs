using System.IO;
using System.Security;
using System.Windows;
using Microsoft.Win32;
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

    private void SelectFileButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        openFileDialog.Title = "Wybierz plik";
        openFileDialog.Filter = "Pliki dźwiękowe (*.mp3;*.wav)|*.mp3;*.wav|Wszystkie pliki (*.*)|*.*";
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        bool? result = openFileDialog.ShowDialog();

        if (result == true)
        {
            string selectedFilePath = openFileDialog.FileName;
            sciezka.Text = selectedFilePath;
        }
    }
}