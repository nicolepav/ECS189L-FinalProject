using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerCommand;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject _camController;
    

    void Start()
    {
        
    }
 
    void Update()
    {
        // respawn
        if (player.transform.position.x > 50 || player.transform.position.x < -50 || player.transform.position.y > 30 ||
            player.transform.position.y < -30)
        {
            GameManager.Instance.ResetLevel(player);
        }
    }

    public CameraController GetCamController()
    {
        _camController = GameObject.Find("CameraController");
        return _camController.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("levelTrigger"))
        {
            Debug.Log("Level Trigger activated");
            GameManager.Instance.UpdateLevel(player);
            
        }
        else if (col.CompareTag("fish"))
        {
            Debug.Log("fish triggered");
            col.gameObject.SetActive(false);
            GameManager.Instance.SavedFish++;
            HUDManager.Instance.UpdateScore();
            FindObjectOfType<SoundManager>().PlaySoundEffect("Save Fish");
        }
    }
}
