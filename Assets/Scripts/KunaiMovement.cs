using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiMovement : MonoBehaviour
{
    //to get the rigidbody component of the prefab it is attached to
    public Rigidbody2D rb;
    //this variable is set as a public varibable so that it can be changed thorugh the use of player preference
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        // set the speed float to be the ssame as the value that is in the slider
        speed = PlayerPrefs.GetFloat("EnemySpeed");
        //makes the kunai move toward the left at a constant speed
        rb.velocity = new Vector2(-speed, 0.0f);
    }
        

}
