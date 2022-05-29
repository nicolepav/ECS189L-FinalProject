using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Conversation conversation;

    private void OnTriggerEnter2D(Collider2D col)
    {
        conversation.StartDialogue();
    }
}
