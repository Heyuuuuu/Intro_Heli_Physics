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

        [Space]
        [Header("Tail Rotor Properties")]
        public float tailForce = 2f;

        [Space]
        [Header("Cyclic Properties")]
        public float cyclicForce = 2f;

        [Header("Auto Level Properties")]
        public float autoLevelForce = 2f;

        private Vector3 flatFwd;
        private Vector3 flatRight;

        private float forwardDot;
        private float rightDot;

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
            HandleCyclic(rb, input);
            HandlePedals(rb, input);

            CalculateAngles();

            AutoLevel(rb);
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

        protected virtual void HandleCyclic(Rigidbody rb, Input_Controller input)
        {

            float finalCylicForceX = input.Cyclic.x * cyclicForce;
            rb.AddRelativeTorque(Vector3.forward * finalCylicForceX, ForceMode.Acceleration);

            float finalCylicForceY = input.Cyclic.y * cyclicForce;
            rb.AddRelativeTorque(Vector3.right * finalCylicForceY, ForceMode.Acceleration);
        }

        protected virtual void HandlePedals(Rigidbody rb, Input_Controller input)
        {
            rb.AddTorque(transform.up * input.Pedal * tailForce, ForceMode.Acceleration);
        }

        protected void CalculateAngles()
        {
            flatFwd = transform.forward;
            flatFwd.y = 0;
            flatFwd.Normalize();

            Debug.DrawRay(transform.position, flatFwd, Color.blue);

            flatRight = transform.right;
            flatRight.y = 0;
            flatRight.Normalize();

            Debug.DrawRay(transform.position, flatRight, Color.red);

            forwardDot = Vector3.Dot(transform.up, flatFwd);
            rightDot = Vector3.Dot(transform.up, flatRight);

           // Debug.Log($"===rightDot:{forwardDot} , rightDot:{rightDot}");
        }

        protected void AutoLevel(Rigidbody rb)
        {
            float rightForce = - forwardDot * autoLevelForce;
            float forwardForce = rightDot * autoLevelForce;

            rb.AddRelativeTorque(Vector3.forward * forwardForce, ForceMode.Acceleration);
            rb.AddRelativeTorque(Vector3.right * rightForce, ForceMode.Acceleration);
        }

        #endregion
    }
}
