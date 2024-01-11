namespace Spotify.logic;

public class Autor
{
    private string imie;
    private string nazwisko;
    private string? pseudonim;
    private string? narodowocs;

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