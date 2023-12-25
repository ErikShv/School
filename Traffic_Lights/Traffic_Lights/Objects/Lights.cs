using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Traffic_Lights.Objects
{
    public class Lights
    {
        public enum TrafficLightsState   //המצאתי סוג חדש של משתנה המגדיר את מצבי הרמזור
        {
            red, yellow, green
        }



        private Ellipse _lightRed;
        private Ellipse _lightGreen;
        private Ellipse _lightYellow;
        private bool _isAuto;         //האם הרמזור נמצא במצב אוטומטי

        private TrafficLightsState _state; //הרמזור יווצר במצב אדום


        private DispatcherTimer _timer;//המשתנה יאפשר לקיים לולאה המתבצעת בקצב שיקבע
        public bool IsAuto
        {
            get
            {
                return _isAuto;
            }
            set
            {
                _isAuto = value;
                if (_isAuto)
                {
                    _timer.Start();

                }
                else
                {
                    _timer.Stop();
                }
                
            }
        }

        /// <summary>
        /// הפעולה בונה עצם רמזור
        /// </summary>
        /// <param name="red">עיגול אדום</param>
        /// <param name="green">עיגול ירוק</param>
        /// <param name="yellow">עיגול צהוב</param>

        public Lights(Ellipse red, Ellipse green, Ellipse yellow)
        {
            _lightRed = red;
            _lightGreen = green;
            _lightYellow = yellow;
            _isAuto = false;
            _state = TrafficLightsState.red;

            _timer = new DispatcherTimer();//כך בונים טיימר
            _timer.Interval = TimeSpan.FromSeconds(2);//כך קובעים את תדירות עבודת הטיימר
            _timer.Stop();//הטיימר לא יעבוד כאשר יווצר
            _timer.Tick += _timer_Tick;
        }

        private void _timer_Tick(object sender, object e)//הפעולה תתבצע באופן אוטומטי כל 2 שניות
        {                                                //בתנאי שהטיימר מופעל
            SetState();
        }


        /// <summary>
        /// הפעולה מעבירה את הרמזור ממצב הנוכחי למצב הבא באופן מעגלי
        /// </summary>
        public void SetState()
        {
            switch (_state)
            {
                case TrafficLightsState.red:                                 //אם הרמזור היה במצב אדום,אז 
                    _state = TrafficLightsState.yellow;                          //עבור למצב צהוב
                    _lightRed.Fill = new SolidColorBrush(Colors.LightGray);  //תכבה אור אדום
                    _lightYellow.Fill = new SolidColorBrush(Colors.Yellow);  //תדליק את האור הצהוב
                    break;
                case TrafficLightsState.yellow:                                 //אם הרמזור היה במצב צהוב,אז 
                    _state = TrafficLightsState.green;                          //עבור למצב ירוק
                    _lightYellow.Fill = new SolidColorBrush(Colors.LightGray);  //תכבה אור צהוב
                    _lightGreen.Fill = new SolidColorBrush(Colors.Green);  //תדליק את האור הירוק
                    break;
                case TrafficLightsState.green:                                 //אם הרמזור היה במצב ירוק,אז 
                    _state = TrafficLightsState.red;                          //עבור למצב אדום
                    _lightGreen.Fill = new SolidColorBrush(Colors.LightGray);  //תכבה אור ירוק
                    _lightRed.Fill = new SolidColorBrush(Colors.Red);  //תדליק את האור האדום
                    break;
            }
            if (Events.OnSetState!= null)
            {
                Events.OnSetState(_state);//כך הרמזור מפעיל את האירוע בכל פעם שהרמזור מחיף את האור
            }
        }


    }
}

