using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Conversation", menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{ 
    public Message[] messages;
    public Actor[] actors;
    public bool Spoke { get; set; }

    private void OnEnable()
    {
        Spoke = false;
    }

    public void StartDialogue()
    {
        DialogueManager.Instance.OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;
}
