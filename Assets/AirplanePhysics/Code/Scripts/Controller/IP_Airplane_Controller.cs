using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    public class IP_Airplane_Controller : IP_Base_Rigidbody_Controller
    {
        #region variables
        [Header("Base Airplane Properties")]
        public IP_Base_Airplane_Input input;
        [Tooltip("Airplane weight in KG")]
        public float airplaneWeight = 800f;
        public Transform centerOfGravity;

        #endregion

        #region built in methods

        public override void Start()
        {
            base.Start();

            if (rb)
            {
                rb.mass = airplaneWeight;
                if(centerOfGravity)
                {
                    rb.centerOfMass = centerOfGravity.localPosition;
                }

            }

        }



        #endregion


        #region Custom Methods

        protected override void HandlePhysics()
        {
            HandleEngine();
            HandleAeroDynamics();
            HandleSteering();
            HandleBrakes();
            HandleAltitude();
        }


        void HandleEngine()
        {

        }
        void HandleAeroDynamics()
        {

        }
        void HandleSteering()
        {

        }
        void HandleBrakes()
        {

        }

        void HandleAltitude()
        {

        }


        #endregion
    }
}