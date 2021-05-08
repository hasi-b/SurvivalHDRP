using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    public class IP_Basic_Follow_Camera : MonoBehaviour
    {
        #region Variables
        [Header("Basic Follow Camera Properties")]
        public Transform target;
        public float distance = 5f;
        public float height = 2f;
        private Vector3 smoothVelocity;
        public float smoothSpeed = 0.5f;
        protected float origHeight;
        #endregion

        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            origHeight = height;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (target)
            {
                HandleCamera();
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleCamera()
        {
            Vector3 wantedPosition = target.position + (-target.forward * distance) +(Vector3.up * height);
            transform.position = Vector3.SmoothDamp(transform.position, wantedPosition,ref smoothVelocity,smoothSpeed) ;



            transform.LookAt(target);

        }



        #endregion
    }
}