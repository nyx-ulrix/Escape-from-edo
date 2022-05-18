using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPlayer : MonoBehaviour
{
    public CatchTutorial catchScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if colides with any gameobject with the Dead tag will reset teh scene
        if (collision.CompareTag("Dead"))
        {
            SceneManager.LoadScene("Tutorial");

        }

    }
}
