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
            if (imie.Text.Length > 0 && nazwisko.Text.Length > 0 && pseudonim.Text.Length > 0 && _biblioteka.autorzy.FirstOrDefault(x => x.pseudonim == pseudonim.Text) == null && _biblioteka.autorzySzczegoly.FirstOrDefault(x => x.imie == imie.Text && x.nazwisko == nazwisko.Text && x.narodowosc == narodowosc.Text && x.krotkiOpis == opis.Text) == null )
            {
                AutorBezSzczegolow autorBez = new AutorBezSzczegolow(pseudonim.Text);
                AutorSzczegoly autorZ = new AutorSzczegoly(imie.Text, nazwisko.Text, narodowosc.Text, opis.Text);
                autorBez.setIndeks(_biblioteka.getIter());
                autorZ.setIndeks(_biblioteka.getIter());
                _biblioteka.increaseIter();
                _biblioteka.addAutor(autorBez);
                _biblioteka.addAutorSzczegoly(autorZ);
                this.Close();
            }
        }
    }
}
