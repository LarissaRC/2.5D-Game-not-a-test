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
    [SerializeField] private Button[] answersTexts;
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject optionOneButton;
    [SerializeField] private GameObject optionTwoButton;

    private DialogueSO dialogue;
    private string[] currentMessages;
    private int activeMessage = 0;
    public static bool isActive = false;

    private string fullText;
    private string partialText;
    private float typingSpeed = 0.025f;
    private bool isTyping = false;
    private Coroutine currentTypingCoroutine;

    public void SetDialogue(DialogueSO dialogue) {

        if(dialogue.isLastDialogue) {
            dialogueBox.SetActive(false);
            return;
        }

        this.dialogue = dialogue;

        currentMessages = dialogue.dialogueTexts;
        actorNameText.text = dialogue.actorName;
        actorProfile.sprite = dialogue.actorProfile;
        activeMessage = 0;
        isActive = true;
        dialogueBox.SetActive(true);

        HideAnswers();

        DisplayMessage();
    }

    private void DisplayMessage() {
        string messageToDisplay = currentMessages[activeMessage];
        
        fullText = messageToDisplay;

        currentTypingCoroutine = StartCoroutine(TypeText());
    }

    private void DisplayAnswers() {
        for (int i = 0; i < answersTexts.Length; i++)
        {
            if(i < dialogue.answers.Length) {
                answersTexts[i].GetComponent<AnswerButton>().answerText.text = dialogue.answers[i].playerAnswer;
                answersTexts[i].GetComponent<AnswerButton>().dialogue = dialogue.answers[i];
                answersTexts[i].gameObject.SetActive(true);
            } else {
                answersTexts[i].gameObject.SetActive(false);
            }
        }
    }

    private void HideAnswers() {
        for (int i = 0; i < answersTexts.Length; i++)
        {
            answersTexts[i].GetComponent<AnswerButton>().answerText.text = "";
            answersTexts[i].gameObject.SetActive(false);
        }
    }

    private void UpdateMessageText(string text) {
        messageText.text = text;
    }

    public void NextMessage() {
        if(!isTyping) {
            HideNextButton();
            HideAnswers();
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

            if(activeMessage == currentMessages.Length - 1) {
                DisplayAnswers();
            } else {
                ShowNextButton();
            }
            
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
        
        if(activeMessage == currentMessages.Length - 1) {
            DisplayAnswers();
        } else {
            ShowNextButton();
        }
    }

    private void ShowNextButton() {
        nextButton.SetActive(true);
    }

    private void HideNextButton() {
        nextButton.SetActive(false);
    }
}
