using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync("Gameplay");
        //SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("Gameplay"));
    }

    public void ExitGame()
    {
        SceneManager.LoadSceneAsync("Title");

    }

}
