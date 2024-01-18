using NAudio.Mixer;

namespace Spotify.logic;

public class Context
{
    private IStrategy _strategy;
    private List<Utwor> _playlista;
    public Context()
    { }
    public Context(IStrategy strategy, List<Utwor> playlista)
    {
        this._strategy = strategy;
        this._playlista = playlista;
    }

    public void SetStrategy(IStrategy strategy, List<Utwor> playlista)
    {
        this._strategy = strategy;
        this._playlista = playlista;
    }

    public List<Utwor> Sort()
    {
        var result = this._strategy.DoAlgorithm(_playlista);
        return result;
    }
}
public interface IStrategy
{
    List<Utwor> DoAlgorithm(List<Utwor> data);
}

class TitleSort : IStrategy
{
    public List<Utwor> DoAlgorithm(List<Utwor> playlista)
    {
        var list = playlista;
        list = list.OrderBy(o => o.nazwa).ToList();
        return list;
    }
}
class AutorSort : IStrategy
{
    public List<Utwor> DoAlgorithm(List<Utwor> playlista)
    {
        var list = playlista;
        list = list.OrderBy(o => o.getAutor().pseudonim).ToList();
        return list;
    }
}