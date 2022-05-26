using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public static int levelIndex = 1;
    
    public static event Action<GameObject> onLevelChange;

    void Awake()
    {
        Instance = this;
    }
    public void UpdateState(GameObject player)
    {
        Debug.Log("State Update");
        onLevelChange?.Invoke(player);
    }

}
