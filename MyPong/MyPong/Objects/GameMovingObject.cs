using MyPong.GameServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyPong.Objects
{
    public abstract class GameMovingObject : GameObject
    {
        protected double _dx; //מהירות אופקית
        protected double _dy; //מהירות אנכית
        protected double _toy; //מיקום יעד אנכי  
        protected double _tox; //מיקום יעד אופקי
        protected double _ddx; //תאוצה אופקית 
        protected double _ddy; //תאוצה אנכית
        protected Canvas _scene;

        public GameMovingObject(Canvas scene, string filename, double size,
            double x, double y) : base(filename, size, x, y)
        {
            _dx = 0;  //הגוף לא ינוע בהתחלה
            _dy = 0;
            _ddx = 0;
            _ddy = 0;
            scene = _scene;
        }

        public override void Render()
        {
            _x += _dx;
            _y += _dy;
            _dx += _ddx;
            _dy += _ddy;
            if (Math.Abs(_x - _tox) < 5 && Math.Abs(_y - _toy) < 5)
            {
                _x = _tox;
                _y = _toy;
                Stop();
            }
            base.Render();
        }

        public void Stop()
        {
            _dx = _dy = _ddx = _ddy = 0;

        }
        public virtual void MoveTo(double toX, double toY, double speed = 1)
        {
            _tox = toX;
            _toy = toY;
            var len = Math.Sqrt(Math.Pow(toX - _x, 2) + Math.Pow(toY - _y, 2));
            var cos = (toX - _x) / len;
            var sin = (toY - _y) / len;

            speed *= Constants.SpeedUnit;
            _dx = speed * cos;
            _dy = speed * sin;
        }

    }
}
