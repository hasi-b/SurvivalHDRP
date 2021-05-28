using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Qubitech
{

    public class PlayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        IInput input;
        PlayerMovement movement;
        void OnEnable()
        {
            input = GetComponent<IInput>();
            movement = GetComponent<PlayerMovement>();
            input.OnMovementDirectionInput += movement.HandleMovementDirection;
            input.OnMovementInput += movement.HandleMovement;
        }

        private void OnDisable()
        {
            input.OnMovementDirectionInput -= movement.HandleMovementDirection;
            input.OnMovementInput -= movement.HandleMovement;
        }
    }
}