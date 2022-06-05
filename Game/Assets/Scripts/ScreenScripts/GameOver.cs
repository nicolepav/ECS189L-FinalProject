using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        GameManager.Instance.UpdateState(GameState.PlayState);
    }

    public void ExitGame()
    {
        GameManager.Instance.UpdateState(GameState.MenuState);
    }

}
