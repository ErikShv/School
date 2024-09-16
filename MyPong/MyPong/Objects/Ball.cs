using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyPong.Objects
{
    public class Ball : GameMovingObject
    {
        public Ball(Canvas scene, string filename, double size, double x, double y) : base(scene, filename, size, x, y)
        {
            image.Width = 50;
            image.Height = size;
            _dy = 5;
            _dx = -7;
        }
        public override void Render()
        {
            //גבולות
            if (_y <= 0)//נגיעה בתיקרה
            {
                _y = 1;
                _dy = -_dy;
            }
            if (_y + image.Height > _scene?.ActualHeight)
            {
                _y = _scene.ActualHeight - image.Height;
                _dy = -_dy;
            }
            if (_x <= 0)//נגיעה בקיר
            {
                _x = 1;
                _dx = -_dx;
            }
            if (_x + image.Width > _scene?.ActualWidth)
            {
                _x = _scene.ActualWidth - image.Width;
                _dx = -_dx;
            }
           

            base.Render();
        }
        public override void Collide(GameObject gameobject)
        {
            if(gameobject is Bat)
            {
                
                _dx = -_dx;
            }
            base.Collide(gameobject);
        }
    }
}

