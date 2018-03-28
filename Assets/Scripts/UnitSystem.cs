using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSystem : MonoBehaviour {
    //This code allow object have a properties of life.

    public enum UnitType
    {
        //This allow you to toggle in editor.
        Player = 0,
        Enemy = 1,
        NPC = 2,
        Obstacle = 3,
    }
    public UnitType unitType = 0;

    public int Health;
    public int curHeal;

    public int Energy;
    public int curEn;

    public int HRegen;
    public int ERegen;

    private float clockCounter;

    // Use this for initialization
    void Start () {
        curHeal = Health;
        curEn = Energy;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.curHeal <= 0)
        {
            Destroy(gameObject);
        }
        if (clockCounter == 1)
        {
            curHeal += HRegen;
            curEn += ERegen;
            clockCounter = 0;
        }
        else
        {
            clockCounter += Time.deltaTime;
        }
	}

    void TakeDMG (int damage)
    {
        this.curHeal -= damage;
    }
    void UseEnergy(int cost)
    {
        this.curEn -= cost;
    }
}
