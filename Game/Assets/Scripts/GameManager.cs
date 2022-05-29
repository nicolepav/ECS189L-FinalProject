using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public static event Action<GameObject> OnLevelChange;
    public static event Action<GameState> OnStateChange;
    public GameState State;
    public static int levelIndex = 1;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateState(GameState.PlayState);
    }
    
    public void UpdateState(GameState newState)
    {
        State = newState;
        OnStateChange?.Invoke(newState);
    }

    public void UpdateLevel(GameObject player)
    {
        // Debug.Log("Level Update");
        OnLevelChange?.Invoke(player);
    }

    public GameState GetState()
    {
        return State;
    }
}

public enum GameState
{
    MenuState,
    PlayState,
    DialogueState
}