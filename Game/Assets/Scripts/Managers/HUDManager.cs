using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI scoreText;

    //For every life the player has left, a bubble is displayed
    [SerializeField] GameObject livesBubble1;
    [SerializeField] GameObject livesBubble2;
    [SerializeField] GameObject livesBubble3;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateScore()
    {
        scoreText.text = "Fish saved: " + GameManager.Instance.SavedFish;
    }
    

    //This function updates the number of bubbles displayed based on the number of lives the player has left
    public void UpdateBubbleCount()
    {
        switch (GameManager.Instance.LifeCounter)
        {
        case 3:
            livesBubble1.SetActive(true);
            livesBubble2.SetActive(true);
            livesBubble3.SetActive(true);
            break;
        case 2:
            livesBubble1.SetActive(true);
            livesBubble2.SetActive(true);
            livesBubble3.SetActive(false);
            break;
        case 1:
            livesBubble1.SetActive(true);
            livesBubble2.SetActive(false);
            livesBubble3.SetActive(false);
            break;
        default:
            livesBubble1.SetActive(false);
            livesBubble2.SetActive(false);
            livesBubble3.SetActive(false);
            break;
        }
    }



    public void Hide()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
