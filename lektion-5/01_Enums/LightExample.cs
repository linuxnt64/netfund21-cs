using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Enums
{
    enum LightState
    {
        On,
        Off
    }

    internal class LightExample
    {
        public static LightState lightState = LightState.Off;

        public static void TurnOn()
        {
            lightState = LightState.On;
        }

        public static void TurnOff()
        {
            lightState = LightState.Off;
        }
    }
}
