namespace Spotify.logic;

public class Album : Prototyp
{
    public List<Utwor> listaUtworow { get; set; }
    public AutorBezSzczegolow autorAlbumu { get; set; }
    public int rokWydania { get; set; }

    public Album(string nazwa) : base(nazwa)
    {
        listaUtworow = new List<Utwor>();
    }
    public List<Utwor> getListaUtworow()
    {
        return listaUtworow;
    }

    public string getNazwa()
    {
        return nazwa;
    }

    public Autor getAutor()
    {
        return autorAlbumu;
    }

    public int getRokWydania()
    {
        return rokWydania;
    }

    public override Prototyp Clone()
    {
        Album albumCopy = (Album)MemberwiseClone();
        albumCopy.listaUtworow = new List<Utwor>(listaUtworow);
        albumCopy.autorAlbumu = new AutorBezSzczegolow(this.autorAlbumu.pseudonim);
        albumCopy.rokWydania = this.rokWydania;
        return (Prototyp)MemberwiseClone();
    }
}