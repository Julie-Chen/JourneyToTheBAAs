using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePause = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    //Sets buttons
    void Update()
    {
        //Pauses Game
        if(Input.GetButtonDown("Pause"))
        {
            GamePause = !GamePause;
        }

        if (GamePause)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!GamePause)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    //Function for resume button
    public void Resume()
    {
        GamePause = false;
    }
    //Function to restart game
    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    //Function for loading main menu
    public void MainMenu()
    {
        Application.LoadLevel(0);
    }
    //Function for loading level selector
    public void LevelSelector()
    {
        Application.LoadLevel(8);
    }
}
