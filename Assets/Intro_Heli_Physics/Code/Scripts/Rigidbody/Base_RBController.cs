using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intro_Heli_Physics
{
    [RequireComponent(typeof(Rigidbody))]
    public class Base_RBController : MonoBehaviour
    {
        #region Variables
        protected Rigidbody rb;
        public Transform m_COG;
        #endregion

        #region BuiltIn Methods
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }


        void FixedUpdate()
        {
            HandlePhysics();
        }
        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics() { }
        #endregion
    }
}