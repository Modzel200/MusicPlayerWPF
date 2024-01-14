namespace Spotify.logic;

public class Utwor : Prototyp
{
    public Autor autorUtworu { get; set; }
    public Gatunek? gatunekUtworu { get; set; }
    public int rokWydania { get; set; }
    public string sciezka { get; set; }
    public float? dlugosc { get; set; }
    public int? odsluchania { get; set; }

    public Utwor(string t, Autor a, int r, string s) : base(t)
    {
        autorUtworu = a;
        rokWydania = r;
        sciezka = s;
    }
    public string getTytul()
    {
        return base.nazwa;
    }
    public void AddPath(string path)
    {
        this.sciezka += path;
    }

    public Autor getAutor()
    {
        return autorUtworu;
    }

    public string getSciezka()
    {
        return sciezka;
    }

    public float getDlugosc()
    {
        return (float)dlugosc;
    }

    public int getOdsluchania()
    {
        return (int)odsluchania;
    }
    public override Prototyp Clone()
    {
        Utwor utworClone = (Utwor)MemberwiseClone();
        utworClone.autorUtworu = new Autor(this.autorUtworu.imie, this.autorUtworu.nazwisko, this.autorUtworu.pseudonim, this.autorUtworu.narodowosc);
        //utworClone.gatunekUtworu = new Gatunek(this.gatunekUtworu.nazwa);
        utworClone.rokWydania = this.rokWydania;
        //utworClone.odsluchania = this.odsluchania;
        utworClone.sciezka = this.sciezka;
        utworClone.dlugosc = this.dlugosc;
        return utworClone;
    }
}