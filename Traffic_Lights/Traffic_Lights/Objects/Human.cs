using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Traffic_Lights.Objects
{
    
  public abstract  class Human
    {
        public enum HumanStateType
        {
            idle,jumping,running
        }
    public Image Image { get; private set; }
        private double _x;//מיקום האובייקט בציר אופקי
        private double _y;//מיקום האובייקט בציר אנכי
        private double _startx;//המיקום ההתחלתי של האובייקט בציר האופקי
        private double _starty;//המיקום ההתחלתי של האובייקט בציר האנכי
        protected BitmapImage _bitmapimage;
        protected HumanStateType _humanState;//המצב
        public Human (Image imagehuman)
        {
            _humanState = HumanStateType.idle;
            Image = imagehuman;
            _bitmapimage = new BitmapImage();
            Image.Source = _bitmapimage;


            MatchGifToState();
            Events.OnSetState += SetState;//בזכות השורה הזאת החיות מתחילות להקשיב לרמזור


        }
        /// <summary>
        /// הפעולה מתאימה לכל מצב העצם את הגיפ שלה
        /// </summary>
        /// 
        protected virtual void MatchGifToState()
        {
           
        }
        /// <summary>
        /// הפעולה מעבירה את מצב האדם למצב המתאים למצב הרמזור
        /// </summary>
        /// <param name="state"></param>
        public void SetState(Lights.TrafficLightsState state)
        {
            switch (state)
            {
                case Lights.TrafficLightsState.red:
                    _humanState = HumanStateType.idle;
                    break;
                case Lights.TrafficLightsState.yellow:
                    _humanState = HumanStateType.jumping;
                    break;
                case Lights.TrafficLightsState.green:
                    _humanState = HumanStateType.running;
                    break;
            }
        }
    }
}
