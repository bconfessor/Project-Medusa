using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoneStormScript : MonoBehaviour
{

    /// <summary>
    /// Time it takes for medusa Gaze to kill enemy
    /// </summary>
    public float gazeTime = 1f;
    //Takes a list of all enemies in the scene
    public GameObject[] enemies;

    //image reference of the Stone Storm meter
    public GameObject stoneStormMeter;


    float timer;
    bool triggerBeingGazed = false;

    //turns true when the move is activated
    bool stoneStormCanBeUsed = false;


    public static StoneStormScript instance;

    public void IncreaseStoneStormMeter(float valueToIncrease)
    {
        //increase the value(size) of the meter
        stoneStormMeter.GetComponent<Image>().fillAmount += valueToIncrease;

        //if it reached the top, it can be used
        if(stoneStormMeter.GetComponent<Image>().fillAmount>=1.0f)
        {
            Debug.Log("Stone Storm can now be used!");
            stoneStormCanBeUsed = true;
        }
    }

    //coroutine to empty meter over time
    public IEnumerator EmptyStoneStormMeter()
    {
        //after it is empty, stone storm can't be used until meter refills
        while (stoneStormMeter.GetComponent<Image>().fillAmount>0.0f)
        {
            stoneStormMeter.GetComponent<Image>().fillAmount -= 0.1f;
            yield return new WaitForSeconds(0.15f);
        }
        
    }

    public void OnGazeEnter()
    {
        triggerBeingGazed = true;
    }

    public void OnGazeExit()
    {
        triggerBeingGazed = false;
        timer = 0;
    }



    public void stoneStormActivated()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("STONE STORM ACTIVATED");
        if (enemies.Length != 0)
        {
            //for each enemy in the scene, petrify them ALL
            foreach (GameObject enemy in enemies)
            {
                EnemyPetrificationCheck enPet = enemy.GetComponent<EnemyPetrificationCheck>();
                enPet.PetrifyEnemy();
            }

        }

        //after everything, empty meter again
        StartCoroutine(EmptyStoneStormMeter());
    }


    void Awake()
    {
        //singleton
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;

    }

    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //will activate attack when:
        //1)Trigger has been gazed at long enough
        //2)Game isn't over
        //3)The attack meter is full(i.e., the attack can be used)
        if (triggerBeingGazed && !TerminationTracker.instance.gameIsOver && stoneStormCanBeUsed)//TODO: Implement 3 in UI
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                //Using Stone Storm!
                stoneStormActivated();
                stoneStormCanBeUsed = false;//since it was activated, now it can't be anymore
            }
        }
    }
}
