using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameLevel[] levels;
    private int _currentLevelIndex = 0;
    private bool _prologue = false;
    private bool _gameOver = false;
    private bool _end = false;
    
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    void Start()
    {
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Title"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Sound", LoadSceneMode.Additive));
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
        GameManager.OnStateChange += GoToTitle;
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
        SoundManager.Instance.PlaySoundEffect("Teleport");
    }

    private void ResetLevel(GameObject player)
    {
        SoundManager.Instance.PlaySoundEffect("Death");
        player.transform.position = levels[_currentLevelIndex].spawnLocation;
        HUDManager.Instance.UpdateBubbleCount();
    }

    private void ShowPrologue(GameState gameState)
    {
        if (gameState == GameState.PrologueState)
        {
            _prologue = true;
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Prologue"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Title"));
            
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
            SoundManager.Instance.PlayMusicTrack("Gameplay BGM");
            
            
            if (_prologue)
                scenesToLoad.Add(SceneManager.UnloadSceneAsync("Prologue"));

            GameManager.Instance.SavedFish = 0;
            GameManager.Instance.LifeCounter = 3;
            
            HUDManager.Instance.Show();
            HUDManager.Instance.UpdateScore();
            GameManager.Instance.LifeCounter = 3;
            HUDManager.Instance.UpdateBubbleCount();
        }
    }

    private void GameOver(GameState gameState)
    {
        if (gameState == GameState.GameOverState)
        {
            _gameOver = true;
            _prologue = false;
            SoundManager.Instance.PlaySoundEffect("Death");
            HUDManager.Instance.Hide();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("GameOver"));
            SoundManager.Instance.PlayMusicTrack("Game Over");
            scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex].levelScene.name));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Background"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Player"));

        }
    }

    private void EndGame(GameState gameState)
    {
        if (gameState == GameState.EndingState)
        {
            _end = true;
            _prologue = false;
            HUDManager.Instance.Hide();
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Ending"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync(levels[_currentLevelIndex-1].levelScene.name));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Background"));
            scenesToLoad.Add(SceneManager.UnloadSceneAsync("Player"));
            SoundManager.Instance.PlayMusicTrack("Ending");
        }
    }

    private void GoToTitle(GameState gameState)
    {
        if (gameState == GameState.MenuState)
        {
            scenesToLoad.Add(SceneManager.LoadSceneAsync("Title"));
            SoundManager.Instance.PlayMusicTrack("Title");
            
            if(_gameOver)
                scenesToLoad.Add(SceneManager.UnloadSceneAsync("GameOver"));
            else if(_end)
                scenesToLoad.Add(SceneManager.UnloadSceneAsync("Ending"));

            _prologue = false;
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
