namespace Spotify.logic;

public class Memento
{
    public string? State
    {
        get;
        set;
    }

    public Memento(string? state)
    {
        State = state;
    }
}

public class Originator
{
    public string? State
    {
        get;
        set;
    }

    public void RestoreState(Memento memento)
    {
        State = memento.State;
    }

    public Memento SaveState()
    {
        return new Memento(State);
    }
}