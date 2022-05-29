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
    public static bool isActive = false;
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
    }
    
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        _messages = messages;
        _actors = actors;
        _activeMessage = 0;
        isActive = true;
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, OpenTime);
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
            isActive = false;
        }
    }

    void AnimateText()
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, TextTransitionTime);
        // LeanTween.textAlpha(actorName.rectTransform, 0, 0);
        // LeanTween.textAlpha(actorName.rectTransform, 1, TextTransitionTime);
    }
    
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isActive)
        {
            NextMessage();
        }
    }
}
