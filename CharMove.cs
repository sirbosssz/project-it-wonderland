using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {
    //This code allow player to move by "WASD" keys.

    // Set Initial values.
    public float speed;
    public float gravity = -9.8f;

    //Use Character controller Component
    private CharacterController _charController;

    // Use this for initialization
    void Start () {
        _charController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) {
            //Get WASD Input direction.
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            //Set Movement for Component
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);

            //Don't forget we have custom gravity!!!
            movement.y = gravity;
            //Make it valid by gametime.
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
        }
	}
}
