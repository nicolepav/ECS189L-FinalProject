using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prologue : MonoBehaviour
{
    
    public void ProceedToGame()
    {
        GameManager.Instance.UpdateState(GameState.PlayState);
    }


}
