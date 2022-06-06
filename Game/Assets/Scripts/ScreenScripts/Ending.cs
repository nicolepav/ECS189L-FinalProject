using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public void JumpToGameOver()
    {
        FindObjectOfType<SoundManager>().PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.MenuState);
    }
}
