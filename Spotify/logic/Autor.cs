namespace Spotify.logic;

public abstract class Autor
{
    public int indeks;
    public abstract List<string> getInfo();

    public abstract void setIndeks(int indeks);
    
    //public string getNazwisko()
    //{
    //    return nazwisko;
    //}
    
}
public class AutorBezSzczegolow : Autor
{
    public string pseudonim { get; set; }
    public List<Utwor> utwory { get; set; }
    public AutorBezSzczegolow(string p)
    {
        pseudonim = p;
        utwory = new List<Utwor>();
    }
    public void dodajPiosenke(Utwor utwor)
    {
        this.utwory.Add(utwor);
    }
    public override List<string> getInfo()
    {
        return new List<string>() { pseudonim};
    }
    public override void setIndeks(int indeks)
    {
        base.indeks = indeks;
    }
}
public abstract class AutorDecorator : Autor
{
    Autor autor;
    public AutorDecorator(Autor autor)
    {
        this.autor = autor;
    }
    public Autor GetAutor()
    {
        return this.autor;
    }
    public void SetAutor(Autor autor)
    {
        this.autor = autor;
    }
}
public class AutorSzczegoly : Autor
{
    public string imie { get; set; }
    public string nazwisko { get; set; }
    public string narodowosc { get; set; }
    public string krotkiOpis { get; set; }
    public AutorSzczegoly(string imie, string nazwisko, string narodowosc, string krotkiOpis)
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.narodowosc = narodowosc;
        this.krotkiOpis = krotkiOpis;
    }
    public override List<string> getInfo()
    {
        return new List<string>() { imie, nazwisko, narodowosc, krotkiOpis };
    }
    public override void setIndeks(int indeks)
    {
        base.indeks = indeks;
    }
}
public class AutorCaleInfo : AutorDecorator
{
    Biblioteka _biblioteka { get; set; }
    public AutorCaleInfo(Autor autor, Biblioteka biblioteka) : base(autor)
    {
        _biblioteka = biblioteka;
    }
    public override List<string> getInfo()
    {
        List<string> info = _biblioteka.autorzySzczegoly.FirstOrDefault(x => x.indeks == GetAutor().indeks).getInfo();
        Autor tenAutor = GetAutor();
        List<string> pseudonim = tenAutor.getInfo();
        foreach(string elem in info)
        {
            pseudonim.Add(elem);
        }
        return pseudonim;
    }
    public override void setIndeks(int indeks)
    {
        base.indeks = indeks;
    }
}