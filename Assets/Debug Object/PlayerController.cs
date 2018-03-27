using UnityEngine;

public class PlayerController : MonoBehaviour {
    // set Instance for Character Speed
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 240.0f;
    public float jumpSpeed = 10.0f;
    public float gravity = -9.8f;

    private CharacterController _characterController;

	// Use this for initialization
	void Start () {
        // get CharacterController for use
        _characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // get Character movement position
        Vector3 movement = new Vector3();

        /*******************************************************/
        // check movement key
        if (Input.GetKey(KeyCode.W)) {
            // move Forward
            movement.z += movementSpeed;
        }
        if (Input.GetKey(KeyCode.S)) {
            // move Backward
            movement.z -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.A)) {
            // move Left
            movement.x -= movementSpeed;
        }
        if (Input.GetKey(KeyCode.D)) {
            // move Right
            movement.x += movementSpeed;
        }

        /*******************************************************/
        // gravitational physics

        // multiply delta time to fix movement speed for player on diffrent framerate
        movement *= Time.deltaTime;
        // move Player object
        _characterController.Move(movement);

	}
}
