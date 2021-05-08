using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{

    

    public class Airplane_Camera : IP_Basic_Follow_Camera
    {
        #region Variable
        [Header("Airplane Camera Property")]
        public float minHeightFfromGround = 2f;
        #endregion


        protected override void HandleCamera()
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,Vector3.down,out hit))
            {
                if(hit.distance< minHeightFfromGround && hit.transform.tag == "ground")
                {
                    float wantedHeight = origHeight + (minHeightFfromGround -hit.distance);
                    height = wantedHeight;
                }
            }

            base.HandleCamera();

        }
    }
}