using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Banggg");

            SceneManager.LoadSceneAsync("Gameplay");

        }
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
