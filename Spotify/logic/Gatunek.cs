namespace Spotify.logic;

public class Gatunek : Prototyp
{
    public Gatunek(string nazwa) : base(nazwa)
    {
        
    }

    public string getGatunek()
    {
        return base.nazwa;
    }
    public override Prototyp Clone()
    {
        return (Prototyp)MemberwiseClone();
    }
}