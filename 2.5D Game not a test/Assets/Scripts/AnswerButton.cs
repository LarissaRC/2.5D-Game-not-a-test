using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    public DialogueSO dialogue;
    public TextMeshProUGUI answerText;

    public void SetDialogue() {
        FindObjectOfType<DialogueManager>().SetDialogue(dialogue);
    }
}
