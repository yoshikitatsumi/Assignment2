using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public abstract class Greyhound
    {
        public abstract string Number { get; set; }
        public string Dog;
        public abstract PictureBox Picture { get; set; }
        public abstract void Move(int distance);

    }
}
