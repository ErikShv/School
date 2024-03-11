using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPong.Objects
{
     public abstract class Bat : GameMovingObject
     {
        public Bat(string filename, double height, double x, double y) : base(filename, height, x, y)
        {
            image.Width = 20;
            image.Height = height;
        }
     }
}
