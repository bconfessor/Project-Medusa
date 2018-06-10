using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIValuesTracker : MonoBehaviour {


    public static UIValuesTracker instance;


    /// <summary>
    /// The time each stage takes, i.e., the time the player has to survive
    /// </summary>
    public int stageTimeLimit = 60;

    /// <summary>
    /// How many enemies the player defeated in this playthrough
    /// </summary>
    public int enemiesKilled;

    /// <summary>
    /// HP text Game Object
    /// </summary>
    public GameObject HPGO;

    /// <summary>
    /// The countdown timer Game Object
    /// </summary>
    public GameObject CountdownGO;

    /// <summary>
    /// The fallen enemies counter Game Object
    /// </summary>
    public GameObject EnemiesCounterGO;


    public IEnumerator StartCountdown()
    {
        int timeElapsed = 0;
        TextMeshProUGUI CountdownText = CountdownGO.GetComponent<TextMeshProUGUI>();


        while(timeElapsed<=stageTimeLimit)
        {
            //check if player died
            if (PlayerStats.instance.isDead)
                break;//stop the countdown

            //each second, rewrite the counter countdown
            CountdownText.text = "Time: " + (stageTimeLimit - timeElapsed);
            timeElapsed++;
            yield return new WaitForSeconds(1);
        }

        //After this, game ends in a victory state
        if(timeElapsed>stageTimeLimit&&!PlayerStats.instance.isDead)
        {
            //victory
            TerminationTracker.instance.PlayerHasWon();
        }

    }

    /// <summary>
    /// Updates the player's life in the UI
    /// </summary>
    public void UpdateHP()
    {
        HPGO.GetComponent<TextMeshProUGUI>().text = "Hp:  " + PlayerStats.instance.HP;
    }

    //player defeated another enemy
    public void AddFallenEnemy()
    {
        //gets current value, adds 1 to it
        enemiesKilled++;
        EnemiesCounterGO.GetComponent<TextMeshProUGUI>().text = enemiesKilled.ToString();

    }

	// Use this for initialization
	void Start () {

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);


        enemiesKilled = 0;
        EnemiesCounterGO.GetComponent<TextMeshProUGUI>().text = enemiesKilled.ToString();
        UpdateHP();
        StartCoroutine(StartCountdown());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
