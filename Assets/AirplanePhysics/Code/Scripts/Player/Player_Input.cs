using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Qubitech
{

    public class Player_Input : MonoBehaviour, IInput
    {
        #region variable
        #endregion

        #region Built In Method


        public Action<Vector2> OnMovementInput { get; set; }
        public Action<Vector3> OnMovementDirectionInput { get; set; }


        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            GetMovementInput();
            GetMovementDirection();
        }
        #endregion
        #region Custom Method

        private void GetMovementInput()
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            OnMovementInput?.Invoke(input);
        }
        private void GetMovementDirection()
        {
            var cameraForwardDirection = Camera.main.transform.forward;
            Debug.DrawRay(Camera.main.transform.position, cameraForwardDirection * 10, Color.red);
            var directionToMoveIn = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
            Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.blue);
            OnMovementDirectionInput?.Invoke(directionToMoveIn);
        }

        #endregion
    }
}