using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : MonoBehaviour
{
    [SerializeField] private DialogueSO dialogue;

    public void Interact() {
        FindObjectOfType<DialogueManager>().OpenDialogue(dialogue);
    }

}
