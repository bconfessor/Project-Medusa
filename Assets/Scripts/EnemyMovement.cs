using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemySpeed = 2f;

    public bool isPetrified = false;

    public GameObject playerGO;
    Vector3 playerPosition;

    Animator anim;

    EnemyAttack enAt;

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
        enAt = GetComponent<EnemyAttack>();
    }

	// Use this for initialization
	void Start () {
        //this will stop enemy from floating towards player on top of rock
        playerPosition = playerGO.transform.position;
        playerPosition.y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if(!isPetrified && !TerminationTracker.instance.gameIsOver && !enAt.isAttacking)
           MoveTowardsPlayer();

        //if game is over, all enemies must stop
        if (TerminationTracker.instance.gameIsOver)
            anim.SetBool("gameIsOver", true);
    }
}
