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
    public bool dialogueStarted; // if currently engaged in dialogue
    private int secondsSinceClick; // counts how long it's been since user last 
                                   // moved through dialogue

    public TransformPlayer tp;

    float afkTime = 5;
    float endAFK = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        bubbles = new Queue<Canvas>();
        dialogueStarted = false;
        secondsSinceClick = 0;
        shutBubbles();
    }

    void Update()
    {
        // Debug.Log(dialogueStarted);
        if (dialogueStarted && 
            ((Input.GetKeyDown(KeyCode.Return)) 
             || Input.GetKeyDown(KeyCode.Space)
             || Time.realtimeSinceStartup >= endAFK ))
        {
            DisplayNextSentence();
        }

        if(dialogueStarted &&
            ((Input.GetKeyDown(KeyCode.Return))
             || Input.GetKeyDown(KeyCode.Space)))
        {
            clickSource.click.play();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        
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

        endAFK = afkTime + Time.realtimeSinceStartup;

        if (sentences.Count == 0)
        {
            shutBubbles();
            StartCoroutine(DelayRepeatDialogue());
            tp.on = true;
            return;
        }

        Canvas bubble = bubbles.Dequeue();
        bubble.GetComponent<Canvas>().enabled = true;

        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence, bubble));
    }

    IEnumerator TypeSentence(string sentence, Canvas bubble)
    {
        bubble.GetComponentInChildren<Text>().text = sentence;

        char[] sentenceArray = sentence.ToCharArray();

        for (int i = 0; i < sentence.Length; i++)
        {
            bubble.GetComponentInChildren<Text>().text = "<color=#000>";
            for (int j = 0; j <= i; j++)
            {
                bubble.GetComponentInChildren<Text>().text += sentenceArray[j];
            }
            bubble.GetComponentInChildren<Text>().text += "</color>";
            for (int k = i + 1; k < sentence.Length; k++)
            {
                bubble.GetComponentInChildren<Text>().text += sentenceArray[k];
            }
            
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
    
    IEnumerator DelayRepeatDialogue()
    {
        yield return new WaitForSeconds(1);
        dialogueStarted = false;
    }
}
