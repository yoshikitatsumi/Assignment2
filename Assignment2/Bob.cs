using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2;

namespace Assignment2
{
    public class Bob:Punter
    {        //these are properties
        public override string Name { get; set; }
        public override int Cash { get; set; }
        public override int Bet { get; set; }
        public override Greyhound Dog { get; set; }

        //this is the constructor
        public Bob(string name, int cash)
        {
            Name = name;
            Cash = cash;
        }

        //this is a method
        public override void Betting(Greyhound dog, int bet)
        {
            Dog = dog;
            Bet = bet;
        }
    }
}
