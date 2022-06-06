using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        FindObjectOfType<SoundManager>().PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.PlayState);
    }

    public void ExitGame()
    {
        FindObjectOfType<SoundManager>().PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.MenuState);
    }

}
