using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    //used so that the get the location of the player
    public Transform Player;

    //transforms the postion of the camera
    void Update()
    {
        transform.position = new Vector3(Player.position.x + 0.5f, Player.position.y + 0.5f, -10);

    }
}
