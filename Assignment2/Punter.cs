using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2;

namespace Assignment2
{
    public abstract class Punter
    { 
        public abstract string Name { get; set; }
        public abstract int Cash { get; set; }
        public abstract int Bet { get; set; }
        public abstract Greyhound Dog { get; set; }

        public abstract void Betting(Greyhound dog, int bet);
    }
}
