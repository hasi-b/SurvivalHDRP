using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]





   
    public class IP_Base_Rigidbody_Controller : MonoBehaviour
    {
        #region variables

        protected Rigidbody rb;
        protected AudioSource aSource;

        #endregion


        #region Built in Methods
        // Start is called before the first frame update
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            aSource = GetComponent<AudioSource>();
            if (aSource)
            {
                aSource.playOnAwake = false;
            }

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(rb)
            {
                HandlePhysics();
            }
        }
        #endregion


        #region Custom Methods
        protected virtual void HandlePhysics()
        {

        }



        #endregion
    }
}
