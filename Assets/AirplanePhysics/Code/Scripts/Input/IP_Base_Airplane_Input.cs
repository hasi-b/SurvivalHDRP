using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Qubitech
{

    public class IP_Base_Airplane_Input : MonoBehaviour
    {
        #region variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;
        protected float throttle = 0f;
        protected int flap = 0;
        protected int maxFlapIncrement =2;
        public KeyCode brakeKey = KeyCode.Space;
        protected float brake = 0f;
        #endregion



        #region properties

        public float Pitch
        {
            get{return pitch;}
        }
        public float Roll
        {
            get { return roll; }
        }
        public float Yaw
        {
            get { return yaw; }
        }
        public float Throttle
        {
            get { return throttle; }
        }
        public float Brake
        {
            get { return brake; }
        }
        public int Flap
        {
            get { return flap; }
        }




        #endregion







        #region builtin methods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }
        #endregion


        #region customMethods

        void HandleInput()
        {
            //process main control input
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");

            //process break input
            brake = Input.GetKey(brakeKey)? 1f:0f;
            //Proces flap input
            if(Input.GetKeyDown(KeyCode.Q))
            {
                flap += 1;
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                flap -= 1;
            }

            flap = Mathf.Clamp(flap, 0, maxFlapIncrement);
        }

        #endregion



    }

}
