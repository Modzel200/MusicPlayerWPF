using System.Media;

namespace Spotify.logic;

public class Player
{
    private SoundPlayer soundPlayer;
    private Player()
    {
        
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
        soundPlayer = new SoundPlayer(sciezka+".wav");
        soundPlayer.Play();
    }

    public void stop()
    {
        soundPlayer.Stop();
    }
}