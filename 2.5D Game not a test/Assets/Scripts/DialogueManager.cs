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

    private Message[] currentMessages;
    private int activeMessage = 0;
    public static bool isActive = false;

    private string fullText;
    private string partialText;
    private float typingSpeed = 0.025f;
    private bool isTyping = false;
    private Coroutine currentTypingCoroutine;

    public void OpenDialogue(Message[] messages) {
        currentMessages = messages;
        activeMessage = 0;
        isActive = true;
        dialogueBox.SetActive(true);

        DisplayMessage();
    }

    private void DisplayMessage() {
        Message messageToDisplay = currentMessages[activeMessage];
        actorNameText.text = messageToDisplay.actorName;
        actorProfile.sprite = messageToDisplay.actorProfile;
        
        fullText = messageToDisplay.message;

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
        isTyping = true;
        partialText = "";
        foreach (char letter in fullText)
        {
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
