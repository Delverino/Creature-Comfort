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
        bubble.GetComponentInChildren<Text>().text = sentence;
        // bubble.GetComponentInChildren<Text>().text = "";

        // foreach(char letter in sentence.ToCharArray())
        // {
        //     bubble.GetComponentInChildren<Text>().text += letter;
        //     yield return null;
        // }
        char[] sentenceArray = sentence.ToCharArray();

        for (int i = 0; i < sentence.Length; i++)
        {
            // char test = bubble.GetComponentInChildren<Text>().text[0];
            // bubble.GetComponentInChildren<Text>().text += "<color=#038940>" + test + "</color>";
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
            

            // bubble.GetComponentInChildren<Text>().text = 
            //     bubble.GetComponentInChildren<Text>().text.Replace(
            //         bubble.GetComponentInChildren<Text>().text[i].ToString(), 
            //         "<color=#000000>" 
            //             + bubble.GetComponentInChildren<Text>().text.ToCharArray()[i].ToString() 
            //             + "</color>"
            //         );
            yield return null;
        }

        // public UnityEngine.UI.Text myText;
        // // Get index of character.
        // int charIndex = myText.text.IndexOf ("S");
        // // Replace text with color value for character.
        // myText.text = myText.text.Replace (myText.text [charIndex].ToString (), "<color=#000000>" + myText.text [charIndex].ToString () + "</color>");
        //     
    }

    void shutBubbles()
    {
        foreach (Canvas canvas in dialogueCanvases)
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
    }
}
