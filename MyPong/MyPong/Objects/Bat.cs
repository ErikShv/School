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
    public abstract class Bat : GameMovingObject
    {
        public Bat(Canvas scene,string filename, double height, double x, double y) : base(scene,filename, height, x, y)
        {
            image.Width = 20;
            image.Height = height;
            Manager.Events.OnKeyPress += MoveBat;
            Manager.Events.OnKeyRelease += StopBat;
        }
        //הפעולה תישאר ריקה אנו נשכתב אותה במחלקות היורשות מפני שכל מחבט צריך להגיב למקשים שונים
        protected virtual void StopBat(VirtualKey key)
        {
            
        }
        //הפעולה תישאר ריקה אנו נשכתב אותה במחלקות היורשות מפני שכל מחבט צריך להגיב למקשים שונים
        protected virtual void MoveBat(VirtualKey key)
        {
        }

        public override void Render()
        {
            //גבולות
            if (_y <= 0)//נגיעה בתיקרה
            {
                _y = 1;
                
            }
           if(_y + image.Height > _scene?.ActualHeight)
            {
                _y = _scene.ActualHeight - image.Height;
                
            }

            base.Render();
        }
    }
}
