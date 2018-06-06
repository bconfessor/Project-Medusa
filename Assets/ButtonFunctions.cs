using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ButtonFunctions : MonoBehaviour {

    public static ButtonFunctions instance;

    public GameObject creditsPanel;

    public float gazeTime = 2.0f;
    float timer;

    bool startGazed, creditsGazed, backGazed, quitGazed, OKGazed, restartGazed, returnGazed = false;


    
    public void StartButtonEnter()
    {
        Debug.Log("Gaze at start button");
        startGazed = true;
    }
    public void StartButtonExit()
    {
        Debug.Log("Gaze off start button");
        startGazed = false;
        timer = 0;
    }

    public void StartButtonClicked()
    {
        //Start game, change scene
        SceneManager.LoadScene("StoryIntro");
        timer = 0;
    }


    public void CreditsButtonEnter()
    {
        Debug.Log("Gaze at Credits button");
        creditsGazed = true;
    }

    public void CreditsButtonExit()
    {
        Debug.Log("Gaze off credits button");
        creditsGazed = false;
        timer = 0;
    }

    public void CreditsButtonClicked()
    {
        creditsPanel.SetActive(true);
        timer = 0;
    }


    public void CreditsBackButtonEnter()
    {
        Debug.Log("Gaze at Back Button");
        backGazed = true;
    }

    public void CreditsBackButtonExit()
    {
        Debug.Log("Gaze off Back Button");
        backGazed = false;
        timer = 0;
    }

    public void CreditsBackButtonClicked()
    {
        creditsPanel.SetActive(false);
        timer = 0;
    }



    public void QuitButtonEnter()
    {
        Debug.Log("Gaze at Quit Button");
        quitGazed = true;
    }

    public void QuitButtonExit()
    {
        Debug.Log("Gaze off Quit Button");
        quitGazed = false;
        timer = 0;
    }

    public void QuitButtonClicked()
    {
        Debug.Log("Quitting...");
        Application.Quit();
        timer = 0;
    }



    //Story Intro button
    public void OKButtonEnter()
    {
        Debug.Log("Gaze at OK Button");
        OKGazed = true;
    }
    public void OKButtonExit()
    {
        Debug.Log("Gaze off OK Button");
        OKGazed = false;
        timer = 0;
    }

    public void OKButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
        timer = 0;
    }


    //Main Scene Restart button
    public void RestartButtonEnter()
    {
        Debug.Log("Gaze at Restart Button");
        restartGazed = true;
    }
    public void RestartButtonExit()
    {
        Debug.Log("Gaze off Restart Button");
        restartGazed = false;
        timer = 0;
    }

    public void RestartButtonClicked()
    {
        Debug.Log("Going to restart now...");
        SceneManager.LoadScene("MainScene");
        timer = 0;
    }



    //Main Scene Return to Main Menu button
    public void ReturnButtonEnter()
    {
        Debug.Log("Gaze at Return Button");
        returnGazed = true;
    }
    public void ReturnButtonExit()
    {
        Debug.Log("Gaze off Restart Button");
        returnGazed = false;
        timer = 0;
    }

    public void ReturnButtonClicked()
    {
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("MainMenu");
        timer = 0;
    }





    //============================================================================================================================================================================

    // Use this for initialization
    void Awake () {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;//singleton
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(startGazed||creditsGazed||backGazed||quitGazed||OKGazed||restartGazed||returnGazed)
        {
            timer += Time.deltaTime;
            if(timer >=gazeTime)
            {
                //looked at a button for long enough, activate it(check which one to activate)
                if (startGazed)
                {
                    StartButtonClicked();
                }
                else if (creditsGazed)
                {
                    CreditsButtonClicked();
                }
                else if (backGazed)
                {
                    CreditsBackButtonClicked();
                }
                else if (quitGazed)
                {
                    QuitButtonClicked();
                }

                else if (OKGazed)//OK button from StoryIntro scene
                {
                    OKButtonClicked();
                }

                else if (restartGazed)//Main Scene Restart Button
                {
                    RestartButtonClicked();
                }

                else if (returnGazed)
                {
                    ReturnButtonClicked();
                }

            }
        }
	}
}
