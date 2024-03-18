using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace MyPong.GameServices
{
    public class Events
    {
        public Action OnRun; //אירוע שיתרחש ללא הרף. עצם שירשם אליו יוכל לנוע
        public Action<VirtualKey> OnKeyPress;//אירוע שיתרחש כאשר נלחץ על המקש
        public Action<VirtualKey> OnKeyRelease;//אירוע שיתרחש כאשר נעזוב את המקש
    }
}
