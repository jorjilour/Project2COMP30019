using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("Level1Scene");
    }
    public void GoToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
}
