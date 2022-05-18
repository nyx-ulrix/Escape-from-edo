using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{

    //used to assign the two panels that are parents of the ui elements for the menu
    public GameObject pauseUI;
    public GameObject loseUI;
    //used to assign the score text so that it can be edited in the script
    public Text scoreTXT;
    public Text pauseTXT;
    //boolean to be used in the update
    public bool GameIsPaused = false;
    //references the catch script to get the score (refer to Catch.cs for more info)
    public Catch catchScript;
    //integer used to assign the score from the catch scripts
    public int score;
    //integer is used to assign the PlayerPrefs (for simplicity)
    public int highscore;
    //use dot get the highscore text so that it can be edited through the scirpt
    public Text highscoretext;
    // references Ninja.cs to check if the player has died/lost
    public Ninja player;

    private void Start()
    {
        // gets the current high score before the game starts
        highscore = PlayerPrefs.GetInt("H I G H S C O R E");
    }

    // Update is called once per frame
    void Update()
    {
        //used to check if the layer has died/lost
        if (player.lose == false)
        {
            //used to call the methods  Resume() and Pause()
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

        //referece to the catch script that catches the 
        score = catchScript.Shuriken;
        highscoretext.text = "Highscore: " + highscore;
        //changes all the score text to be the words Score: followed by the current score
        scoreTXT.text = "Score:" + score;
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
        // sets the score text in the pause menu
        pauseTXT.text = "Score:" + score;
        //activates the pause menu
        pauseUI.SetActive(true);
        //stops time so that the player and obstacles will not move while in the menu
        Time.timeScale = 0;
        // set the pause state to be true for the if else statement in the update
        GameIsPaused = true;
    }

    public void Restart()
    {
        //used to reset the scene
        SceneManager.LoadScene("Game");
        //used to ensure that tiem will not stay at zero when the scene is reloaded
        Time.timeScale = 1;
        //set the player to lose the variable is used to ensure that the lose menu and the pause menu wont both be activated
        player.lose = false;
    }

    public void Menu()
    {
        //Changes the scene to the main menu scene
        SceneManager.LoadScene("Main Menu");
        //used to ensure that tiem will not stay at zero when the scene is reloaded
        Time.timeScale = 1;
    }

}
