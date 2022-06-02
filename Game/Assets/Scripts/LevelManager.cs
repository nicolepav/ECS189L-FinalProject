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
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Background"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Player", LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Sound", LoadSceneMode.Additive));
    }
    
    void Awake()
    {
        GameManager.OnLevelChange += ChangeLevel;
    }

    private void ChangeLevel(GameObject player)
    {
        _currentLevelIndex++;
        scenesToLoad.Add(SceneManager.LoadSceneAsync(levels[_currentLevelIndex].levelScene.name, LoadSceneMode.Additive));
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(levels[_currentLevelIndex].levelScene.name));
        scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex-1].levelScene.name));
        player.transform.position = levels[_currentLevelIndex].spawnLocation;
    }
    
}
