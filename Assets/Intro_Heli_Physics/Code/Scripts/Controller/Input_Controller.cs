using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    public enum InputType
    {
        Keyboard,
        Xbox,
        Mobile
    }

    [RequireComponent(typeof(KeyboardHeli_Input), typeof(XboxHeli_Input))]
    public class Input_Controller : MonoBehaviour
    {
        #region Variables

        public InputType inputType = InputType.Keyboard;   
        
        KeyboardHeli_Input m_KeyboardInput;
        XboxHeli_Input m_XboxInput;

        #endregion


        #region Properties
        private float m_Throttle;
        private float m_Collective;
        private Vector2 m_Cyclic;
        private float m_Pedal;
        private float m_StickyThrottle;
        private float m_StickCollectiveInput;

        public float Throttle { get => m_Throttle;}
        public float Collective { get => m_Collective;}
        public Vector2 Cyclic { get => m_Cyclic;}
        public float Pedal { get => m_Pedal;}
        public float StickyThrottle { get => m_StickyThrottle; }
        public float StickyCollectiveInput { get => m_StickCollectiveInput; }


        #endregion

        #region Builtin Methods
        void Start()
        {
            m_KeyboardInput = GetComponent<KeyboardHeli_Input>();
            m_XboxInput = GetComponent<XboxHeli_Input>();
            SetInputType();
        }

        void Update()
        {
            if (m_XboxInput & m_KeyboardInput)
            {
                switch (inputType)
                {
                    case InputType.Keyboard:
                        m_Throttle = m_KeyboardInput.RawThrottleInput;
                        m_Collective = m_KeyboardInput.CollectiveInput;
                        m_Cyclic = m_KeyboardInput.CyclicInput;
                        m_Pedal = m_KeyboardInput.PedalInput;
                        m_StickyThrottle = m_KeyboardInput.StickThrottle;
                        m_StickCollectiveInput = m_KeyboardInput.StickCollectiveInput;
                        break;

                    case InputType.Xbox:
                        m_Throttle = m_XboxInput.RawThrottleInput;
                        m_Collective = m_XboxInput.CollectiveInput;
                        m_Cyclic = m_XboxInput.CyclicInput;
                        m_Pedal = m_XboxInput.PedalInput;
                        m_StickyThrottle = m_XboxInput.StickThrottle;
                        m_StickCollectiveInput = m_XboxInput.StickCollectiveInput;
                       
                        break;
                }
            }
        }

        #endregion

        #region Custom Methods
        private void SetInputType()
        {
            if (inputType == InputType.Keyboard)
            {
                m_KeyboardInput.enabled = true;
                m_XboxInput.enabled = false;
            }

            if (inputType == InputType.Xbox)
            {
                m_KeyboardInput.enabled = false;
                m_XboxInput.enabled = true;
            }
        }

        private void AutoBalanceCollective()
        {

        }
        #endregion
    }
}
