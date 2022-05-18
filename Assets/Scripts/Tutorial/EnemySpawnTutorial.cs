using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTutorial : MonoBehaviour
{
    // to assign enemy prefab
    public GameObject enemy;
    //minimum time between spawn
    public float timeMin = 3f;
    //maximum time between spawn
    public float timeMax = 5f;
    // references Ninja.cs to check if the player has died/lost
    public Ninja charater;
    //location of where the kunai will spaw
    Vector2 SpawnPostion;

    // Use this for initialization
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Instantiate(enemy, new Vector2(112, 24), enemy.transform.rotation * Quaternion.Euler(0f, 0f, 0f));
        Invoke("Spawn", Random.Range(timeMin, timeMax));
    }

}
