using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "dialogueSO", menuName = "ScriptableObjects/dialogueSO")]
public class DialogueSO : ScriptableObject
{
    public string[] dialogueTexts;
    public string playerAnswer;
    public string actorName;
    public Sprite actorProfile;
    public bool isLastDialogue;
    public DialogueSO[] answers;
}
