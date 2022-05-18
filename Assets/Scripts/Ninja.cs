using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ninja : MonoBehaviour
{
    //used to assign the panels panels that are parents of the UI elements for the lose menu
    public GameObject loseUI;
    //reference the catch script to get the score (go to Catch.cs for more info)
    public Catch catchScript;
    //integer for the score 
    public int score;
    //boolean to check if the player is dead
    public bool lose;
    //used to assign the lose score text so that it can be edited in the script
    public Text loseTXT;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") || collision.CompareTag("Enemy"))
        {
            //references the catch script so that the score will be set to the number of shuriken that has been caught
            score = catchScript.Shuriken;

            //changes the score text to be the score when the player died
            loseTXT.text = "Score:" + score;

            //activates the UI
            loseUI.SetActive(true);

            //stop time
            Time.timeScale = 0f;

            //set the lose boolean to be true so that the resume and lose UI wont show up together ( more info in UIManager.cs)
            lose = true;

            //if the current score is highter than the highscore it will set the current score as the new highscore
            if (PlayerPrefs.GetInt("H I G H S C O R E") < score)
            {
                PlayerPrefs.SetInt("H I G H S C O R E", score);

            }

        }
    }
}
