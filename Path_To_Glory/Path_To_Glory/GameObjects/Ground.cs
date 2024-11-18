using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameObjects
{
    class Ground : GameObject
    {
        public Ground(Scene scene, string filename, double placeX, double placeY) : base(scene, filename, placeX, placeY)
        {
            Image.Width = 1000;
            Image.Height = 50;
        }
        
    }
}
