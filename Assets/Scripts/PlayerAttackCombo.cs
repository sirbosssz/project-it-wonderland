using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCombo : MonoBehaviour {

    public float atkStartSwing = 0.3f;
    public float chainTime = .8f;
    public int combo = 0;
    public float nowTime;

    public AudioSource atkSound;

	// Use this for initialization
	void Start () {
        atkSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (nowTime <= chainTime-atkStartSwing)
            {
                if (combo == 3)
                {
                    combo = 0;
                }
                else
                {
                    combo += 1;
                }
                nowTime = chainTime;
                atkSound.Play();
            }
        }
        if (nowTime>0)
        {
            nowTime -= Time.deltaTime;
        }
        else
        {
            combo = 0;
        }
	}
}
