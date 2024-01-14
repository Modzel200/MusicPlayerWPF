using Spotify.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spotify.view
{
    /// <summary>
    /// Logika interakcji dla klasy AddAutor.xaml
    /// </summary>
    public partial class AddAutor : Window
    {
        private Biblioteka _biblioteka;
        public AddAutor(Biblioteka biblioteka)
        {
            InitializeComponent();
            this._biblioteka = biblioteka;
        }
        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            if (imie.Text.Length > 0 && nazwisko.Text.Length > 0 && pseudonim.Text.Length > 0 && _biblioteka.autorzy.FirstOrDefault(x => x.imie == imie.Text && x.nazwisko == nazwisko.Text && x.pseudonim == pseudonim.Text && x.narodowosc == narodowosc.Text) == null)
            {
                _biblioteka.addAutor(new Autor(imie.Text, nazwisko.Text, pseudonim.Text, narodowosc.Text));
                this.Close();
            }
        }
    }
}
