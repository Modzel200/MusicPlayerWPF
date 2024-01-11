using System.Media;

namespace Spotify.logic;

public class Player
{
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
        SoundPlayer soundPlayer = new SoundPlayer(sciezka);
        soundPlayer.Play();
    }
}