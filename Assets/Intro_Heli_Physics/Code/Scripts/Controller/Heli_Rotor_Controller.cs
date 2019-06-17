using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Intro_Heli_Physics
{
    public class Heli_Rotor_Controller : MonoBehaviour
    {
        #region Variables
        private List<IHeliRotor> m_Rotors;
        #endregion

        #region Builtin Methods
        private void Start()
        {
            m_Rotors = GetComponentsInChildren<IHeliRotor>().ToList<IHeliRotor>();
        }
        #endregion

        #region Custom Methods
        public void UpdateRotors(Input_Controller input, float currentRPMs)
        {

            float currnetDps = (currentRPMs * 360) / 60;

            if (m_Rotors.Count > 0)
            {
                foreach (var rotor in m_Rotors)
                {
                    rotor.UpdateRotor(currnetDps,input);
                }
            }
        }
        #endregion
    }
}
