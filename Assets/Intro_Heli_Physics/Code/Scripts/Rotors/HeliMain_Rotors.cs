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

        #region Properties
        private float currentRPMs;
        public float CurrentRPMs { get => currentRPMs; }
        #endregion

        #region override Methods
        public void UpdateRotor(float dps, Input_Controller input)
        {
            currentRPMs = (dps / 360) * 60f;
            transform.Rotate(Vector3.up, dps * Time.deltaTime);

            m_LRotor.transform.localRotation = Quaternion.Euler(-input.StickyCollectiveInput * m_MaxPitch, 0, 0);
            m_RRotor.transform.localRotation = Quaternion.Euler(input.StickyCollectiveInput * m_MaxPitch, 0, 0);
        }
        #endregion

    }
}
