using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyPong.Objects
{
    class RightBat : Bat
    {
        public RightBat(Canvas scene, string filename, double height, double x, double y) : base(scene,filename, height, x, y)

        {
            _dy= -3;
        }
    }
}
