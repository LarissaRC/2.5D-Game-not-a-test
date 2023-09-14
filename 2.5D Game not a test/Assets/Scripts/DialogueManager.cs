using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Image actorProfile;
    [SerializeField] private TextMeshProUGUI actorNameText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject optionOneButton;
    [SerializeField] private GameObject optionTwoButton;

    private string[] currentMessages;
    private int activeMessage = 0;
    public static bool isActive = false;

    private string fullText;
    private string partialText;
    private float typingSpeed = 0.025f;
    private bool isTyping = false;
    private Coroutine currentTypingCoroutine;

    public void OpenDialogue(DialogueSO dialogue) {
        currentMessages = dialogue.dialogueTexts;
        actorNameText.text = dialogue.actorName;
        actorProfile.sprite = dialogue.actorProfile;
        activeMessage = 0;
        isActive = true;
        dialogueBox.SetActive(true);

        DisplayMessage();
    }

    private void DisplayMessage() {
        print(currentMessages);
        string messageToDisplay = currentMessages[activeMessage];
        print("A");
        
        fullText = messageToDisplay;

        currentTypingCoroutine = StartCoroutine(TypeText());
    }

    private void UpdateMessageText(string text) {
        messageText.text = text;
    }

    public void NextMessage() {
        if(!isTyping) {
            HideNextButton();
            activeMessage++;
            if(activeMessage < currentMessages.Length) {
                DisplayMessage();
            } else {
                isActive = false;
                dialogueBox.SetActive(false);
            }
        } else {
            StopCoroutine(currentTypingCoroutine);
            UpdateMessageText(fullText);
            ShowNextButton();
            isTyping = false;
        }
        
    }

    IEnumerator TypeText()
    {
        print("B");
        isTyping = true;
        partialText = "";
        foreach (char letter in fullText)
        {
            print("C");
            partialText += letter;
            UpdateMessageText(partialText);
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
        ShowNextButton();
    }

    private void ShowNextButton() {
        nextButton.SetActive(true);
    }

    private void HideNextButton() {
        nextButton.SetActive(false);
    }
}
