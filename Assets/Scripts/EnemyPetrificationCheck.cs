using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPetrificationCheck : MonoBehaviour {

    /// <summary>
    /// Time it takes for medusa Gaze to kill enemy
    /// </summary>
    public float gazeTime = 2f;


    float timer;
    bool enemyBeingGazed = false;

    public float timeToCrumbleIntoDust = 3f;

    bool enemyIsDead = false;

    public void OnGazeEnter()
    {
        enemyBeingGazed = true;
    }

    public void OnGazeExit()
    {
        enemyBeingGazed = false;
        timer = 0;
    }

    //Enemy has been stared at for long enough, petrify them
    public void PetrifyEnemy()
    {
        EnemyMovement en = this.GetComponent<EnemyMovement>();
        en.isPetrified = true;
        Debug.Log("Enemy petrified");
        //Maybe change material so we know it's petrified?


        //enemy was defeated, update Fallen Enemies Counter
        if (!enemyIsDead)
        {
            UIValuesTracker.instance.AddFallenEnemy();
            enemyIsDead = true;//to ensure it will only count once
        }
        StartCoroutine(CrumbleIntoDust());
    }

    public IEnumerator CrumbleIntoDust()
    {
        //Some time after it's petrified, enemy will dissapear
        yield return new WaitForSeconds(timeToCrumbleIntoDust);
        Destroy(this.gameObject);
    }




    // Use this for initialization
    void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //enemy petrification will only work if they're already
        if (enemyBeingGazed && !TerminationTracker.instance.gameIsOver)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
                PetrifyEnemy();
                
        }
	}
}
