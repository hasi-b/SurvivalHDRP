using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    [RequireComponent(typeof(WheelCollider))]
    public class IP_Airplane_Wheel : MonoBehaviour
{
        #region variables
        private WheelCollider wheelCol;

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
        
        }
        #endregion



        #region Custom Methods
        public void InitWheel()
        {
            if (wheelCol)
            {
                wheelCol.motorTorque = 0.0000000000001f;
            }
        }


        #endregion
    }
}