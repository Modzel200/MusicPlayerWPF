namespace Spotify.logic;

public class Biblioteka
{
    private List<Playlista> listaPlaylist;
    private List<Album> albumy;
    private List<Utwor> utwory;

    private Biblioteka()
    {
        listaPlaylist = new List<Playlista>();
    }

    private static Biblioteka _instance;
    public static Biblioteka GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Biblioteka();
        }

        return _instance;
    }
    public List<Playlista> getPlaylisty()
    {
        return listaPlaylist;
    }

    public Playlista getPlaylista(int i)
    {
        return listaPlaylist[i];
    }
    public List<Album> getAlbumy()
    {
        return albumy;
    }

    public List<Utwor> getUtwory()
    {
        return utwory;
    }

    public void addPlaylista(Playlista playlista)
    {
        listaPlaylist.Add(playlista);
    }
}