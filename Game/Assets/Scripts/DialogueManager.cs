using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private const float OpenTime = 0.25f; 
    private const float CloseTime = 0.5f;
    private const float TextTransitionTime = 0.5f;

    public static DialogueManager Instance;
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    private int _activeMessage = 0;
    private Message[] _messages;
    private Actor[] _actors;
    
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        _messages = messages;
        _actors = actors;
        _activeMessage = 0;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, OpenTime);
        GameManager.Instance.UpdateState(GameState.DialogueState);
    }

    void DisplayMessage()
    {
        Message messageToDisplay = _messages[_activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = _actors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.actorImage;
        
        AnimateText();
    }

    void NextMessage()
    {
        _activeMessage++;
        if (_activeMessage < _messages.Length)
        {
            DisplayMessage();
        }
        else
        {
            backgroundBox.LeanScale(Vector3.zero, CloseTime).setEaseInOutExpo();
            GameManager.Instance.UpdateState(GameState.PlayState);
            GameManager.Instance.SavedFish++;
            Debug.Log(GameManager.Instance.SavedFish);
        }
    }

    void AnimateText()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, TextTransitionTime);
    }
    
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        if (GameManager.Instance.GetState() == GameState.DialogueState && Input.GetButtonDown("Fire1"))
        {
            NextMessage();
        }
    }
}
