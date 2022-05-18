using UnityEngine;
using System.Collections;

public class FloorMoveScript : MonoBehaviour
{
    //used so that the get the location of the player
    public Transform Player;

    void Update()
    {
        //makes sure that the floor will be constantly a set distance away from the player while maintaining the correct height
        transform.position = new Vector3(Player.position.x + 0.5f , 0);

    }
}