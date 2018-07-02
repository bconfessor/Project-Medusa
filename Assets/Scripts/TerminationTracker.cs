using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// This script basically tracks whether the countdown hit zero, or whether the player has died(win and defeat, respectively)
/// </summary>
public class TerminationTracker : MonoBehaviour {

    public static TerminationTracker instance;

    public GameObject StageEndCanvasGO, StageEndText, StageEndDescriptionText;

    public bool gameIsOver = false;


    /// <summary>
    /// Will activate Stage End Canvas in a losing state
    /// </summary>
    public void PlayerHasLost()
    {
        gameIsOver = true;
        StageEndCanvasGO.SetActive(true);
        StageEndText.GetComponent<TextMeshProUGUI>().text = "You died";
        StageEndDescriptionText.GetComponent<TextMeshProUGUI>().text = "\nScore: " + UIValuesTracker.instance.enemiesKilled;
    }


    /// <summary>
    /// Activates Stage End Canvas in a winning state
    /// </summary>
    public void PlayerHasWon()
    {
        gameIsOver = true;
        StageEndCanvasGO.SetActive(true);
        StageEndText.GetComponent<TextMeshProUGUI>().text = "You survived !";
        StageEndDescriptionText.GetComponent<TextMeshProUGUI>().text = "\nHigh Score: "+ UIValuesTracker.instance.enemiesKilled;
    }



	// Use this for initialization
	void Start () {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
