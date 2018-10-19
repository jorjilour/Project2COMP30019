using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    public static GameOver Instance;
    public Text youLoseMessage;
    public bool isGameOver;
    private float timeLeft = 3.0f;

    public void Start()
    {
        isGameOver = false;
    }

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(null);
            return;
        }

        Instance = this;
    }

    public void Update()
    {
        if(isGameOver)
        {

            youLoseMessage.text = "GAME OVER";
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Debug.Log("going to main menu");
                youLoseMessage.text = "";
                SceneManager.LoadScene("MainMenu");
                isGameOver = false;
            }
        }

    }
}
