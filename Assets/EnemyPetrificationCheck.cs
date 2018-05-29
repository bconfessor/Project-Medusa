using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPetrificationCheck : MonoBehaviour {


    public float gazeTime = 2f;
    float timer;
    bool enemyBeingGazed = false;

    public float timeToCrumbleIntoDust = 3f;


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
		if(enemyBeingGazed)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
                PetrifyEnemy();
                
        }
	}
}
