using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {
    //This code allow player to move by "WASD" keys.

    // Set Initial values.
    public float speed;
    public float gravity = -5.8f;
    public float jumpSpeed = 0.5f;
    public float terminalVelocity = -1.5f;
    public float minFall = -0.1f;
    private float _vertSpeed;

    //Use Character controller Component
    private CharacterController _charController;

    // Use this for initialization
    void Start () {
        _charController = GetComponent<CharacterController>();
        _vertSpeed = minFall;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;
        if (1==1) {
            movement = new Vector3(0, 0, 0);
            //Get WASD Input direction.
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                float deltaX = Input.GetAxis("Horizontal") * speed;
                float deltaZ = Input.GetAxis("Vertical") * speed;
                movement = new Vector3(deltaX, 0, deltaZ);
                movement = Vector3.ClampMagnitude(movement, speed);
                // Make it valid by gametime.
                movement *= Time.deltaTime;
                //Set Movement for Component
                movement = transform.TransformDirection(movement);
            }

            //JUMP
            if (_charController.isGrounded)
            {
                if (Input.GetKey("space"))
                {
                    _vertSpeed = jumpSpeed;
                    _vertSpeed = _vertSpeed * 0.1f;
                }
                else
                {
                    _vertSpeed = minFall * 0.1f;
                }
            }
            else
            {
                _vertSpeed += gravity * 1 * Time.deltaTime;
                if (_vertSpeed < terminalVelocity)
                {
                    _vertSpeed = terminalVelocity;
                }
            }
            movement.y = _vertSpeed;
            //

            _charController.Move(movement);
        }
	}
}
