using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class DialogueBubble
{
    public GameObject objectToShow;
    public DialogueTrigger dialoguetrigger; //may be the same as objectToShow
    public Text nameText;
    public Text dialogueText;
}
