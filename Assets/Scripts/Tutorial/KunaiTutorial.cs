using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiTutorial : MonoBehaviour
{
    //to get the rigidbody component of the prefab it is attached to
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //makes the kunai move toward the left at a constant speed
        rb.velocity = new Vector2(-3, 0.0f);
    }
        

}
