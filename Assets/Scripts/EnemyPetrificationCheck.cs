using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPetrificationCheck : MonoBehaviour {

    /// <summary>
    /// Time it takes for medusa Gaze to kill enemy
    /// </summary>
    public float gazeTime = 2f;

    Animator anim;
    AudioSource enemyAudioSource;

    //Sound that plays when enemy gets petrified
    public AudioClip enemyPetrificationSFX;
    //audio that plays when enemy crumbles into dust(dissapears)
    public AudioClip enemyCrumbleSFX;

    /// <summary>
    /// How much the Stone Storm meter goes up upon defeating an enemy
    /// </summary>
    public float stoneStormMeterIncrease=0.1f;

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

        enemyAudioSource.PlayOneShot(enemyPetrificationSFX);

        //enemy was defeated, update Fallen Enemies Counter(put in if so it only plays once)
        if (!enemyIsDead)
        {
            UIValuesTracker.instance.AddFallenEnemy();
            enemyIsDead = true;//to ensure it will only count once

            //when enemy dies, fill up stone Storm meter
            StoneStormScript.instance.IncreaseStoneStormMeter(stoneStormMeterIncrease);


            //to petrify, simply freeze the animation
            anim.enabled = false;
            //anim.SetTrigger("isPetrified");
        }
        StartCoroutine(CrumbleIntoDust());
    }

    public IEnumerator CrumbleIntoDust()
    {
        //Some time after it's petrified, enemy will dissapear


        //give time to play the petrification sound
        yield return new WaitForSeconds(timeToCrumbleIntoDust / 3);
        enemyAudioSource.Stop();

        //play crumble sound
        enemyAudioSource.PlayOneShot(enemyCrumbleSFX);
        yield return new WaitForSeconds(2*timeToCrumbleIntoDust/3);

        Destroy(this.gameObject);
    }


    void Awake()
    {
        enemyAudioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
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
