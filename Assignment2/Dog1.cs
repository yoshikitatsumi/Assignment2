﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public class Dog1:Greyhound
    {
        public override string Number { get; set; }
        public override PictureBox Picture { get; set; }
        public Dog1(string tempNumber, PictureBox tempPic)
        {
            Number = tempNumber;
            Picture = tempPic;
        }
        public override void Move
            (int distance)
        {

            Picture.Location = new Point(Picture.Location.X + distance, Picture.Location.Y);
        }
    }
}
