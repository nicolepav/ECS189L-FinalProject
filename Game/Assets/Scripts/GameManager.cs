using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public static event Action<GameObject> OnLevelChange;
    public static event Action<GameObject> OnDeath;
    public static event Action<GameState> OnStateChange;
    public GameState State;
    public int SavedFish { get; set; }
    public int LifeCounter { get; set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateState(GameState.MenuState);
        SavedFish = 0;
        LifeCounter = 3;
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

    public void ResetLevel(GameObject player)
    {
        LifeCounter--;
        if (LifeCounter <= 0)
            UpdateState(GameState.GameOverState);
        else
            OnDeath?.Invoke(player);
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
    DialogueState,
    GameOverState
}