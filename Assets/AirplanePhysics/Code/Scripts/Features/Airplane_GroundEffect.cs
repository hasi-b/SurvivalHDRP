using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Qubitech
{
    public class Airplane_GroundEffect : MonoBehaviour
    {

        #region Variables
        public float maxGroundDistance =3f;
        public float liftForce = 100f;
        private Rigidbody rb;
        public float maxSpeed;
        #endregion

        #region BuiltIn Methods
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();

        }
       

        

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rb)
            {
                HandleGroundEffect();
            }
        }
        #endregion

        #region Custom Methods
        protected virtual void HandleGroundEffect()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,Vector3.down, out hit))
            {
                if (hit.transform.tag == "ground" && hit.distance< maxGroundDistance)
                {

                    float currentSPeed = rb.velocity.magnitude;
                    float normalizedSpeed = currentSPeed / maxSpeed;
                    normalizedSpeed = Mathf.Clamp01(normalizedSpeed);
                  

                    float distance = maxGroundDistance - hit.distance;
                    float finalForce = liftForce * distance*normalizedSpeed;
                    rb.AddForce(Vector3.up * finalForce);
                }
            }
        }
        #endregion
    }


}