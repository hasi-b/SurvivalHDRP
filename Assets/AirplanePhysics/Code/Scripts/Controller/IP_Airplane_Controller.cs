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
        public float airplaneWeight = 544f;
        public Transform centerOfGravity;
        [Header("Airplane Engine")]
        public List <IP_Airplane_Engine> engines = new List<IP_Airplane_Engine>();
        [Header("Wheels")]
        public List<IP_Airplane_Wheel> wheels = new List<IP_Airplane_Wheel>();

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
                    rb.centerOfMass = centerOfGravity.localPosition; // assigning the center of gravity of the plane from the inspector
                }

            }

            if(wheels!= null)
            {
                if (wheels.Count > 0)
                {
                    foreach(IP_Airplane_Wheel wheel in wheels)
                    {

                    }
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
            if(engines!= null)
            {
                if (engines.Count > 0)
                {
                    foreach(IP_Airplane_Engine engine in engines)
                    {

                    }
                }
            }



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