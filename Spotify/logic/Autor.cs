namespace Spotify.logic;

public class Autor
{
    public string imie { get; set; }
    public string nazwisko { get; set; }
    public string pseudonim { get; set; }
    public string narodowosc { get; set; }
    public List<Utwor> utwory {  get; set; }

    public Autor(string i, string n, string p, string nar)
    {
        imie = i;
        nazwisko = n;
        pseudonim = p;
        narodowosc = nar;
        utwory = new List<Utwor>();
    }
    public string getNazwisko()
    {
        return nazwisko;
    }
    public void dodajPiosenke(Utwor utwor)
    {
        this.utwory.Add(utwor);
    }
}