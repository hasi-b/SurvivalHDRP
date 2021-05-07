using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    public class IP_Airplane_Characteristics : MonoBehaviour
    {
        #region variables
        [Header("Characteristics Properties")]
        public float forwardSpeed;
        public float Kmph;
        public float maxKMPH = 200f;

        public AnimationCurve liftCurve = AnimationCurve.EaseInOut(0f,0f,1f,1f);

        [Header("Drag Characteristics")]
        float dragfactor = 0.01f;

        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;

        public float maxliftPower;
        private float maxMPS;
        private float normalizeKMPH;

        #endregion
        #region Constants
        public float mpsToMph = 2.23694f;
        #endregion

        #region Built in Method 
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion
        #region Custom Method
        public void IniCharacteristics(Rigidbody curRb)
        {
            rb = curRb;
            startDrag = rb.drag;
            startAngularDrag = rb.angularDrag;

            maxMPS = maxKMPH / 0.27778f;
        }
        public void UpdateCharacteristics()
        {

            if (rb)
            {

                CalculateForwardSpeed();
                CalculateDrag();
                CalculateLift();
            }
        }




        void CalculateForwardSpeed()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
            forwardSpeed =Mathf.Max(0f,localVelocity.z);
            forwardSpeed = Mathf.Clamp(forwardSpeed,0f,maxMPS);
            Kmph = forwardSpeed * mpsToMph;
            Kmph = Mathf.Clamp(Kmph, 0f, maxKMPH);
            normalizeKMPH = Mathf.InverseLerp(0f,maxKMPH,Kmph);
        }
        void CalculateLift()
        {
            Vector3 liftDir = transform.up;
            float liftPower = liftCurve.Evaluate(normalizeKMPH) * maxliftPower;


            Vector3 finalLift = liftDir * liftPower;
            rb.AddForce(finalLift);
        }
        void CalculateDrag()
        {
            float speedDrag = forwardSpeed * dragfactor;
            float finalDrag = speedDrag + startDrag;
            float finalAngularDrag = speedDrag + startAngularDrag;
            rb.drag = finalDrag;
            rb.angularDrag = finalAngularDrag;

        }


        #endregion
    }

}