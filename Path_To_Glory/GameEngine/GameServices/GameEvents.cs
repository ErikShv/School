using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace GameEngine.GameServices
{
   public class GameEvents
   {
        public Action OnRun;                            //האירוע שבזכותו העצמים נעים ינועו
        public Action<VirtualKey> OnKeyDown;            //אירוע שבזכותו העצמים יוכלו להקשיב ללחיצת המקשים
        public Action<VirtualKey> OnKeyUp;              //האירוע שבזכותו העצמים יוכלו להקשיב לעזיבת המקש
        public Action<int> OnRemoveLife ;               //האירוע שבאמצעותו נוכל למחוק לב מדף המשחק
        public Action OnScoreRefresh;                   //באמצעות  האירוע נוכל להציג את ההישג המעודכן
        public Action<int> OnUpdateTime;                //האירוע שמאפשר להציג על המסך את משך הזמן הנותר של המשחק
        public Action OnGameOver;                       //האירוע שתרחש כאשר יסתיים המשחק
        public Action<double, double> OnMousePress;     //האירוע שיתרחש כאשר ילחץ הלחצן של עכבר
    }
}
