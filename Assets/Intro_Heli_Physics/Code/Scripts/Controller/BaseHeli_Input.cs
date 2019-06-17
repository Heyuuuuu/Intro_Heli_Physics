using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Intro_Heli_Physics
{
    public class BaseHeli_Input : MonoBehaviour
    {
        #region Variables
        protected float m_Vertical = 0f;
        protected float m_Horizontal = 0f;
        #endregion

        #region Builtin Methods
        void Update()
        {
            HandleInput();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleInput()
        {
            m_Vertical = UnityEngine.Input.GetAxis("Vertical");
            m_Horizontal = UnityEngine.Input.GetAxis("Horizontal");
        }
        #endregion
    }
}
