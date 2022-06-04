using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerCommand;
using System; 

public class PlayerController : MonoBehaviour
{
    private IPlayerCommand left;
    private IPlayerCommand right;
    private IPlayerCommand up;
    private IPlayerCommand adjustGravity;
    private IPlayerCommand adjustGravityLeft;
    private IPlayerCommand adjustGravityRight;

    private int _gravityIndex = 0;
    public int GravityIndex
    {
        get => _gravityIndex;
        set => _gravityIndex = value;
    }

    private Vector2 _deltaGravity;
    public Vector2 DeltaGravity
    {
        get => _deltaGravity;
        set => _deltaGravity = value;
    }

    private Vector2 _deltaVelocity;
    public Vector2 DeltaVelocity
    {
        get => _deltaVelocity;
        set => _deltaVelocity = value;
    }

    private Vector2[] _gravityDirs;
    public Vector2[] GravityDirs
    {
        get => _gravityDirs;
        set => _gravityDirs = value;
    }

    void Start(){
        this.left =  ScriptableObject.CreateInstance<MoveLeft>();
        this.right =  ScriptableObject.CreateInstance<MoveRight>();
        this.up =  ScriptableObject.CreateInstance<MoveUp>();
        this.adjustGravityLeft = ScriptableObject.CreateInstance<AdjustGravityLeft>();
        this.adjustGravityRight = ScriptableObject.CreateInstance<AdjustGravityRight>();


        this._deltaGravity = Physics2D.gravity/2;         // save original gravity TEMPORARY
        this._deltaVelocity = new Vector2(0.005f, 0.005f);    // to adjust effect of vertical/horizontal movement

        this.GravityDirs = new Vector2[4] { new Vector2(0, this.DeltaGravity.y),   // bottom
                                            new Vector2(-this.DeltaGravity.y, 0),  // right
                                            new Vector2(0, -this.DeltaGravity.y),  // top
                                            new Vector2(this.DeltaGravity.y, 0)};  // left

        Physics2D.gravity = this.GravityDirs[this.GravityIndex];
        Debug.Log("gravity on start: " + Physics2D.gravity);

    }

    // gets correct negative and positive modulus of two numbers
    public int nfmod(int a,int b)
    {
        return (int)(a - b * Math.Floor(a / (double)b));
    }

    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    void Update() 
    {
        transform.eulerAngles = new Vector3(0,0,0);


        // can use GetAxis for joystick control instead of wasd
        // would have to set up axis so it is not mouse
        // https://docs.unity3d.com/ScriptReference/Input.GetAxis.html

        if (Input.GetKey(KeyCode.A)) 
        {
            Debug.Log("A pressed");
            this.left.Execute(this.gameObject);
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            Debug.Log("D pressed");
            this.right.Execute(this.gameObject);
        }

        if (Input.GetKey(KeyCode.W)) 
        {
            this.up.Execute(this.gameObject);
        }

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) ) 
        {
            this.adjustGravityLeft.Execute(this.gameObject);
        }

        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.P))
        {
            this.adjustGravityRight.Execute(this.gameObject);
        }


        // do player animation here

    }
    

    // add collision functions here
}