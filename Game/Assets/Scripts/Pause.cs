using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //When the game is paused, a panel will be displayed to tell the player that the game is currently paused.
    [SerializeField] GameObject pausedScreen;
    public static Pause Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.Instance.Paused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }

    }

    //Pauses and freezes the game
    void PauseGame()
    {
        pausedScreen.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.Paused = true;
    }

    //Resumes the game 
    public void ResumeGame()
    {
        pausedScreen.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.Paused = false;
    }

}
