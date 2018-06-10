using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float HP = 100;
    public bool isDead = false;


    public static PlayerStats instance;

    public float petrifyCooldown;


    //damages player
    public void DecreaseHP(float damageValue)
    {
        HP -= damageValue;
        if(HP<=0)
        {
            //player is dead
            Debug.Log("GAME OVER");

            
            isDead = true;
            //send warning to Termination Tracker Script
            TerminationTracker.instance.PlayerHasLost();
        }
    }


	// Use this for initialization
	void Awake () {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

        isDead = false;
        HP = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
