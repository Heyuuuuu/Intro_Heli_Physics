using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Intro_Heli_Physics
{
    public class Heli_Characteristics:MonoBehaviour
    {
        #region Variables

        #endregion

        #region Builtin Methods

        void Start()
        {

        }

        void Update()
        {

        }

        #endregion

        #region  Custom Methods

        public void UpdateCharacteristics(Rigidbody rb, Input_Controller input)
        {
            HandleLift(rb, input);
            HandleCyclic();
            HandlePedals();
        }

        protected virtual void HandleLift(Rigidbody rb, Input_Controller input)
        {
            Vector3 liftForce = Physics.gravity.magnitude * rb.mass * transform.up;
            rb.AddForce(liftForce, ForceMode.Force);
        }

        protected virtual void HandleCyclic()
        {

        }

        protected virtual void HandlePedals()
        {

        }

        #endregion
    }
}
