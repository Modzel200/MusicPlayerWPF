using System.Text.Json.Serialization;

namespace Spotify.logic;

public class Biblioteka
{
    public List<Playlista> listaPlaylist { get; set; }
    public List<Album> albumy { get; set; }
    public List<Utwor> utwory { get; set; }
    public List<Autor> autorzy { get; set; }

    private Biblioteka()
    {
        listaPlaylist = new List<Playlista>();
        albumy = new List<Album>();
        utwory = new List<Utwor>();
        autorzy = new List<Autor>();
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
    public void addAutor(Autor autor)
    {
        autorzy.Add(autor);
    }
}