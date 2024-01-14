using NAudio.Wave;
using System;
using System.Windows;

namespace Spotify.logic
{
    public class Player
    {
        private WaveOutEvent waveOut;
        private State state;
        public TimeSpan PlaybackTime { get; set; }

        private Player()
        {
            state = new PauseState();
            PlaybackTime = TimeSpan.Zero;
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

        public void SetState(State newState)
        {
            state = newState;
        }

        public void play(string filePath)
        {
            state = new PlayState();
            waveOut = state.Play(filePath, waveOut);
        }

        public void stop()
        {
            state = new StopState();
            state.Stop(waveOut);
        }

        public void AdjustVolume(double glosnosc)
        {
            if (waveOut != null)
            {
 
                waveOut.Volume = (float)glosnosc;
            }
        }

    }
}
