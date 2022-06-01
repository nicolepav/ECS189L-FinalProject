using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerCommand;
using System; // for class Math



public class PlayerMovement : MonoBehaviour, IPlayerCommand
{
    [SerializeField]
    private GameObject player;
    private Vector2 deltaGravity; // save original gravity TEMPORARY
    private Vector2 deltaVelocity; // to adjust effect of vertical/horizontal movement
    private Vector2[] gravityDirs;
    private int gravityIndex = 0;

    void Start()
    {
        this.deltaVelocity = new Vector2(0.1f, 0.2f);
        this.deltaGravity = Physics2D.gravity/2;
        this.gravityDirs = new Vector2[4] {new Vector2(0,deltaGravity.y), // bottom
                                            new Vector2(-deltaGravity.y,0), // right
                                            new Vector2(0,-deltaGravity.y), // top
                                            new Vector2(deltaGravity.y,0)}; // left
        Physics2D.gravity = this.gravityDirs[this.gravityIndex];
        Debug.Log("gravity: " + Physics2D.gravity);
    }

    private void Update()
    {
        this.AdjustGravity();
    }
    // adjust gravity
    public void AdjustGravity()
    {
        if (Input.GetKeyDown("space")) // key pressed
        {
            // increment gravity index
            this.gravityIndex = (this.gravityIndex + 1) % 4;
            // set gravity
            Physics2D.gravity = this.gravityDirs[this.gravityIndex];
            // rotate camera
            this.player.GetComponent<Player>().getCamController().GetComponent<CameraController>().rotateCamera();
            //FindObjectOfType<SoundManager>().PlaySoundEffect("Squish");
        } 
    }

    void FixedUpdate()
    {
        // stop rotation - glitch when player is moving and adjustGravity is called.
        transform.eulerAngles = new Vector3(0,0,0);

        // keyboard keys
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // -1 => value < 0; 0 => value == 0; 1 => value > 0
        int xDir = Math.Sign(Physics2D.gravity.x);
        int yDir = Math.Sign(Physics2D.gravity.y);
        float dy = 0;
        float dx = 0;

        if (xDir != 0) // gravity going right/left
        {
            dx = -xDir * moveVertical * deltaVelocity.y;
            dy = xDir * moveHorizontal * deltaVelocity.x;
            // this.player.transform.Translate(-xDir * moveVertical * deltaVelocity.y, xDir * moveHorizontal * deltaVelocity.x, 0.0f);

        } 
        else if (yDir != 0)// gravity going up/down
        {
            dx = -yDir * moveHorizontal * deltaVelocity.x;
            dy = -yDir * moveVertical * deltaVelocity.y;
            // this.player.transform.Translate(-yDir * moveHorizontal * deltaVelocity.x, -yDir * moveVertical * deltaVelocity.y, 0.0f);
        }
        this.player.transform.Translate(dx, dy, 0.0f);
        // Debug.Log("dx: " + dx + ", dy: " + dy);
    }
    
}
