using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    //This code make player can move camera by mouse.
    //TO SET!!!!! : 1. add to character and make it X mode.  2. add to camera and make it Y mode.

	public enum RotationAxes {
        //This allow you to toggle in editor.
        MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}

	public RotationAxes axes = RotationAxes.MouseXandY;

	public float sensitivityHor = 9;
	public float sensitivityVer = 9;

	public float minimumVer = -15;
	public float maximumVer =  15;

	private float _rotationX = 0;

    private bool IsRightHold = true;

	void Start () {
		Rigidbody body = GetComponent<Rigidbody> ();
		if(body != null){
			body.freezeRotation = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
        //CheckRightMouse();
        if(IsRightHold && Time.timeScale > 0) {
            if (axes == RotationAxes.MouseX)
            {
                // mouse in X direction
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                // mouse in Y direction
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
                _rotationX = Mathf.Clamp(_rotationX, minimumVer, maximumVer);

                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                // both direction
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
                _rotationX = Mathf.Clamp(_rotationX, minimumVer, maximumVer);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
		
	}

    void CheckRightMouse() {
        //To check if right mouse is held.
        //NOT USE FOR NOW
        if (Input.GetMouseButtonDown(1))
            IsRightHold = true;
        else if (Input.GetMouseButtonUp(1))
            IsRightHold = false;

    }
}
