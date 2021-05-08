using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    public class IP_Airplane_Propeller : MonoBehaviour
    {

        #region variables
        [Header("Propeller Properties")]
        public float minRotationRPM = 30f;

        public float minQuadRPMs = 300f;
        public float minTextureSwap = 600f;
        public GameObject mainProp;
        public GameObject blurredProp;

        [Header("Material Properties")]
        public Material blurredPropMat;
        public Texture2D blurLevel1;
        public Texture2D blurLevel2;
     
        public float minDPS = 0.5f;
       // private Rigidbody rb;


        #endregion


        #region Built in Methods

        private void Start()
        {
            
            // rb = GetComponent<Rigidbody>();
            if (mainProp && blurredProp)
            {
                
                HandleSwapping(0f);
            }
            

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
            else
            {
                transform.Rotate(Vector3.forward, 1);
            }
            if (mainProp && blurredProp)
            {
                HandleSwapping(currentRPM);
            }

        }

        void HandleSwapping(float currentRPM)
        {
            if (currentRPM > minQuadRPMs)
            {
                blurredProp.gameObject.SetActive(true);
                mainProp.gameObject.SetActive(false);

                if (blurredPropMat  && blurLevel1 && blurLevel2)
                {
                    if (currentRPM > minTextureSwap)
                    {
                        blurredPropMat.SetTexture("_BaseColorMap", blurLevel2);

                    }
                    else
                    {
                        blurredPropMat.SetTexture("_BaseColorMap", blurLevel1);
                    }
                }
               

            }
            else
            {

                blurredProp.gameObject.SetActive(false);
                mainProp.gameObject.SetActive(true);
            }
        }

        

        #endregion
    }
}