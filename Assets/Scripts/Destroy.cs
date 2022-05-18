using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    //used so that the get the location of the player
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //makes sure that the destroyer will be constantly a set distance away from the player while maintaining the correct height
        transform.position = new Vector2(player.position.x - 50, 18);
    }

    //code to destroy all gameobjects with the tag of Tree Island and Enemy
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Tree" || col.tag == "Island"|| col.tag == "Enemy")
            Destroy(col.gameObject);
    }

}