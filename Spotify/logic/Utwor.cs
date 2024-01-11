namespace Spotify.logic;

public class Utwor
{
    private string tytul;
    private Autor autorUtworu;
    private Gatunek? gatunekUtworu;
    private int rokWydania;
    private string sciezka;
    private float? dlugosc;
    private int? odsluchania;

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