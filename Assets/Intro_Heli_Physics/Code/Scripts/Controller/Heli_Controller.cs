using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    [RequireComponent(typeof(Input_Controller))]
    public class Heli_Controller : Base_RBController
    {
        #region Variables
        [Header("Helicopter Properties")]
        public float m_weight = 10f;

        public List<Heli_Engine> m_Engines = new List<Heli_Engine>();
        [Header("Helicopter Rotors Controller")]
        public Heli_Rotor_Controller m_RotorController;
        private Input_Controller m_Input;
        private Heli_Characteristics m_characteristics;
        #endregion

        #region BuiltIn Methods
        private void Start()
        {
            m_Input = GetComponent<Input_Controller>();
            rb.mass = m_weight;
            m_characteristics = GetComponent<Heli_Characteristics>();
        }
        #endregion

        #region Custom Method
        protected override void HandlePhysics()
        {
            if (m_Input)
            {
                HandleEngine();
                HandleRotors();
                HandleCharacteristics();
            }
        }

        protected virtual void HandleCharacteristics()
        {
            m_characteristics.UpdateCharacteristics(rb, m_Input);
        }

        protected virtual void HandleEngine()
        {
            foreach(Heli_Engine engine in m_Engines)
            {
                engine.UpdateEngine(m_Input.StickyThrottle);
            }
        }

        protected virtual void HandleRotors()
        {
            if (m_RotorController && m_Engines.Count > 0)
            {
                m_RotorController.UpdateRotors(m_Input, m_Engines[0].CurrentRPM);
            }
        }

        #endregion
    }
}