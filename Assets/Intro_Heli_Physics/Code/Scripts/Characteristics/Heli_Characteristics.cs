using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Intro_Heli_Physics
{
    public class Heli_Characteristics:MonoBehaviour
    {
        #region Variables
        [Header("Lift Properties")]
        public float maxLiftForce = 100f;

        public HeliMain_Rotors mainRotors;
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
            if(mainRotors)
            {
                float normalizedRPMs = mainRotors.CurrentRPMs / 500f;
                Vector3 liftForce = (Physics.gravity.magnitude * rb.mass + maxLiftForce) * transform.up;
                //rb.AddForce(liftForce * Mathf.Pow(input.StickCollectiveInput, 2f) * Mathf.Pow(normalizedRPMs, 2f), ForceMode.Force);

                rb.AddForce(liftForce * Mathf.Pow(normalizedRPMs, 2f), ForceMode.Force);
            }
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
