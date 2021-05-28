using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine.Examples;
using Cinemachine;


namespace Qubitech
{

    


    
    public class ActionCollider : MonoBehaviour
    {


        #region variables

        public GameObject cmCam;
        public GameObject Airplane;
        public GameObject player;
        public  GameObject TextTMP;
        public GameObject wheel;
        private Transform playerTransform;
        private Transform airPlaneTransform;
        IP_Airplane_Wheel iWheel;
        IP_Base_Airplane_Input input;
        float collisionCounter=0f;
        public GameObject mainCam;
        Airplane_Camera air_cam;
        

        #endregion

        #region Built in Methods

        // Start is called before the first frame update
        void Start()
        {
            air_cam = mainCam.GetComponent<Airplane_Camera>();
            input= Airplane.GetComponent<IP_Base_Airplane_Input>();
            iWheel = wheel.GetComponent<IP_Airplane_Wheel>();
            input.enabled = false;
            air_cam.enabled = false;
            playerTransform = player.GetComponent<Transform>();
            airPlaneTransform = Airplane.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log("COl"+collisionCounter);
        }

      
        private void OnTriggerStay(Collider other)
        {
            colliderCalculation(other);
            


        }

        #endregion

        #region Custom Methods

        void enterPlane()
        {
            Debug.Log("E Pressed");

            cmCam.SetActive(false);
            
            player.SetActive(false);
            air_cam.enabled = true;

            TextTMP.SetActive(false);
            input.enabled = true;
        }
        void exitPLane()
        {

            Debug.Log("Plane Exited");
            cmCam.SetActive(true);
            player.SetActive(true);
            air_cam.enabled = false;
            
            
            input.enabled = false;
            playerTransform.position = new Vector3(airPlaneTransform.position.x+4.841f,airPlaneTransform.position.y-1.55f,airPlaneTransform.position.z - 1.815f);
            
        }

        void showUI()
        {
            TextTMP.SetActive(true);
            Debug.Log("Entered");
        }

        void colliderCalculation(Collider other)
        {
            if (other.tag == "Player")
            {
                
                showUI();
            }
            else
            {
                collisionCounter++;
                if (collisionCounter>100f) // This is fixing the weird behaviour of this text geetting disabled
                {
                    TextTMP.SetActive(false);
                    collisionCounter = 0f;
                }
            }


            if (Input.GetKeyDown(KeyCode.E) && other.tag == "Player")
            {
                enterPlane();
            }

            if (input.enabled && iWheel.wheelCol.isGrounded && Input.GetKeyDown(KeyCode.F))
            {
                exitPLane();
            }
        }


        #endregion
    }
}