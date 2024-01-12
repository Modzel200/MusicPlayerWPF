namespace Spotify.logic;

public class Album
{
    public string nazwa { get; set; }
    public List<Utwor> listaUtworow { get; set; }
    public Autor autorAlbumu { get; set; }
    public int rokWydania { get; set; }

    public Album()
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
}