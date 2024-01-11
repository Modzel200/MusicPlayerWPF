namespace Spotify.logic;

public class Playlista
{
    private string nazwa;
    private List<Utwor> listaUtworow;
    private int ilosc;
    private float dlugosc;

    public Playlista(string nazwaPlaylisty)
    {
        nazwa = nazwaPlaylisty;
        ilosc = 0;
        dlugosc = 0;
        listaUtworow = new List<Utwor>();
    }

    public string getNazwa()
    {
        return nazwa;
    }
    public void dodajUtwor(Utwor utwor)
    {
        listaUtworow.Add(utwor);
        ilosc++;
    }

    public List<Utwor> getLista()
    {
        return listaUtworow;
    }

    public Utwor getUtwor(int i)
    {
        return listaUtworow[i];
    }
    public int getIlosc()
    {
        return ilosc;
    }

    public float getDlugosc()
    {
        return dlugosc;
    }

    public void wymieszaj()
    {
        var rng = new Random();
        int n = ilosc;
        while (n > 1)
        {
            int k = rng.Next(n--);
            (listaUtworow[n], listaUtworow[k]) = (listaUtworow[k], listaUtworow[n]);
        }
    }

    public void wyeksportuj()
    {
        //logika do napisania
    }
}