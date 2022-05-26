using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    // Start is called before the first frame update
    void Start()
    {
        // currently in gameplay scene
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Background"));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Additive));
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Player", LoadSceneMode.Additive));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
