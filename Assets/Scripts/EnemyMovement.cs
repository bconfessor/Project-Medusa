using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemySpeed = 2f;

    public bool isPetrified = false;

    public GameObject playerGO;
    Vector3 playerPosition;


    void MoveTowardsPlayer()
    {
        float step = enemySpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);
    }


	// Use this for initialization
	void Start () {
        //this will stop enemy from floating towards player on top of rock
        playerPosition = playerGO.transform.position;
        playerPosition.y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if(!isPetrified && !TerminationTracker.instance.gameIsOver)
           MoveTowardsPlayer();
    }
}
