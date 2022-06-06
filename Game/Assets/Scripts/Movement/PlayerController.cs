using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PlayerCommand;
using System; 

public class PlayerController : MonoBehaviour
{
    private IPlayerCommand left;
    private IPlayerCommand right;
    private MoveUp up;
    // private IPlayerCommand adjustGravity;
    private IPlayerCommand adjustGravityLeft;
    private IPlayerCommand adjustGravityRight;
    private List<Action<bool>> collection;
    private bool _isAdjusting = false;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    [SerializeField] private LayerMask platformLayer;
    
    public bool IsAdjusting
    {
        get => _isAdjusting;
        set => _isAdjusting = value;
    }
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
        _animator = transform.GetChild(0).GetComponent<Animator>();
        _boxCollider2D = transform.GetChild(0).GetComponent<BoxCollider2D>();
    
        // this.collection.Add(this.adjustGravityLeft.IsAdjusting);
        // this.collection.Add(this.adjustGravityRight.IsAdjusting);
        // this.collection.Add(this.gameObject.GetComponent<Player>().getCamController().IsAdjusting);
    
    
        this._deltaGravity = Physics2D.gravity/2;         // save original gravity TEMPORARY
        this._deltaVelocity = new Vector2(0.005f, 0.005f);    // to adjust effect of vertical/horizontal movement
    
        this._gravityDirs = new Vector2[4] { new Vector2(0, this.DeltaGravity.y),   // bottom
                                            new Vector2(-this.DeltaGravity.y, 0),  // right
                                            new Vector2(0, -this.DeltaGravity.y),  // top
                                            new Vector2(this.DeltaGravity.y, 0)};  // left
    
        Physics2D.gravity = this.GravityDirs[this.GravityIndex];

    }

    // gets correct negative and positive modulus of two numbers
    public int nfmod(int a,int b)
    {
        return (int)(a - b * Math.Floor(a / (double)b));
    }

    public void AdjustingGravity(bool val)
    {
        foreach (Action<bool> notif in this.collection)
        {
            notif(val);
        }
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
            // Debug.Log("A pressed");
            this.left.Execute(this.gameObject);
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            // Debug.Log("D pressed");
            this.right.Execute(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.W)) 
        {
            if (IsGrounded())
            {
                this.up.Execute(this.gameObject);
                _animator.SetBool("isJumping", true);
            }
        }

        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) ) 
        {
            this.adjustGravityLeft.Execute(this.gameObject);
            
        }

        if (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.P))
        {
            this.adjustGravityRight.Execute(this.gameObject);
        }

        this.SetJump();

        // do player animation here
        if (IsGrounded())
            _animator.SetBool("isJumping", false);
        else
        {
            _animator.SetBool("isJumping", true);
        }
    }
    

    // add collision functions here
    private void SetJump()
    {
        var rigidBody = this.GetComponent<Rigidbody2D>();
        float yDir = Physics2D.gravity[1];
        float xDir = Physics2D.gravity[0];
        float dy = rigidBody.velocity[1];
        float dx = rigidBody.velocity[0];

        // Debug.Log("yDir: " + yDir + ", dy: " + dy);
        // if player is no longer jumping, reset jumps counter
        if ((xDir != 0 && Math.Abs(dx) < 0.001) || (yDir != 0 && Math.Abs(dy) < 0.001))
        {
            this.up.SetCurNumJumps(0);
        } 
    }
    
    private bool IsGrounded()
    {
        var boxDirection = Vector2.down;
        switch (_gravityIndex)
        {
            case (0):
                boxDirection = Vector2.down;
                break;
            case (1):
                boxDirection = Vector2.right;
                break;
            case (2):
                boxDirection = Vector2.up;
                break;
            case (3):
                boxDirection = Vector2.left;
                break;
        }
        
        var leeway = .02f;
        RaycastHit2D rayHit = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f,  boxDirection, 
            leeway, platformLayer);
        Color rayColor;
        if(rayHit.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;
        return rayHit.collider != null;
    }
}