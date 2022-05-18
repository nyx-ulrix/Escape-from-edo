using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandChecker : MonoBehaviour
{
    // to assign where the players transform so that it can be referenced in the update
    public Transform player;
    //boolean to check if there is a island at the location of the checker
    public bool islandSpawned;

    // Update is called once per frame
    void Update()
    {
        //makes sure that the spawnner will be constantly a set distance away
        //from the player while maintaining the correct height
        transform.position = new Vector3(player.position.x + 22, 25, 11);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if statement to see if the collision was with a island
        if (collision.CompareTag("Island"))
        {
            islandSpawned = true;
        }
    }

    // to see if the island is no longer in contact
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if statement to see if the collision was with a island but in this
        //case if it is in contact with anything but the island the code will run
        if (collision.CompareTag("Island"))
        {
            islandSpawned = false;
        }
    }
}
