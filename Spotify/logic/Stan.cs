using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Spotify.logic
{
    public interface Stan
    {
        SoundPlayer Odtwarzaj(string sciezka, SoundPlayer soundPlayer);
        void Pauza(SoundPlayer soundPlayer);
        SoundPlayer Zatrzymaj(SoundPlayer soundPlayer);
    }


    class StanOdtwarzanie : Stan
    {
        private SoundPlayer soundPlayer;
        public SoundPlayer Odtwarzaj(string sciezka, SoundPlayer soundPlayer)
        {
            soundPlayer = new SoundPlayer(sciezka);
            soundPlayer.Play();
            return soundPlayer;
        }

        public void Pauza(SoundPlayer soundPlayer)
        {

        }

        public SoundPlayer Zatrzymaj(SoundPlayer soundPlayer)
        {
            return null;
        }
    }

    class StanPauza : Stan
    {
        public SoundPlayer Odtwarzaj(string sciezka, SoundPlayer soundPlayer)
        {
            return null;
        }

        public void Pauza(SoundPlayer soundPlayer)
        {
            soundPlayer.Stop();
        }

        public SoundPlayer Zatrzymaj(SoundPlayer soundPlayer)
        {
            return null;
        }
    }

    class StanZatrzymanie : Stan
    {
        public SoundPlayer Odtwarzaj(string sciezka, SoundPlayer soundPlayer)
        {
            return null;
        }

        public void Pauza(SoundPlayer soundPlayer)
        {
           
        }

        public SoundPlayer Zatrzymaj(SoundPlayer soundPlayer)
        {
            soundPlayer = new SoundPlayer();
            return soundPlayer;
        }
    }
}
