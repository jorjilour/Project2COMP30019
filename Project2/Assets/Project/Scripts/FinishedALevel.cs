using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishedALevel : MonoBehaviour
{
    public static FinishedALevel Instance;
    public Text endMessage;

    private string currentLevel;
    private float timeLeft = 2.0f;
    private static string message = "You Finished Level ";
    private Time time;
    private bool isLevelFinished;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(null);
            return;
        }

        Instance = this;
    }


    // Use this for initialization
    void Start()
    {
        //endMessage.text = message;
        isLevelFinished = false;
        endMessage.text = "";

    }

    private void Update()
    {
        //print("UPDATING");
        //print(isLevelFinished);
        if (isLevelFinished)
        {
            print(isLevelFinished);

            endMessage.text = message;

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Debug.Log("going to next scene");
                endMessage.text = "";
                LevelFinished();
            }
        }

    }

    // Update is called once per frame
    public void GoalReached()
    {
        print("goal reached method");
        isLevelFinished = true;
       
    }

    private void LevelFinished()
    {
        //restart everything and load next level
        isLevelFinished = false;
        SceneManager.LoadScene("Level1Scene");
    }
}
