using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameObjects
{
    class MonsterA : GameMovingObject
    {
        public MonsterA(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Height = 70;
        }
        public override void Collide(GameObject gameObject)
        {
            if (gameObject is Bullet)
            {
                _scene.RemoveObject(gameObject);
            }

        }
    }
}
