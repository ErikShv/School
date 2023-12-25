using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_Lights
{
   public static class Events
    {
        public static Action<Traffic_Lights.Objects.Lights.TrafficLightsState> OnSetState;

    }
}
