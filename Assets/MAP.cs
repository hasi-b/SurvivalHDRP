using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{  

public class MAP : MonoBehaviour
{

        #region Variable

        bool map_enbale=false;
        public GameObject pin;
        public GameObject mapCam;
        public GameObject mapText;
        public GameObject minimap;
        #endregion
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*    if(map_enbale && Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Only M");
                pin.SetActive(false);
                mapCam.SetActive(false);
                mapText.SetActive(false);
                mainCam.SetActive(true);
                


            }*/
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("AGAIN M");
                
                pin.SetActive(!pin.activeSelf);
                mapCam.SetActive(!mapCam.activeSelf);
                mapText.SetActive(!mapText.activeSelf);
                minimap.SetActive(!minimap.activeSelf);
               // mainCam.SetActive(!mainCam.activeSelf);
                

            }

        }
}

}