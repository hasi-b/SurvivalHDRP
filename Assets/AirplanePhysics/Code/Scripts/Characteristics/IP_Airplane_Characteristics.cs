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


        [Header("Control Properties")]
        public float pitchSpeed = 4000f;
        public float rollSpeed = 4000f;
        public float YawSpeed = 1000f;
        public float rbLerpSpeed = 0.2f;


        private IP_Base_Airplane_Input input;
        private Rigidbody rb;
        private float startDrag;
        private float startAngularDrag;

        public float maxliftPower;
        private float maxMPS;
        private float normalizeKMPH;

        private float angleOfAttack;
        private float pitchAngle;
        private float rollAngle;


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
        public void IniCharacteristics(Rigidbody curRb, IP_Base_Airplane_Input curInput)
        {
            input = curInput;

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
                HandlePitch();
                HandleRoll();
                HandleYaw();
                HandleBanking();

                HandleRigidbodyTransform();
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

            angleOfAttack = Vector3.Dot(rb.velocity.normalized,transform.forward);
            angleOfAttack += angleOfAttack;



            Vector3 liftDir = transform.up;
            float liftPower = liftCurve.Evaluate(normalizeKMPH) * maxliftPower;


            Vector3 finalLift = liftDir * liftPower*angleOfAttack;
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

        void HandleRigidbodyTransform()
        {
            if (rb.velocity.magnitude > 1f)
            {
                Vector3 updatedVelocity = Vector3.Lerp(rb.velocity,transform.forward*forwardSpeed,forwardSpeed*angleOfAttack*Time.deltaTime*rbLerpSpeed);
                rb.velocity = updatedVelocity;

                Quaternion updatedRotation = Quaternion.Slerp(rb.rotation,Quaternion.LookRotation(rb.velocity.normalized,transform.up),Time.deltaTime*rbLerpSpeed);
                rb.MoveRotation(updatedRotation);

            }


        }

        void HandlePitch()
        {
            Vector3 flatForward = transform.forward;
            flatForward.y = 0f;
            flatForward = flatForward.normalized;
            pitchAngle = Vector3.Angle(transform.forward, flatForward);
            // Debug.Log("PitchAngel = " +pitchAngle);

            Vector3 pitchTorque = input.Pitch * pitchSpeed * transform.right;

            rb.AddTorque(pitchTorque);


        }

        void HandleRoll()
        {
            Vector3 flatRight = transform.right;
            flatRight.y = 0f;
            flatRight = flatRight.normalized;
            rollAngle = Vector3.SignedAngle(transform.right, flatRight, transform.forward);

            Vector3 rollTorque = -input.Roll * rollSpeed * transform.forward;
            rb.AddTorque(rollTorque);

        }

        void HandleYaw()
        {
            Vector3 yawTorque = input.Yaw * YawSpeed * transform.up;
            rb.AddTorque(yawTorque);
        }


        void HandleBanking()
        {
            float bankSide = Mathf.InverseLerp(-90f,90f, rollAngle);
            float bankAmount = Mathf.Lerp(-1f, 1f, bankSide);
            Vector3 bankTorque = bankAmount * rollSpeed * transform.up;
            rb.AddTorque(bankTorque);
        }

        #endregion
    }

}