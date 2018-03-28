using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAIMaster : MonoBehaviour {
    //This code will be AI mastercode, to Extends :  " public class CODENAME : CustomAIMaster " instead of Mono.

    public enum AIAttackType
    {
        //This allow you to toggle in editor.
        MeleeAI = 0,
        RangeAI = 1,
    }

    public enum AIBehave
    {
        //This allow you to toggle in editor.
        Aggressive = 0,
        Passive = 1,
    }

    public float MeleeRange = 50;
    public float RangedRange = 300;

    public AIAttackType atktype = 0;
    public AIBehave behave = 0;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dist = 9999999999;
        if (player)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }

        if (dist < 700)
        {
            BotFacePlayer();
        }
        else
        {
            Debug.Log("");
        }
	}

    void BotFacePlayer()
    {
        if (behave == AIBehave.Aggressive)
        {

        }
    }

    void BotAttack()
    {

    }


}
