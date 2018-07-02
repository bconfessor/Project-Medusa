using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemySpeed = 2f;

    public bool isPetrified = false;

    public GameObject playerGO;
    Vector3 playerPosition;

    Animator anim;

    void MoveTowardsPlayer()
    {
        float step = enemySpeed * Time.deltaTime;
        //change position
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);

        //adjust rotation
        transform.LookAt(playerPosition);
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        //this will stop enemy from floating towards player on top of rock
        playerPosition = playerGO.transform.position;
        playerPosition.y = transform.position.y;
        anim.SetTrigger("hasSpawned");
	}
	
	// Update is called once per frame
	void Update () {
        if(!isPetrified && !TerminationTracker.instance.gameIsOver)
           MoveTowardsPlayer();
    }
}
