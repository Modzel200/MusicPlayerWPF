namespace Spotify.logic;

public class Autor
{
    public string imie { get; set; }
    public string nazwisko { get; set; }
    public string? pseudonim { get; set; }
    public string? narodowosc { get; set; }

    public Autor(string i, string n)
    {
        imie = i;
        nazwisko = n;
    }
    public string getNazwisko()
    {
        return nazwisko;
    }
}