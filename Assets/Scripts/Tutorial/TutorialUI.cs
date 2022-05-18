using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    //used to assign the  panel that is the parent of the ui elements for the pause menu
    public GameObject pauseUI;
    //boolean to be used in the update
    public bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        //used to call the methods  Resume() and Pause() when the button is pressed GameIsPaused is used to determine which method to run
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        // deactivates the pause menu
        pauseUI.SetActive(false);
        //ensure that  time flows normally
        Time.timeScale = 1;
        // set the pause state to be false for the if else statement in the update
        GameIsPaused = false;
    }

    void Pause()
    {
        //activates the pause menu
        pauseUI.SetActive(true);
        //stops time so that the player and obstacles will not move while in the menu
        Time.timeScale = 0;
        // set the pause state to be true for the if else statement in the update
        GameIsPaused = true;
    }

    public void Menu()
    {
        //Changes the scene to the main menu scene
        SceneManager.LoadScene("Main Menu");
        //used to ensure that tiem will not stay at zero when the scene is reloaded
        Time.timeScale = 1;
    }

}
