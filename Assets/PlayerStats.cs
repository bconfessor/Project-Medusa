using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float HP = 100;
    public bool isDead = false;

    public GameObject gameOverCanvas;

    public static PlayerStats instance;

    public float petrifyCooldown;

    //what will this do? Probably show "Game Over" screen
    public void PlayerIsDead()
    {
        //show Game OVER Panel and Restart Button
        gameOverCanvas.SetActive(true);
    }

    //damages player
    public void DecreaseHP(float damageValue)
    {
        HP -= damageValue;
        if(HP<=0)
        {
            //player is dead
            Debug.Log("GAME OVER");
            isDead = true;
            PlayerIsDead();
        }
    }


	// Use this for initialization
	void Start () {
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
