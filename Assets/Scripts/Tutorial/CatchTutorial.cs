using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTutorial : MonoBehaviour
{
    //used to assign the panel that is the parent of the ui elements for the clear menu
    public GameObject TutorialClear;
    //used so that the get the location of the player
    public Transform player;
    Collider2D deflect;
    //the shuriken integer is public as it will later be referenced byu other scripts and used as a score
    public int Shuriken;

    private void Start()
    {
        deflect = GetComponent<Collider2D>();
        //make sure that the score will be reset
        Shuriken = 0;
    }

    private void Update()
    {
        //makes sure that the catch radius will be constantly a set distance away from the player while maintaining the correct height
        transform.position = new Vector2(player.position.x, player.position.y);
    }

    private void FixedUpdate()
    {
        //when the mouse button is down the deflect (collider component see start function) will be activated for 0.5 frames before the disable deflect method is called
        if (Input.GetMouseButtonDown(1))
        {
            deflect.enabled = true;
            Invoke("disableDeflect", 0.5f);
        }
    }

    // method to disable the collider
    void disableDeflect()
    {
        deflect.enabled = false;
    }

    //if the collider which has to be activated is activated and there is a collision with an object with the tag Enemy
    //the enemy will be destroyed, the UI that shows you have completed the level will be displayed and time will be stopped
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TutorialClear.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
