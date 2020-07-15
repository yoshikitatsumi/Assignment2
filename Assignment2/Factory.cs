using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment2;

namespace Assignment2
{
    public static class Factory
    {
        public static int count;
        public static Punter CreatePunter(string name, int bet)
        {
            if (name == "Joe")
            {
                count++;

                return new Joe("Joe", 100);
            }
            else if (name == "Bob")
            {
                count++;

                return new Bob("Bob", 100);
            }
            else if (name == "Al")
            {
                count++;

                return new Al("Al", 100);
            }
            return null;
        }
 
    }

}
