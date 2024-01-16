namespace Spotify.logic;

public class Playlista : Prototyp, IObserver
{
    public List<Utwor> listaUtworow { get; set; }
    public int ilosc { get; set; }
    public float dlugosc { get; set; }
    private List<IObserver> observers = new List<IObserver>();
    private Action playlistUpdateFunction;

    public Playlista(string nazwaPlaylisty, Action updateFunction) : base(nazwaPlaylisty)
    {
        ilosc = 0;
        dlugosc = 0;
        listaUtworow = new List<Utwor>();
        playlistUpdateFunction = updateFunction;
    }

    public void Update()
    {
        playlistUpdateFunction?.Invoke();
    }

    public string getNazwa()
    {
        return base.nazwa;
    }
    public void dodajUtwor(Utwor utwor)
    {
        listaUtworow.Add(utwor);
        ilosc++;
        Update();
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
        Update();
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
        Update();
    }
    public override Prototyp Clone()
    {
        Playlista playlistaClone = (Playlista)MemberwiseClone();
        playlistaClone.ilosc = this.ilosc;
        playlistaClone.dlugosc = this.dlugosc;
        playlistaClone.listaUtworow = new List<Utwor>(this.listaUtworow);
        return playlistaClone;
    }

    public void wyeksportuj()
    {
        //logika do napisania
    }
}