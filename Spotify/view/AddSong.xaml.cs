using System.IO;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Spotify.logic;

namespace Spotify.view;

public partial class AddSong : Window
{
    private Playlista _playlista;
    private Utwor utworProto;
    private Biblioteka _biblioteka;
    private Autor _autor;
    public AddSong(Playlista playlista, Biblioteka biblioteka)
    {
        _biblioteka = biblioteka;
        InitializeComponent();

        RefreshCombo();
        _playlista = playlista;
        utworProto = new Utwor("template", new Autor("template", "template", "template", "template"), 996, "../../../songs/");
        tytul.Text = utworProto.getTytul();
        rok.Text = utworProto.rokWydania.ToString();
        sciezka.Text = utworProto.sciezka.ToString();
    }
    private void RefreshCombo()
    {
        this.autor.ItemsSource = _biblioteka.autorzy;
    }

    private void Submit_OnClick(object sender, RoutedEventArgs e)
    {
        if (File.Exists(sciezka.Text) && tytul.Text.Length > 0 && autor.Text.Length > 0 && rok.Text.Length > 0 && _playlista.listaUtworow.FirstOrDefault(x => x.nazwa == tytul.Text) == null)
        {
            string newDir = "../../../songs/";
            Utwor utwor = utworProto.Clone() as Utwor;
            utwor.AddPath(tytul.Text);
            utwor.nazwa = tytul.Text;
            utwor.autorUtworu = _autor;
            string originalFilePath = sciezka.Text;
            string newFilePath = Path.Combine(newDir, Path.GetFileName(originalFilePath));
            

            var existingSong = _playlista.getLista().FirstOrDefault(obj => obj.sciezka == newFilePath);

            if (existingSong != null)
            {
                MessageBox.Show("Utwór już jest w playliscie");
                return;
            }

            if (File.Exists(newFilePath))
            {
                Biblioteka biblioteka = Biblioteka.GetInstance();
                List<Utwor> utwory = biblioteka.getUtwory();

                var utwor_istniejacy = utwory.Find(obj => obj.sciezka == newFilePath);

                if (utwor_istniejacy != null)
                {

                    _playlista.dodajUtwor(utwor_istniejacy);
                }
                else
                {                    
                    utwor.AddPath(newFilePath);
                    _autor.dodajPiosenke(utwor);
                    _playlista.dodajUtwor(utwor);
                    utwory.Add(utwor);
                }
            }
            else
            {
                File.Copy(originalFilePath, newFilePath);
                utwor.AddPath(newFilePath);
                _autor.dodajPiosenke(utwor);
                _playlista.dodajUtwor(utwor);

            }

            this.Close();
        }


    }
    private void autor_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        Autor selectedAutor = (Autor)autor.SelectedItem;
        _autor = selectedAutor;
    }
    private void AddAutor(object sender, RoutedEventArgs e)
    {
        AddAutor addAutor = new AddAutor(_biblioteka);
        addAutor.Show();
    }


    private void SelectFileButton_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();

        openFileDialog.Title = "Wybierz plik";
        openFileDialog.Filter = "Pliki dźwiękowe (*.mp3;*.wav)|*.mp3;*.wav";
        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        bool? result = openFileDialog.ShowDialog();

        if (result == true)
        {
            string selectedFilePath = openFileDialog.FileName;
            sciezka.Text = selectedFilePath;
        }
    }
}