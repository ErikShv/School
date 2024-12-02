using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameObjects
{
    class ReaperSlash : GameMovingObject
    {
        public ReaperSlash(Scene scene, string filename, double placeX, double placeY,bool Right) : base(scene, filename, placeX, placeY)
        {
            Image.Height = 40;
            if (Right)
            {
                _dX = 5;
            }
            if (!Right)
            {
                _dX = -5;
            }
        }
    }
}
