using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // public Canvas canvas;
    // public Text nameText;
    public Text dialogueText;

    // private Queue<string> names;
    private Queue<string> sentences;
    private Queue<Canvas> bubbles;
    private bool dialogueStarted;

    public TransformPlayer tp;
    public DialogueMaster master;
    
    // Start is called before the first frame update
    void Start()
    {
        // names = new Queue<string>();
        sentences = new Queue<string>();
        bubbles = new Queue<Canvas>();
        // canvas.GetComponent<Canvas> ().enabled = false;
        dialogueStarted = false;
    }

    void Update()
    {
        if (dialogueStarted && Input.anyKeyDown) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue");
        Time.timeScale = 0f;
        // TODO: make this happen for each canvas each time
        //canvas.GetComponent<Canvas>().enabled = true; 
        
        // prevents restarting dialogue in the middle
        if (!dialogueStarted) {
            // names.Clear();
            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            // foreach(string name in dialogue.names)
            // {
            //     names.Enqueue(name);
            // }
            foreach (Canvas canvas in dialogue.canvases)
            {
                bubbles.Enqueue(canvas);
            }

            dialogueStarted = true;
            tp.on = false;
            Debug.Log(tp.on);

            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        master.shutBubbles();

        if (sentences.Count == 0)
        {
            master.shutBubbles();
            // canvas.GetComponent<Canvas>().enabled = false;
            dialogueStarted = false;
            tp.on = true;
            Debug.Log(tp.on);
            Time.timeScale = 1f;
            return;
        }

        Canvas bubble = bubbles.Dequeue();
        bubble.GetComponent<Canvas>().enabled = true;
        Debug.Log(bubble);

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        // string name = names.Dequeue();
        // nameText.text = name;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
}
