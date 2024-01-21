namespace Spotify.logic;

public class Playlista : Subject
{
    public string nazwa {  get; set; }
    public List<Utwor> listaUtworow { get; set; }
    public int ilosc { get; set; }
    public float dlugosc { get; set; }

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
        NotifyObservers();
    }

    public List<Utwor> getLista()
    {
        return listaUtworow;
    }

    public Utwor? getUtwor(int i)
    {
        if (listaUtworow.Count > 0 && i < listaUtworow.Count && i != -1)
        {
            return listaUtworow[i];
        }
        return null;
    }

    public void usunUtwor(int i)
    {
        if (listaUtworow.Count > 0 && i < listaUtworow.Count && i != -1)
        {
            listaUtworow.RemoveAt(i);
        }
        NotifyObservers();
    }

    public int getIlosc()
    {
        return ilosc;
    }

    public float getDlugosc(int i)
    {
        return dlugosc;
    }

    public void upPosition(int i)
    {
        if (i > 0 && i != -1)
        {
            (listaUtworow[i], listaUtworow[i - 1]) = (listaUtworow[i - 1], listaUtworow[i]);
        }
        NotifyObservers();
    }

    public void downPosition(int i)
    {
        if (i < listaUtworow.Count - 1 && i != -1)
        {
            (listaUtworow[i], listaUtworow[i + 1]) = (listaUtworow[i + 1], listaUtworow[i]);
        }
        NotifyObservers();
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
        NotifyObservers();
    }
}