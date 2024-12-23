using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_To_Glory.GameServices
{
    public class MyGameEvents
    {
        public Action OnNextRoom;
        public Action<int> CheckHp;
        public Action<int> CheckCoins;
    }
}
