using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    
    public void ProceedToGame()
    {
        FindObjectOfType<SoundManager>().PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.PlayState);
    }


}
