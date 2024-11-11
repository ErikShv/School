using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameObjects
{
    class Bullet : GameMovingObject
    {
        private bool _FacingRight { get; set; }
        public Bullet(Scene scene, string fileName, double placeX, double placeY,bool FacingRight) : base(scene, fileName, placeX, placeY)
        {
            
            Image.Height = 100;
            _FacingRight = FacingRight;
            if (FacingRight)
            {
                
                _dX = 8;
            }
            else
            {
                _dX = -8;
            }
        }
        public override void Collide(GameObject gameObject)
        {
            if (gameObject is MonsterA)
            {
                _scene.RemoveObject(gameObject);
            }

        }


    }
}
