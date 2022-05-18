using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawn : MonoBehaviour
{
    //used tp assign the island prefab to the spawnner
    public GameObject island;
    //used so that the spawnner will move along with the player so that the island will be spawnnned at a set distance from the player
    public Transform player;
    //float for random range that the Island will spawn in
    public float range;
    //location of where the Island will spaw
    Vector3 SpawnPostion;
    private bool islandDetect = false;
    //reference to the checker gameobject script
    public IslandChecker check;

    // Update is called once per frame
    void Update()
    {
        //makes sure that the spawnner will be constantly a set distance away from the player while maintaining the correct height
        transform.position = new Vector2(player.position.x + 3, 21);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Island"))
        {
            if (islandDetect == false)
            {

                //specify the range the enemy can spawn in
                range = Random.Range(20, 25);
                //specify teh spawn postion by usingthe players postiotn with an offset of 25 on the x axis and a random offset on the y axis
                SpawnPostion = new Vector3(player.position.x + 25, range, 10);
                //code to spawn the prefab which will cange in the x axis along with the player
                //extra offset compared to the spawnner object just so that there is a space between the island
                GameObject go = Instantiate(island, SpawnPostion, Quaternion.identity) as GameObject;
            }
        }
    }
}
