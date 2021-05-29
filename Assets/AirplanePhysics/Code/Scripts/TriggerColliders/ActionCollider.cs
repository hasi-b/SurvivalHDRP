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
        float airplane_X,airplane_Y,airplane_Z;
        bool Entered;
        bool inPLane;
        

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
            airplane_X = airPlaneTransform.position.x + 4.841f;
            airplane_Y = airPlaneTransform.position.y - 1.55f;
            airplane_Z = airPlaneTransform.position.z - 1.815f;

            if (Entered)
            {
                if (Input.GetKeyDown(KeyCode.F) && !inPLane)
                {
                    
                    enterPlane();
                    inPLane = true;
                }

                else if (input.enabled && iWheel.wheelCol.isGrounded && inPLane && Input.GetKeyDown(KeyCode.F))
                {
                    exitPLane();
                    inPLane = false;
                }


            }





        }

      
       
        private void OnTriggerEnter(Collider other)
        {
            colliderCalculation(other, true);
        }
        private void OnTriggerExit(Collider other)
        {
            colliderCalculation(other, false);
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
            playerTransform.position = new Vector3(airplane_X, airplane_Y, airplane_Z);
            player.SetActive(true);
            air_cam.enabled = false;
            
            
            input.enabled = false;
            
            
        }

        void showUI()
        {
            TextTMP.SetActive(true);
            Debug.Log("Entered");
        }

        void colliderCalculation(Collider other, bool enter)
        {
            if (other.tag == "Player" && enter == true)
            {
                
                showUI();
                Entered = true;
               

            }
            else if(other.tag == "Player" && enter == false)
            {
                
                
                    TextTMP.SetActive(false);
                Entered = false;
                    
            }


           

            
        }


        #endregion
    }
}