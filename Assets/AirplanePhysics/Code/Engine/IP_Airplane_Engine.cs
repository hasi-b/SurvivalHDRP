using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{

    public class IP_Airplane_Engine : MonoBehaviour
    {
        #region variables
        public float maxForce = 200f;
        public float maxRPM = 2550f;

        #endregion
        #region Builtin Methods
       
        #endregion
        #region custom Methods

        public Vector3 CalculateForce(float  throttle)
        {
            float finalThrottle = Mathf.Clamp01(throttle);
            float finalPower = throttle * maxForce;

            Vector3 finalForce = transform.forward * finalPower;
            return finalForce;

        }



        #endregion
    }
}
