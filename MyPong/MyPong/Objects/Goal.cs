using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPong.Objects
{
    public class Goal : GameObject
    {
        public Goal(string filename, double size, double x, double y) : base(filename, size, x, y)
        {
            image.Width = 50;
            image.Height = size;
        }
    }
}
