using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("TuteLevelScene");
    }
    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1Scene");
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3Scene");
    }
}
