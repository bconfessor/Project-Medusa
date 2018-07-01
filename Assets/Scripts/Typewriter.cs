using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour {

    /// <summary>
    /// The full text which will be typed.
    /// </summary>
    string textToWrite = "The story of Medusa is one of the most notorious legends from the ancient Greek culture. "
        + "Best known for her hair made out of snakes, Medusa's head was seen as a valuable weapon capable of petrifying enemies. "
        + "\nWith the garden full of statues from her enemies, Medusa hears screams and realizes she is under attack. "
        + "\n\nNow you as Medusa need to survive using your petrifying eyes!";

    /// <summary>
    /// The time it takes for each new letter to show up.
    /// </summary>
    public float timeOfEachPress=0.5f;

    TextMeshProUGUI TMProToWrite;
    public GameObject textGO;

    public IEnumerator WriteText(string fullText)
    {
        int i = 0;
        TMProToWrite.text = "";
        string currentText = "";
        while(i<fullText.Length)
        {
            currentText += fullText[i++]; 
            TMProToWrite.text = currentText;
            yield return new WaitForSeconds(timeOfEachPress);
        }
    }

	// Use this for initialization
	void Start () {
        TMProToWrite = textGO.GetComponent<TextMeshProUGUI>();
        StartCoroutine(WriteText(textToWrite));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
