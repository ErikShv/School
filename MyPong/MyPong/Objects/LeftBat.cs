using MyPong.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace MyPong.Objects
{
    public class LeftBat : Bat
    {
        public LeftBat(Canvas scene, string filename, double height, double x, double y) : base(scene, filename, height, x, y)
        {
            _dy = 0;
        }
        protected override void MoveBat(VirtualKey key)
        {
            if(key == KeyBinds.LeftPlayerUp)
            {
                _dy = -5;
            }
            if (key == KeyBinds.LeftPlayerDown)
            {
                _dy = 5;
            }
            
        }
        protected override void StopBat(VirtualKey key)
        {
            if(key == KeyBinds.LeftPlayerUp || key == KeyBinds.LeftPlayerDown)
            {
                _dy = 0;
            }
        }
    }
}

