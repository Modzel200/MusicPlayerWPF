namespace Spotify.logic;

public class Utwor
{
    public string tytul { get; set; }
    public Autor autorUtworu { get; set; }
    public Gatunek? gatunekUtworu { get; set; }
    public int rokWydania { get; set; }
    public string sciezka { get; set; }
    public float? dlugosc { get; set; }
    public int? odsluchania { get; set; }

    public Utwor(string t, Autor a, int r, string s)
    {
        tytul = t;
        autorUtworu = a;
        rokWydania = r;
        sciezka = s;
    }
    public string getTytul()
    {
        return tytul;
    }

    public Autor getAutor()
    {
        return autorUtworu;
    }

    public string getSciezka()
    {
        return sciezka;
    }

    public float getDlugosc()
    {
        return (float)dlugosc;
    }

    public int getOdsluchania()
    {
        return (int)odsluchania;
    }
}