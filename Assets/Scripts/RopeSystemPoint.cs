using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RopeSystemPoint : MonoBehaviour
{
    // variables to keep track of the different components the RopeSystem script will interact with.
    // ropehingeanchor is used to set the point end point of the rope with the start to be the players current position
    public GameObject ropeHingeAnchor;
    //distance joint here is used to ensure that the rope does not extend at a later stage
    public DistanceJoint2D ropeJoint;
    //boolean to check if teh rope has been attached
    private bool ropeAttached;
    //to get the position of the player
    private Vector2 playerPosition;
    //rigidbody componenet for the rope hinge
    private Rigidbody2D ropeHingeAnchorRb;
    //get the renderer component
    private SpriteRenderer ropeHingeAnchorSprite;
    // rope renderer component
    public LineRenderer ropeRenderer;
    //list that will be used to store the location of the point that was clicked as well as the location of the player 
    private List<Vector2> ropePositions = new List<Vector2>();
    private bool distanceSet;
    public AudioSource ropeVFX;
    // references Ninja.cs to check if the player has died/lost
    public Ninja player;
    // references the UIManager script to check if the game is paused
    public UserInterface GameIsPaused;
    //boolean variable to check if the game has been paused
    public bool PauseState;


    void Awake()
    {
        //ensure that the ropejoint is disabled
        ropeJoint.enabled = false;
        //set the playerPosition to be the players current position so that it can be referenced easily later on
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
    }

    // First, you capture the world position of the mouse cursor using the camera's ScreenToWorldPoint method.
    // You then calculate the facing direction by subtracting the player's position from the mouse position in
    // the world. You then use this to create aimAngle, which is a representation of the aiming angle of the
    // mouse cursor. The value is kept positive in the if-statement.
    void Update()
    {
        var mouse = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        //The player position is tracked using a convenient variable to save you from referring
        //to transform.Position all the time.

        playerPosition = transform.position;

        PauseState = GameIsPaused.GameIsPaused;

        HandleInput(mouse);

        UpdateRopePositions();

    }

    // HandleInput is called from the Update() loop, and simply polls for input from the left and right mouse buttons.
    private void HandleInput(Vector2 mouse)
    {
        //used to check if the layer has died/lost
        if (player.lose == false && PauseState == false)
        {
            //code that runs when a left mouse click is detected
            if (Input.GetMouseButtonDown(0))
            {
                // a 2D raycast is fired to and from the position of the mouse cursor this is to check that theree is a gameobject in the location the player has clicked
                var hit = Physics2D.Raycast(mouse, mouse, 0f);

                if (ropeAttached)
                {
                    //deactivates the rope system when the left mouse button is clicked again
                    ResetRope();

                }

                else if (!ropeAttached)
                {
                    if (ropeAttached) return;
                    ropeRenderer.enabled = true;

                    //when the raycast hits on a gameobject with a collide
                    if (hit.collider != null)
                    {
                        //plays the rope audio
                        ropeVFX.Play();
                        // sets the ropeAttached to be true to be referenced
                        ropeAttached = true;
                        //if the raycast hits something
                        if (!ropePositions.Contains(hit.point))
                        {
                            //impulse force is added to move the player slightlty
                            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 5f), ForceMode2D.Impulse);
                            //adds the location of the mouse click to the list
                            ropePositions.Add(mouse);
                            //sets teh lenght of the rope based on the distance between the player and the location of the click
                            ropeJoint.distance = Vector2.Distance(playerPosition, mouse);
                            //set the ropejoint to be true so that the rope distance will be constant
                            ropeJoint.enabled = true;
                            //enable the anchor point sprite
                            ropeHingeAnchorSprite.enabled = true;
                        }
                    }

                    //if the raycast doesn't hit anything, then the rope line renderer and rope joint are disabled,
                    //and the ropeAttached flag is set to false.
                    else
                    {
                        ropeRenderer.enabled = false;
                        ropeAttached = false;
                        ropeJoint.enabled = false;
                    }
                }
            }
        }

    }

    //if the left mouse button is clicked again , the ResetRope() method is called, which will disable and reset all
    //rope/grappling hook related parameters to what they should be when the grappling hook is not being used.
    private void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }

    private void UpdateRopePositions()
    {
        // exits method if the rope isn't actually attached.
        if (!ropeAttached)
        {
            return;
        }

        // Set the rope's line renderer vertex count (positions) to whatever number of positions are stored in
        // ropePositions, plus 1 more (for the player's position).
        ropeRenderer.positionCount = ropePositions.Count + 1;

        // loop backwards through the ropePositions list, and for every position (except the last position),set the line renderer vertex position to the location the player clicked
        for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
        {
            if (i != ropeRenderer.positionCount - 1)
            {
                ropeRenderer.SetPosition(i, ropePositions[i]);

                //Set the rope anchor to the second-to-last rope position where the current hinge/anchor should be,
                //or if there is only one rope position, then set that one to be the anchor point. This configures
                //the ropeJoint distance to the distance between the player and the current rope position being
                //looped over.
                if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                {
                    var ropePosition = ropePositions[ropePositions.Count - 1];
                    if (ropePositions.Count == 1)
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                    else
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                // This if-statement handles the case where the rope position being looped over is the
                // second-to-last one; that is, the point at which the rope connects to an object, a.k.a.
                // the current hinge/anchor point.
                else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                {
                    var ropePosition = ropePositions.Last();
                    ropeHingeAnchorRb.transform.position = ropePosition;
                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                        distanceSet = true;
                    }
                }
            }
            else
            {
                // Sets the rope's last vertex position to the player's current position
                ropeRenderer.SetPosition(i, transform.position);
            }
        }
    }
}