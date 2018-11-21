using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nonvrscript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }


    void Update()
    {

    }

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void Backgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
