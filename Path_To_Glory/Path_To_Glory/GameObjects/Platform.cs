using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameObjects
{
    class Platform : GameObject
    {
        public Platform(Scene scene, string filename, double placeX, double placeY) : base(scene, filename, placeX, placeY)
        {
            Image.Height = 50;
            
        }
        
    }
}
