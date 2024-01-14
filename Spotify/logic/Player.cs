using System.Media;

namespace Spotify.logic;

public class Player
{
    private SoundPlayer soundPlayer;
    private Stan stan;
    public TimeSpan CzasOdtwarzania { get; set; }
    private Player()
    {
        stan = new StanPauza();
        CzasOdtwarzania = TimeSpan.Zero;
    }
    private static Player _player;

    public static Player getInstance()
    {
        if (_player == null)
        {
            _player = new Player();
        }

        return _player;
    }

    public void play(string sciezka)
    {
        stan = new StanOdtwarzanie();
        soundPlayer = stan.Odtwarzaj(sciezka + ".wav", soundPlayer);
    }

    public void stop()
    {
        stan = new StanPauza();
        stan.Pauza(soundPlayer);
    }
} 