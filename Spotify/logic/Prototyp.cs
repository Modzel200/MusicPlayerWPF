using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.logic
{
    public abstract class Prototyp
    {
        public string nazwa {  get; set; }
        protected Prototyp(string nazwa)
        {
            this.nazwa = nazwa;
        }
        public abstract Prototyp Clone();
    }
}
