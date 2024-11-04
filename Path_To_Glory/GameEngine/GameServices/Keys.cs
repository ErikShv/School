using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace GameEngine.GameServices
{
   public class Keys
    {
        public static VirtualKey Leftkey { get; set; } = VirtualKey.Left;
        public static VirtualKey Rightkey { get; set; } = VirtualKey.Right;
        public static VirtualKey Upkey { get; set; } = VirtualKey.Up;
        public static VirtualKey Downkey { get; set; } = VirtualKey.Down;
        
    }
}
