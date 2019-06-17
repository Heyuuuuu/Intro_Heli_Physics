using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    public class KeyboardHeli_Input : BaseHeli_Input
    {
        #region Properties
        protected float rawThrottleInput = 0f;
        protected float stickyThrottle = 0f;
        protected float collectiveInput = 0f;
        protected Vector2 cyclicInput = Vector2.zero;
        protected float pedalInput = 0f;

        public float RawThrottleInput { get => rawThrottleInput; }
        public float StickThrottle { get => stickyThrottle; }
        public float CollectiveInput { get => collectiveInput; }
        public Vector2 CyclicInput { get => cyclicInput; }
        public float PedalInput { get => pedalInput; }
        #endregion

        #region Custom Method
        protected override void HandleInput()
        {
            HandleThrottle();
            HandleCollective();
            HandleCyclic();
            HandlePedal();

            ClampInput();
            HandleStickyThrottle();
        }

        protected virtual void HandleThrottle()
        {
            rawThrottleInput = Input.GetAxis("Throttle");
        }

        protected virtual void HandleCollective()
        {
            collectiveInput = Input.GetAxis("Collective");
        }

        protected virtual void HandleCyclic()
        {
            base.HandleInput();
            cyclicInput.x = m_Horizontal;
            cyclicInput.y = m_Vertical;
        }

        protected virtual void HandlePedal()
        {
            pedalInput = Input.GetAxis("Pedal");
        }

        protected void ClampInput()
        {
            Mathf.Clamp(rawThrottleInput, -1, 1);
            Mathf.Clamp(collectiveInput, -1, 1);
            Vector2.ClampMagnitude(cyclicInput, 1);
            Mathf.Clamp(pedalInput, -1, 1);
        }

        protected void HandleStickyThrottle()
        {
            stickyThrottle += rawThrottleInput * Time.deltaTime;
            stickyThrottle = Mathf.Clamp01(stickyThrottle);
        }
        #endregion
    }
}
