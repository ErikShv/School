using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Traffic_Lights.Objects
{
    public class Boy : Human
    {
        public Boy(Image imagehuman) : base(imagehuman)
        {
          
        }
        protected override void MatchGifToState()
        {
            switch (_humanState)
            {
                case HumanStateType.idle:
                    _bitmapimage.UriSource = new Uri("ms-appx:///Assets/Boy/boy_idle_right.gif");
                    break;
                case HumanStateType.jumping:
                    _bitmapimage.UriSource = new Uri("ms-appx:///Assets/Boy/boy_ready_right.gif");
                    break;
                case HumanStateType.running:
                    _bitmapimage.UriSource = new Uri("ms-appx:///Assets/Boy/boy_run_right.gif");
                    break;
            }
        }
    }
}
