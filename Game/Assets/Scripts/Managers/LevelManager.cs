using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameLevel[] levels;
    private int _currentLevelIndex = 0;
    private bool _readPrologue = false;
    
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    void Start()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Title"));
        HUDManager.Instance.Hide();
    }
    
    void Awake()
    {
        GameManager.OnLevelChange += ChangeLevel;
        GameManager.OnDeath += ResetLevel;
        GameManager.OnStateChange += StartGame;
        GameManager.OnStateChange += GameOver;
        GameManager.OnStateChange += ShowPrologue;
        GameManager.OnStateChange += EndGame;
    }

    private void ChangeLevel(GameObject player)
    {
        _currentLevelIndex++;
        if (_currentLevelIndex == levels.Length)
        {
            GameManager.Instance.UpdateState(GameState.EndingState);
            return;
        }
        scenesToLoad.Add(SceneManager.LoadSceneAsync(levels[_currentLevelIndex].levelScene.name, LoadSceneMode.Additive));
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(levels[_currentLevelIndex].levelScene.name));
        scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex-1].levelScene.name));
        player.transform.position = levels[_currentLevelIndex].spawnLocation;
    }

    private void ResetLevel(GameObject player)
    {
        player.transform.position = levels[_currentLevelIndex].spawnLocation;
        HUDManager.Instance.UpdateBubbleCount();
    }

    private void GameOver(GameState gameState)
    {
        if (gameState == GameState.GameOverState)
        {
            HUDManager.Instance.Hide();
            
            // Gameover Scene
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Title"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex].levelScene.name));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Background"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Player"));
            
            // _currentLevelIndex = 0;
        }
    }

    private void StartGame(GameState gameState)
    {
        if (gameState == GameState.PlayState)
        {
            Physics2D.gravity = new Vector2(0f, -9.81f);
            
            _currentLevelIndex = 0;
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Background"));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Player", LoadSceneMode.Additive));
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Sound", LoadSceneMode.Additive));
            
            if (!_readPrologue)
                scenesToLoad.Add(SceneManager.UnloadSceneAsync("Prologue"));

            GameManager.Instance.SavedFish = 0;
            GameManager.Instance.LifeCounter = 3;
            
            HUDManager.Instance.Show();
            HUDManager.Instance.UpdateScore();
            GameManager.Instance.LifeCounter = 3;
            HUDManager.Instance.UpdateBubbleCount();
        }
    }

    private void ShowPrologue(GameState gameState)
    {
        if (gameState == GameState.PrologueState)
        {
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Prologue"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Title"));
            _readPrologue = true;
        }
    }

    private void EndGame(GameState gameState)
    {
        if (gameState == GameState.EndingState)
        {
            HUDManager.Instance.Hide();
            
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Ending"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex-1].levelScene.name));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Background"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Player"));
        }
    }

    // for awaiting async loading. game works as is right now however
    private IEnumerator LoadScene(AsyncOperation sceneLoad)
    {
        while (!sceneLoad.isDone)
        {
            yield return null;
        }
    }
}
