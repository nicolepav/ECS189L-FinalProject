using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    
    public void ProceedToGame()
    {
        SoundManager.Instance.PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.PlayState);
    }


}
