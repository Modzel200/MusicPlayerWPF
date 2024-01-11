namespace Spotify.logic;

public class Album
{
    private string nazwa;
    private List<Utwor> listaUtworow;
    private Autor autorAlbumu;
    private int rokWydania;

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