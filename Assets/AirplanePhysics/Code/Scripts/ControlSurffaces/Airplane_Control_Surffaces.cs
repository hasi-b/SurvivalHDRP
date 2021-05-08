using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Qubitech
{
    public class Airplane_Control_Surffaces : MonoBehaviour
    {

        public enum ControlSurfaceType
        {
            Rudder,
            Elevator,
            Flap,
            Alleron

        }

        #region variables
        [Header("Control Surface Properties")]
        public ControlSurfaceType type = ControlSurfaceType.Rudder;
        public float maxAngle = 30f;
        public Vector3 axis = Vector3.right;
        public Transform controlSurfaceGraphic;

        public float smoothSpeed;

        private float wantedAngle;
        #endregion




        #region BuiltInMethods
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (controlSurfaceGraphic)
            {
                Vector3 finalAngleAxis = axis * wantedAngle;
                controlSurfaceGraphic.localRotation = Quaternion.Slerp(controlSurfaceGraphic.localRotation,Quaternion.Euler(finalAngleAxis),Time.deltaTime*smoothSpeed);

            }
        }
        #endregion

        #region Custom Methods
        public void HandleControlSurface(IP_Base_Airplane_Input input)
        {
            float inputValue = 0f;
            switch(type)
            {
                case ControlSurfaceType.Rudder:
                    inputValue = input.Yaw;
                    break;
                case ControlSurfaceType.Elevator:
                    inputValue = input.Pitch;
                    break;
                case ControlSurfaceType.Flap:
                    inputValue = input.Flap;
                    break;
                case ControlSurfaceType.Alleron:
                    inputValue = input.Roll;
                    break;
                default:
                    break;
            }
            wantedAngle = maxAngle * inputValue;
        }

        #endregion
    }
}