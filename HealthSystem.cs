using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {
    //This code allow object have a properties of life.

    public int Health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.Health <= 0)
        {
            Destroy(gameObject);
        }
	}

    void TakeDMG (int damage)
    {
        this.Health -= damage;
    }
}
