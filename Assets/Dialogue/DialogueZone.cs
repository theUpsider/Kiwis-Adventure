using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueZone : MonoBehaviour
{
    public DialogueBubble dialoguebubble;


    public void OnTriggerEnter2D(Collider2D col)
    {
        {
            dialoguebubble.objectToShow.SetActive(true); //activate dialogue
            dialoguebubble.dialoguetrigger.TriggerDialogue(dialoguebubble.nameText, dialoguebubble.dialogueText);
        }
    }
}
