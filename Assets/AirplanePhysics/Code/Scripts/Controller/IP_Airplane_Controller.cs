using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    [RequireComponent(typeof(IP_Airplane_Characteristics))]
    public class IP_Airplane_Controller : IP_Base_Rigidbody_Controller
    {
        #region variables
        [Header("Base Airplane Properties")]
        public IP_Base_Airplane_Input input;
        public IP_Airplane_Characteristics characteristics;
        [Tooltip("Airplane weight in KG")]
        public float airplaneWeight = 544f;
        public float maxxforce;
        
        public Transform centerOfGravity;
        [Header("Airplane Engine")]
        public List <IP_Airplane_Engine> engines = new List<IP_Airplane_Engine>();
        [Header("Wheels")]
        public List<IP_Airplane_Wheel> wheels = new List<IP_Airplane_Wheel>();

        [Header("Control Surfaces")]
        public List<Airplane_Control_Surffaces> control_Surffaces = new List<Airplane_Control_Surffaces>();
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
                characteristics = GetComponent<IP_Airplane_Characteristics>();
                if (characteristics)
                {
                    characteristics.IniCharacteristics(rb,input);
                }
            }

            if(wheels!= null)
            {
                if (wheels.Count > 0)
                {
                    foreach(IP_Airplane_Wheel wheel in wheels)
                    {
                        wheel.InitWheel();  
                    }
                }
            }
           

        }



        #endregion


        #region Custom Methods

        protected override void HandlePhysics()
        {
            if (input)
            {
                HandleEngine();
                HandleCharacteristics();
                HandleControlSurfaces();
                HandleWheels();
                HandleAltitude();
            }
        }


        void HandleEngine()
        {
            if(engines!= null)
            {
                if (engines.Count > 0)
                {
                    foreach(IP_Airplane_Engine engine in engines)
                    {
                        
                        
                            rb.AddForce(engine.CalculateForce(input.Throttle));
                        
                        maxxforce = rb.velocity.magnitude / 14.853f;
                    }
                }
            }



        }
        void HandleCharacteristics()
        {
            if (characteristics)
            {
                characteristics.UpdateCharacteristics();
            }
        }


        void HandleControlSurfaces()
        {
            if (control_Surffaces.Count > 0)
            {
                foreach (Airplane_Control_Surffaces controlSurfaces in control_Surffaces)
                {
                    controlSurfaces.HandleControlSurface(input);
                }
            }
        }

        void HandleWheels()
        {
            if (wheels.Count > 0)
            {
                foreach(IP_Airplane_Wheel wheel in wheels)
                {
                    wheel.HandleWheel(input);
                }
            }
        }

        void HandleAltitude()
        {

        }



        #endregion
    }
}