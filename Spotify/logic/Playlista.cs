namespace Spotify.logic;

public class Playlista : Prototyp
{
    public List<Utwor> listaUtworow { get; set; }
    public int ilosc { get; set; }
    public float dlugosc { get; set; }

    public Playlista(string nazwaPlaylisty) : base(nazwaPlaylisty)
    {
        ilosc = 0;
        dlugosc = 0;
        listaUtworow = new List<Utwor>();
    }

    public string getNazwa()
    {
        return base.nazwa;
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