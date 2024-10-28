using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameObjects
{
   public abstract class GameMovingObject : GameObject
    {
        public GameMovingObject(Scene scene, string filename, double placeX, double placeY) : base(scene, filename, placeX, placeY)
        {
        }
    }
}
