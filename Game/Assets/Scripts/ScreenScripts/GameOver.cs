using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        SoundManager.Instance.PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.PlayState);
    }

    public void ExitGame()
    {
        SoundManager.Instance.PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.MenuState);
    }

}
