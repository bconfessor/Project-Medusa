using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemySpeed = 2f;

    public bool isPetrified = false;

    public GameObject playerGO; 

    void MoveTowardsPlayer()
    {
        float step = enemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerGO.transform.position, step);
    }


	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(!isPetrified && !PlayerStats.instance.isDead)
           MoveTowardsPlayer();
    }
}
