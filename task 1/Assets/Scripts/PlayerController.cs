using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public float movespeed = 2.0f;

    private PlayerInput playerInput;
    private InputController PlayerInputControl;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        PlayerInputControl = new InputController();
        PlayerInputControl.Player.Enable();
        PlayerInputControl.Player.Jump1.performed += Jump;
        PlayerInputControl.Player.Movement.performed += Move;
    }
    private void FixedUpdate()
    { 
        Vector2 inputVector = PlayerInputControl.Player.Movement.ReadValue<Vector2>();
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * movespeed, ForceMode.Force);
    }
    // Update is called once per frame
    public void Jump(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
   public void Move(InputAction.CallbackContext Context)
    {
        Vector2 inputVector = PlayerInputControl.Player.Movement.ReadValue<Vector2>();
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * movespeed, ForceMode.Force);
    }
}
