using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public float frequencyMax;
    public float enemySpeed;
    public Text HighscoreTXT;
    public int score;
    public int highscore;
    public Text highscoreNum;
    public Slider speed;
    public Slider freq;

    private void Start()
    {
        // gets the current high score before the scene loads
        highscore = PlayerPrefs.GetInt("H I G H S C O R E");
        //sets teh highscore number to be the current highscore
        highscoreNum.text = highscore.ToString();
        ////get the spawn time form the player prefs to set teh slider location
        speed.value = PlayerPrefs.GetFloat("EnemySpeed");

        ////get the enemy speed form the player prefs to set teh slider location
        freq.value = PlayerPrefs.GetFloat("SpawnTime");
    }

    public void Game()
    {
        // set the maximum time between spawn in plyer prefs so that it can be referenced later on
        PlayerPrefs.SetFloat("SpawnTime", frequencyMax);
        // set the speed of the kunai in player prefs so that it can be refrenced later on
        PlayerPrefs.SetFloat("EnemySpeed", enemySpeed);
        //load game scene
        SceneManager.LoadScene("Game");
    }

    public void EnemyFrequency(float frequency)
    {
        //to be linked to the slider UI so that it the value can be changed
        frequencyMax = frequency;

    }

    public void EnemySpeed(float speed)
    {
        //to be linked to the slider UI so that it the value can be changed
        enemySpeed = speed;

    }

    public void tutorial()
    {
        //load Tutorial scene
        SceneManager.LoadScene("Tutorial");
    }

}
