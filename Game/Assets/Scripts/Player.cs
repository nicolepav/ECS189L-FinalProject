using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerCommand;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject player;


    //movement controls
    private PlayerMovement movement;
    int[] gravity = new int[2] {0,-1}; // direction of down [x dir(+/-), y dir(+/-)]

    // level trackers
    private bool shouldUpdateLevel; 
    private int nextLevel;
    // scene level names
    List<string> levels = new List<string>(){"", "Level1"}; // empty string is current scene name, levels start 1,2,3...
    // Start is called before the first frame update
    void Start()
    {
        this.shouldUpdateLevel = true;
        this.nextLevel = 1;
        this.levels[0] = this.player.scene.name;
        Debug.Log(levels[0]);
        //-----------
        this.movement = this.gameObject.AddComponent<PlayerMovement>() as PlayerMovement;
    }

    void Update()
    {
        // level tracker
        updateLevel();
        //movement
        updateMovement();

    }
    void updateMovement()
    {
        // if (Input.GetButtonDown("up"))
        // {
        //     this.movement.Jump(this.gameObject,this.gravity);
        // }
        if (Input.GetAxis("Horizontal") != 0)
        {
            this.movement.MoveHorizontally(this.gameObject,this.gravity);
        }
    }
    void updateLevel()
    {
        // need to update level 
        if (this.shouldUpdateLevel && !this.levels[0].Equals(this.levels[this.nextLevel]))
        {
            // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
            SceneManager.MoveGameObjectToScene(this.player, SceneManager.GetSceneByName(this.levels[this.nextLevel]));
            // update cur scene name
            this.levels[0] = this.player.scene.name;
            this.shouldUpdateLevel = false;
            // update nextLevel
            this.nextLevel = this.nextLevel + 1;
            Debug.Log(levels[0]);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        gameObject.transform.Translate(moveHorizontal * 0.05f, moveVertical * 0.25f, 0.0f);
    }
}
