using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MyPong.Objects
{
    public abstract class Bat : GameMovingObject
    {
        public Bat(Canvas scene,string filename, double height, double x, double y) : base(scene,filename, height, x, y)
        {
            image.Width = 20;
            image.Height = height;

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
