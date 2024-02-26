using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPong.Objects
{
    public class Fan : GameObject
    {
        public Fan(string filename, double size, double x, double y) : base(filename, size, x, y)
        {
            image.Width = 200;
            image.Height = size;
        }
    }
}
