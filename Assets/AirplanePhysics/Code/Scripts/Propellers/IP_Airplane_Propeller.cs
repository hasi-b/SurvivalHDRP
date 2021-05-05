using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    public class IP_Airplane_Propeller : MonoBehaviour
    {

        #region variables
        public float minDPS = 0.5f;
       // private Rigidbody rb;


        #endregion


        #region Built in Methods

        private void Start()
        {
           // rb = GetComponent<Rigidbody>();
        }
        #endregion

        #region Custom Methods

        public void HandlePropeller(float currentRPM)
        {
            
              float DPS = (currentRPM * 360f) / 60f * Time.deltaTime;
            //Debug.Log("DPS " + DPS);
            //Vector3 finalDPS = Vector3.forward * DPS;
            //rb.AddTorque(finalDPS);
            if (DPS > minDPS)
            {
                transform.Rotate(Vector3.forward, DPS);
            }
        }

        #endregion
    }
}