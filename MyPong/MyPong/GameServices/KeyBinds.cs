using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace MyPong.GameServices
{
    public static class KeyBinds
    {
        public static VirtualKey LeftPlayerUp { get; set; } = VirtualKey.W;
        public static VirtualKey LeftPlayerDown { get; set; } = VirtualKey.S;
        public static VirtualKey RightPlayerUp { get; set; } = VirtualKey.Up;
        public static VirtualKey RightPlayerDown { get; set; } = VirtualKey.Down;

    }
}
