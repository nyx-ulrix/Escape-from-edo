using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    //to assign the tree prefab so that it can be instantiated
    public GameObject tree;
    //used so that the spawnner will move along with the player so that the Tree will be spawnnned at a set distance from the player
    public Transform player;
    public TreeChecker check;

    // Update is called once per frame
    void Update()
    {
        //makes sure that the spawnner will be constantly a set distance away from the player
        //while maintaining the correct height

        transform.position = new Vector3(player.position.x + 10, 6, 11);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // this if statement will check if there is something that is not an tree if an tree is deteccted it will
        // not instantiate an object

        if (collision.CompareTag ("Tree"))
        {
            // if else statement is used to ensure that the script does not keep spawwing Tree at the same place as ther will be
            // an offset between where the Tree is spawnned and the checker
            if (check.treeSpawned == false)
            {
                //code to spawn the prefab which will cange in the x axis along with the player
                GameObject go = Instantiate(tree, new Vector3(player.position.x + 25, 1, 10), Quaternion.identity) as GameObject;
            }

        }

    }
}
