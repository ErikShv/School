using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameServices
{
    public class MyGameEvents
    {
        //כל האירועים שיש במשחק שהם מיוחדים למשחק הזה
        public Action OnNextRoom;  //פעולה העוברת לחדר הבא במשחק
        public Action<int> CheckHp; //פעולה הבודקת בכל תחילת חדר כמה חיים יש לשחקן
        public Action<int> CheckCoins; //בודקת כמה מטבעות יש לשחקן בכל תחילת חדר חדש
        public Action OnWinGame;  //פעולה שקורה כאשר השחקן מנצח
    }
}
