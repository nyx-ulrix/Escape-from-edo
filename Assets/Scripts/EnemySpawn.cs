using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //used so that the get the location of the player
    public Transform player;
    // to assign enemy prefab
    public GameObject enemy;
    //float for random range that the kunai will spawn in
    public float range;
    //minimum time between spawn
    public float timeMin = 1f;
    // this is not set to a value as it will be set by the player at the main menu
    public float timeMax;
    // references Ninja.cs to check if the player has died/lost
    public Ninja charater;
    //location of where the kunai will spaw
    Vector2 SpawnPostion;

    // Use this for initialization
    void Start()
    {
        //to set the value of the timemax
        timeMax = PlayerPrefs.GetFloat("SpawnTime");
        // spawn function only needs to be called once as it will keep looping itself
        Spawn();

    }

    // Update is called once per frame
    void Update()
    {
        //makes sure that the spawnner will be constantly a set distance away from the player while maintaining the correct height
        transform.position = new Vector3(player.position.x + 25, player.position.y, 0);

    }

    void Spawn()
    {
        if (charater.lose == false)
        {
            //specify the range the enemy can spawn in
            range = Random.Range(-2, 2);
            //specify teh spawn postion by usingthe players postiotn with an offset of 25 on the x axis and a random offset on the y axis
            SpawnPostion = new Vector2(player.position.x + 25, player.position.y + range);
            //to intstantiate teh object hoever the prefab was made with a rotation so  Quaternion.Euler(0f, 0f, 0f) has to be used
            Instantiate(enemy, SpawnPostion, enemy.transform.rotation * Quaternion.Euler(0f, 0f, 0f));

        }
        //invokes the method at random intervals
        Invoke("Spawn", Random.Range(timeMin, timeMax));
    }

}
