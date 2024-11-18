using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    public class HeliMain_Rotors : MonoBehaviour, IHeliRotor
    {
        #region Variables
        [Header("Tail Rotor Properties")]
        public Transform m_LRotor;
        public Transform m_RRotor;
        public float m_MaxPitch = 30f;
        #endregion

        #region override Methods
        public void UpdateRotor(float dps, Input_Controller input)
        {
            transform.Rotate(Vector3.up, dps * Time.deltaTime);

            m_LRotor.transform.localRotation = Quaternion.Euler(-input.StickCollectiveInput * m_MaxPitch, 0, 0);
            m_RRotor.transform.localRotation = Quaternion.Euler(input.StickCollectiveInput * m_MaxPitch, 0, 0);
        }
        #endregion

    }
}
