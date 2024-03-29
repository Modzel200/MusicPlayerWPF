﻿using System.Text.Json.Serialization;
using System.Windows;

namespace Spotify.logic;

public class Biblioteka : Subject
{
    public static int iter;
    public List<Playlista> listaPlaylist { get; set; }
    public List<Prototyp> albumyIUtwory { get; set; }
    public List<AutorBezSzczegolow> autorzy { get; set; }
    public List<AutorSzczegoly> autorzySzczegoly {  get; set; }

    private Biblioteka()
    {
        listaPlaylist = new List<Playlista>();
        albumyIUtwory = new List<Prototyp>();
        autorzy = new List<AutorBezSzczegolow>();
        autorzySzczegoly = new List<AutorSzczegoly>();
        iter = 0;
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

    public Playlista? getPlaylista(int i)
    {
        var exists = listaPlaylist.ElementAtOrDefault(i) != null;
        if (exists)
        {
            return listaPlaylist[i];
        }
        return null;
    }
    public List<Album> getAlbumy()
    {
        List<Album> list = new List<Album>();
        foreach (Album album in albumyIUtwory.OfType<Album>())
        {
            list.Add(album);
        }
        return list;
    }

    public List<Utwor> getUtwory()
    {
        List<Utwor> list = new List<Utwor>();
        foreach (Utwor utwor in albumyIUtwory.OfType<Utwor>())
        {
            list.Add(utwor);
        }
        return list;
    }

    public void addPlaylista(Playlista playlista)
    {
        listaPlaylist.Add(playlista);
        NotifyObservers();
    }

    public void removePlaylista(Playlista playlista)
    {
        listaPlaylist.Remove(playlista);
        NotifyObservers();
    }
    public void addAutor(AutorBezSzczegolow autor)
    {
        autorzy.Add(autor);
        NotifyObservers();
    }
    public void addAutorSzczegoly(AutorSzczegoly autor)
    {
        autorzySzczegoly.Add(autor);
        NotifyObservers();
    }
    public int getIter()
    {
        return iter;
    }
    public void increaseIter()
    {
        iter++;
    }

    public void upPosition(int i)
    {
        if(i > 0 && i != -1)
        {
            (listaPlaylist[i], listaPlaylist[i -1]) = (listaPlaylist[i - 1], listaPlaylist[i]);
        }
        NotifyObservers();
    }

    public void downPosition(int i)
    {
        if (i < listaPlaylist.Count-1 && i!= -1)
        {
            (listaPlaylist[i], listaPlaylist[i+1]) = (listaPlaylist[i+1], listaPlaylist[i]);
        }
        NotifyObservers();
    }

}