using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {


    public float enemyDamage=1;//default



    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            //Enemy touched player, damage it
            Debug.Log(gameObject.name + " touched player!");
            PlayerStats.instance.DecreaseHP(enemyDamage);

            //update UI
            UIValuesTracker.instance.UpdateHP();

            //for now, kill enemy as they attack the player
            Destroy(this.gameObject);
        }
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
