using NAudio.Wave;
using NAudio.FileFormats;
using System;
using System.IO;
using System.Windows;

namespace Spotify.logic
{
    public interface State
    {
        WaveOutEvent Play(string filePath, WaveOutEvent waveOut);
        void Pause(WaveOutEvent waveOut);
        WaveOutEvent Stop(WaveOutEvent waveOut);
    }

    class PlayState : State
    {
        public WaveOutEvent Play(string filePath, WaveOutEvent waveOut)
        {
            if (waveOut != null && waveOut.PlaybackState == PlaybackState.Paused)
            {
                waveOut.Play();
                return waveOut;
            }
            else
            {

                bool isMp3;
                try
                {
                    new AudioFileReader(filePath);
                    isMp3 = false;
                }
                catch
                {
                    isMp3 = true;
                }
                if (isMp3)
                {

                    var audioFile = new Mp3FileReader(filePath);
                    waveOut = new WaveOutEvent();
                    waveOut.Init(audioFile);
                    waveOut.Play();
                    return waveOut;


                }
                else
                {
                    var audioFile = new AudioFileReader(filePath);
                    waveOut = new WaveOutEvent();
                    waveOut.Init(audioFile);
                    waveOut.Play();
                    return waveOut;
                }
            }
        }

        public void Pause(WaveOutEvent waveOut)
        {
            
        }

        public WaveOutEvent Stop(WaveOutEvent waveOut)
        {
            return null;
        }
    }

    class PauseState : State
    {
        public WaveOutEvent Play(string filePath, WaveOutEvent waveOut)
        {
            return null;
        }

        public void Pause(WaveOutEvent waveOut)
        {
            waveOut.Pause();
        }

        public WaveOutEvent Stop(WaveOutEvent waveOut)
        {
            return null;
        }
    }

    class StopState : State
    {
        public WaveOutEvent Play(string filePath, WaveOutEvent waveOut)
        {
            return null;
        }

        public void Pause(WaveOutEvent waveOut)
        {
            
        }

        public WaveOutEvent Stop(WaveOutEvent waveOut)
        {
            waveOut?.Stop();
            waveOut?.Dispose();
            return null;
        }
    }
}
