using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
    [SerializeField] private Transform target;
    public float rotationSpeed = 1.5f;
    private float _rotationY;
    private Vector3 _offset;

	// Use this for initialization
	void Start () {
        _rotationY = transform.eulerAngles.y;
        //
        _offset = target.position - transform.position;
	}

    void LateUpdate() {
        float horInput = Input.GetAxis("Horizontal");
        if (horInput != 0) {
            //
            _rotationY += horInput * rotationSpeed;
        } else {
            //
            _rotationY += Input.GetAxis("Mouse X") * rotationSpeed * 3;
        }
        //
        Quaternion rotation = Quaternion.Euler(0, _rotationY, 0);
        //
        transform.position = target.position - (rotation * _offset);
        //
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
