using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    //The final dialogue configured: name, sentences[]
    public Dialogue dialogue;

    public void TriggerDialogue(Text name, Text text)
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue,name,text);
    }
    
}
