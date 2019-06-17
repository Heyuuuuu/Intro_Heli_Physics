using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    public class HeliTail_Rotors : MonoBehaviour, IHeliRotor
    {
        #region Variables
        [Header("Tail Rotor Properties")]
        public float m_RotorSpeedModifier = 1.5f;
        public Transform m_LRotor;
        public Transform m_RRotor;
        public float m_MaxPitch = 30f;
        #endregion

        #region Override Methods
        public void UpdateRotor(float dps, Input_Controller input)
        {
            transform.Rotate(Vector3.right, dps * m_RotorSpeedModifier * Time.deltaTime);

            m_LRotor.transform.localRotation = Quaternion.Euler(0, input.Pedal * m_MaxPitch, 0);
            m_RRotor.transform.localRotation = Quaternion.Euler(0, -input.Pedal * m_MaxPitch, 0);
        }
        #endregion

    }
}
