using GameEngine.GameObjects;
using GameEngine.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Path_To_Glory.GameObjects
{
    class MonsterA : GameMovingObject
    {
        public MonsterA(Scene scene, string fileName, double placeX, double placeY) : base(scene, fileName, placeX, placeY)
        {
            Image.Height = 70;
            _ddY = 1;
        }
        public override void Collide(List <GameObject> gameObject)
        {
            foreach (var otherobject in gameObject)
            {
                if (otherobject is Bullet)
                {
                    _scene.RemoveObject(otherobject);
                }

                if (otherobject is Ground)
                {

                    _dY = 0;
                    _Y -= 1;
                }
                if (otherobject is Platform platform)
                {
                    var rect = RectHelper.Intersect(Rect, platform.Rect);
                    if (rect.Width <= rect.Height) //מהצד
                    {
                        if (_dX < 0)
                        {
                            _dX = 0;
                            _X += 2;
                        }
                        if (_dX > 0)
                        {

                            _dX = 0;
                            _X -= 2;
                        }
                    }
                    if (rect.Width > rect.Height)  //מלמעלה או מלמטה
                    {

                        if (_dY > 0)    //מלמעלה
                        {

                            _dY = 0;
                            _Y -= 1;

                        }
                        else          //מלמטה
                        {
                            _dY = -_dY;
                        }
                    }
                }
            }
        }
    }
}
