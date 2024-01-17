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

        public WaveOutEvent play(string filePath)
        {
            SetState(new PlayState());
            waveOut = state.Play(filePath, waveOut);
            return waveOut;
        }

        public void stop()
        {
            SetState(new StopState());
            state.Stop(waveOut);
        }

        public void pause()
        {
            SetState(new PauseState());
            state.Pause(waveOut);
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
