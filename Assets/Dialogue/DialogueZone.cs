using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueZone : MonoBehaviour, IManager
{
    public DialogueBubble dialoguebubble;

    public void handlePlayerInput(GameObject Player, string message)
    {
        if (message == "Enter")
        {
        Debug.Log("Display next sentance handled.");
        FindObjectOfType<DialogManager>().DisplayNextSentence();
        }
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Level.subsribe(this);
            dialoguebubble.objectToShow.SetActive(true); //activate dialogue
            dialoguebubble.dialoguetrigger.TriggerDialogue(dialoguebubble.nameText, dialoguebubble.dialogueText);
        }
        Debug.Log(this + " subsribed.");
    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            Level.unsubscribe(this);
        Debug.Log(this + " unsubsribed.");
    }


}
