using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewriter : MonoBehaviour {

    /// <summary>
    /// The full text which will be typed.
    /// </summary>
    public string textToWrite;

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
        while(i<fullText.Length)
        {
            TMProToWrite.text += fullText[i++];
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
