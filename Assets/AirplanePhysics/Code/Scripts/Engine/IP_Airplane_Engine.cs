using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Qubitech
{

    public class IP_Airplane_Engine : MonoBehaviour
    {
        #region variables
        [Header("Engine Properties")]
        public float maxForce = 10000f;
        public float maxRPM = 2550f;
        public IP_Airplane_Controller airPlaneController;
        public AnimationCurve powerCurve = AnimationCurve.Linear(0f,0f,1f,1f);
        [Header("Propeller")]
        public IP_Airplane_Propeller propeller;
        

        #endregion
        #region Builtin Methods

        #endregion
        #region custom Methods

        public Vector3 CalculateForce(float  throttle)
        {
            //calculating power
            float finalThrottle = Mathf.Clamp01(throttle);

            finalThrottle = powerCurve.Evaluate(finalThrottle);
            //calculating RPM of the propeller
            
                float currentRPM = airPlaneController.maxxforce * maxRPM;
            
            if (propeller)
            {
                propeller.HandlePropeller(currentRPM);
            }
            //calculating force and creating
            float finalPower = throttle * maxForce;

            Vector3 finalForce = transform.forward * finalPower;
            return finalForce;

        }



        #endregion
    }
}
