using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedALevel : MonoBehaviour
{
    public static FinishedALevel Instance;
    public Text endMessage;

    private int currentLevel;
    private float timeLeft = 30.0f;
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
        currentLevel = 0;
        isLevelFinished = false;
    }

    private void Update()
    {
        //print("UPDATING");
        if (isLevelFinished)
        {
            endMessage.text += message + currentLevel.ToString();
            isLevelFinished = false;
        }
//        timeLeft -= Time.deltaTime;
//        if (timeLeft < 0)
//        {
//            endMessage.text = "";
//            LevelFinished();
//        }
    }

    // Update is called once per frame
    public bool GoalReached(int level)
    {
        this.currentLevel = level;
        isLevelFinished = true;
        return true;
    }

    private void LevelFinished()
    {
        //restart everything and load next level
    }
}
