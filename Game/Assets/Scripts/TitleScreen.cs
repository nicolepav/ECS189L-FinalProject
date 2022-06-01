using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    
    public void StartGame()
    {
        //When the player clicks the button to start the game, the first scene of the game is loaded.
        SceneManager.LoadSceneAsync("Gameplay", LoadSceneMode.Additive);
        
    }
}
