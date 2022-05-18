using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChecker : MonoBehaviour
{
    // to assign where the players transform so that it can be referenced in the update
    public Transform player;
    //boolean to check if there is a tree at the location of the checker
    public bool treeSpawned;

    // Update is called once per frame
    void Update()
    {
        //makes sure that the spawnner will be constantly a set distance away
        //from the player while maintaining the correct height
        transform.position = new Vector2(player.position.x + 25, 6);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if statement to see if the collision was with a tree
        if (collision.CompareTag("Tree"))
        {
            treeSpawned = true;

        }
    }

    // to see if the tree is no longer in contact
    private void OnTriggerExit2D(Collider2D collision)
    {
        //if statement to see if the collision was with a tree but in this
        //case if it is in contact with anything but the tree the code will run
        if (collision.CompareTag("Tree"))
        {
            treeSpawned = false;
        }
    }
}
