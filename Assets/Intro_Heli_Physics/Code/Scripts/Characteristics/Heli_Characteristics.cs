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

        public float maxRotorTourque = 10f;

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
            HandlePedals(rb, input);
        }

        protected virtual void HandleLift(Rigidbody rb, Input_Controller input)
        {
            if(mainRotors)
            {
                float normalizedRPMs = mainRotors.CurrentRPMs / 300f;
                Vector3 liftForce = (Physics.gravity.magnitude * rb.mass + maxLiftForce) * transform.up;
                Vector3 final = liftForce * input.StickyCollectiveInput * Mathf.Pow(normalizedRPMs, 2f);
                //Debug.Log(final.ToString());
                //Debug.Log(normalizedRPMs);
                rb.AddForce(final, ForceMode.Force);
            }
        }

        protected virtual void HandleCyclic()
        {

        }

        protected virtual void HandlePedals(Rigidbody rb, Input_Controller input)
        {
            rb.AddTorque(transform.up * input.Pedal * maxRotorTourque);
        }

        #endregion
    }
}
