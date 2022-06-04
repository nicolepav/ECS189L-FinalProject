using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerCommand;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject camController;
    
    // level tracking variables
    private bool shouldUpdateLevel; 
    private int nextLevel;
    private int currentLevel;

    // scene level 
    // levels[0] is placeholder for current scene name, levels start 1,2,3...
    // must match scene name to string in levels
    List<string> levels = new List<string>(){"", "Level1"};

    void Start()
    {
        this.shouldUpdateLevel = true;
        this.nextLevel = 1;

        //I added an int for the current level to test the text display
        this.currentLevel = 1;
        this.levels[0] = this.player.scene.name;
        
        DisplayScore.Instance.SetScoreText(this.currentLevel);
    }
 
    void Update()
    {
        // level tracker
        updateLevel();
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
            
            // update camera controller
            this.camController = GameObject.Find("CameraController");
        }
    }
    
    public CameraController getCamController()
    {
        this.camController = GameObject.Find("CameraController");
        return this.camController.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("levelTrigger"))
        {
            //I invoked the function to update the displayed score.
            this.currentLevel+=1;
            DisplayScore.Instance.SetScoreText(this.currentLevel);

            // Debug.Log("Level Trigger activated");
            GameManager.Instance.UpdateLevel(player);
            
        }
            
    }

    // rotate player graphic
    public void RotatePlayerLeft()
    {
        // transform.GetChild(0).transform.Rotate(0,0,-90);
    }
    public void RotatePlayerRight()
    {
        // transform.GetChild(0).transform.Rotate(0,0,90);
    }
    
}
