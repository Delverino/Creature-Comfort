using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Canvas[] dialogueCanvases; // all speech bubbles in scene
    private Text dialogueText; // text to print in one bubble

    private Queue<string> sentences; // all sentences in THIS dialogue
    private Queue<Canvas> bubbles; // all speech bubbles in THIS dialogue
    private bool dialogueStarted; // if currently engaged in dialogue

    public TransformPlayer tp;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        bubbles = new Queue<Canvas>();
        dialogueStarted = false;
        shutBubbles();
    }

    void Update()
    {
        if (dialogueStarted && Input.anyKeyDown) {
            DisplayNextSentence();
            clickSource.click.play();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue");
        Time.timeScale = 0f;
        
        // prevents restarting dialogue in the middle
        if (!dialogueStarted) {
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            foreach(Canvas canvas in dialogue.canvases)
            {
                bubbles.Enqueue(canvas);
            }

            dialogueStarted = true;
            tp.on = false;

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        shutBubbles();

        if (sentences.Count == 0)
        {
            shutBubbles();
            dialogueStarted = false;
            tp.on = true;
            Time.timeScale = 1f;
            return;
        }

        Canvas bubble = bubbles.Dequeue();
        bubble.GetComponent<Canvas>().enabled = true;
        Debug.Log(bubble);

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, bubble));
    }

    IEnumerator TypeSentence(string sentence, Canvas bubble)
    {
        bubble.GetComponentInChildren<Text>().text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            bubble.GetComponentInChildren<Text>().text += letter;
            yield return null;
        }
    }

    void shutBubbles()
    {
        foreach (Canvas canvas in dialogueCanvases)
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
