using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    [RequireComponent(typeof(WheelCollider))]
    public class IP_Airplane_Wheel : MonoBehaviour
{
        #region variables

        [Header("Wheel Properties")]
        public Transform wheelGraphic;
        public bool isBraking = false;
        public float brakePower =5f;
        public bool isSteering = false;
        public float steerAngle = 20f;
        public float steerSmoothSpeed = 2f;


        public WheelCollider wheelCol;
        private Vector3 worldPos;
        private Quaternion worldRot;
        private float finalBreakForce;
        private float finalSteerAngle;
        private bool isGrounded;

        public bool IsGrounded
        {
            get { return isGrounded; }
        }
        #endregion



        #region Built in Methods
        


        // Start is called before the first frame update
        void Start()
        {
            wheelCol = GetComponent<WheelCollider>();
        }

    // Update is called once per frame
        void Update()
        {
           /* if (wheelCol.isGrounded)
            {
                Debug.Log("Grounded");
            } */
        }

        /*private void OnTriggerStay(Collider other)
        {
            if (other.tag == "ground")
            {
                isGrounded = true;
                Debug.Log("Grounded");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "ground")
            {
                isGrounded = true;
                Debug.Log("Grounded");
                Debug.Log("Collider"+ collision.collider.tag );
            }
            else
            {
                isGrounded = false;
            }
        }
        */

        

        #endregion



        #region Custom Methods
        public void InitWheel()
        {
            if (wheelCol)
            {
                wheelCol.motorTorque = 0.0000000000001f;
            }
        }
        public void HandleWheel(IP_Base_Airplane_Input input)
        {
            if (wheelCol)
            {
                wheelCol.GetWorldPose(out worldPos,out worldRot);
                if (wheelGraphic)
                {
                    wheelGraphic.rotation = worldRot;
                    wheelGraphic.position = worldPos;
                }

                if (isBraking)
                {

                    if (input.Brake > 0.1f)
                    {
                        finalBreakForce = Mathf.Lerp(finalBreakForce, input.Brake * brakePower, Time.deltaTime);
                        wheelCol.brakeTorque = input.Brake * brakePower;
                    }
                    else
                    {
                        wheelCol.brakeTorque = 0f;
                        wheelCol.motorTorque = 0.0000000000001f;
                    }
                }
                if (isSteering)
                {
                   finalSteerAngle = Mathf.Lerp(finalSteerAngle, -input.Yaw*steerAngle,Time.deltaTime*steerSmoothSpeed);
                    wheelCol.steerAngle = finalSteerAngle;
                    
                }
            }
        }

        #endregion
    }
}