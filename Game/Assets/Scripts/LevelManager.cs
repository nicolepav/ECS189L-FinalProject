using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameLevel[] levels;
    private int _currentLevelIndex = 0;
    
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    void Start()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Title"));
    }
    
    void Awake()
    {
        GameManager.OnLevelChange += ChangeLevel;
        GameManager.OnDeath += ResetLevel;
        GameManager.OnStateChange += StartGame;
        GameManager.OnStateChange += GameOver;
    }

    private void ChangeLevel(GameObject player)
    {
        _currentLevelIndex++;
        scenesToLoad.Add(SceneManager.LoadSceneAsync(levels[_currentLevelIndex].levelScene.name, LoadSceneMode.Additive));
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(levels[_currentLevelIndex].levelScene.name));
        scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex-1].levelScene.name));
        player.transform.position = levels[_currentLevelIndex].spawnLocation;
    }

    private void ResetLevel(GameObject player)
    {
        player.transform.position = levels[_currentLevelIndex].spawnLocation;
    }

    private void GameOver(GameState gameState)
    {
        if (gameState == GameState.GameOverState)
        {
            // Gameover Scene
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Title"));
            
            scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex].levelScene.name));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Background"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("HUD"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Player"));
        }
    }

    private void StartGame(GameState gameState)
    {
        if (gameState == GameState.PlayState)
        {
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Background"));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Player", LoadSceneMode.Additive));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Sound", LoadSceneMode.Additive));
            
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Title"));
        }
    }
}
