using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Qubitech
{

    


    public class ThirdPersonPlayerController : MonoBehaviour
    {
        #region Variables
        CharacterController controller;
        public float speed=2f;
        public float SprintSpeed = 5f;
        public Camera camera;
        public float AnimationBlendSpeed = 6f;
        float mDesiredRotation = 0f;
        float mDeesiredAnimatinSpeed = 0f;
        public float RotationSpeed = 15f;
        Animator anim;
        float mspeedY = 0f;
        float mGravity = -1f;
        bool mjumping = false;
        public float jumpSpeed = 0.05f;


        #endregion

        #region Builtin Method
        // Start is called before the first frame update
        void Start()
        {
            controller = GetComponent<CharacterController>();
            anim = GetComponent<Animator>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            characterInput();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //mjumping = true;
                //anim.SetTrigger("Jump");
                Debug.Log("Jump pressed");
                mspeedY += jumpSpeed * 0.2f;


            }
        }

        #endregion

        #region Custom Method

        public void characterInput()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            

            if (!controller.isGrounded)
            {
                mspeedY += mGravity * Time.deltaTime;
               

            }
            else //if
            {
                
                mspeedY = 0f;
            }
           /* anim.SetFloat("SpeedY",mspeedY/ jumpSpeed);
            if(mjumping && mspeedY < 0)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position,Vector3.down,out hit, .5f, LayerMask.GetMask("Default")))
                {
                    mjumping = false;
                    anim.SetTrigger("Land");
                }
            }*/


            Vector3 movement = new Vector3(x, 0f, z).normalized;
            Vector3 rotatedMovement = Quaternion.Euler(0,camera.transform.rotation.eulerAngles.y,0) * movement;
            Vector3 verticalMovement = Vector3.up*mspeedY;
            
            if (Input.GetKey(KeyCode.LeftShift))
            {
                mDeesiredAnimatinSpeed = 1f;
                Debug.Log("Shiiiiift");
                controller.Move(verticalMovement + (rotatedMovement * SprintSpeed * Time.deltaTime));
               // controller.Move(rotatedMovement * SprintSpeed * Time.deltaTime);
            }
            else
            {
                mDeesiredAnimatinSpeed = 0.5f;
                 controller.Move(verticalMovement+ (rotatedMovement * speed * Time.deltaTime));
               // controller.Move(rotatedMovement * speed * Time.deltaTime);
            }
            if (rotatedMovement.magnitude > 0)
            {

                mDesiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                

                
                
            }
            else
            {
                mDeesiredAnimatinSpeed = 0f;
                
            }
            anim.SetFloat("Speed", Mathf.Lerp(anim.GetFloat("Speed"), mDeesiredAnimatinSpeed, AnimationBlendSpeed * Time.deltaTime));

            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);
            transform.rotation = Quaternion.Lerp(currentRotation,targetRotation,RotationSpeed*Time.deltaTime);
        }


        #endregion
    }
}