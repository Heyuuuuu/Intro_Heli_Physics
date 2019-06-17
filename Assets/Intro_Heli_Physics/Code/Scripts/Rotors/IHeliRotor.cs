using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    public interface IHeliRotor
    {
        void UpdateRotor(float dps,Input_Controller input);
    }
}
