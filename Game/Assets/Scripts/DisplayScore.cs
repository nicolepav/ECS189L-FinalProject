using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    public static DisplayScore Instance;

    public TextMeshProUGUI scoreText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        
    }


    void Awake()
    {
        Instance = this;
    }

    //This function can be invoked by the player script to update the score that is displayed.
    public void SetScoreText(int level)
    {
        scoreText.text = "Score: " + level.ToString();
    }
}
