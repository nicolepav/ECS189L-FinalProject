using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //When the game is paused, a panel will be displayed to tell the player that the game is currently paused.
    [SerializeField] GameObject pausedScreen;
    

    // Update is called once per frame
    void Update()
    {

        //The player can press Q to pause the game
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PauseGame();
        }

        //The player can press Z to resume the game
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ResumeGame();
        }
        
    }

    //Pauses and freezes the game
    public void PauseGame()
    {
        pausedScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    //Resumes the game 
    public void ResumeGame()
    {
        pausedScreen.SetActive(false);
        Time.timeScale = 1f;
    }

}
