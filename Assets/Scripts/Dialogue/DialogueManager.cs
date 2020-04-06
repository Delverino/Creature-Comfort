using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Canvas canvas;
    
    // public Text nameText;
    public Text dialogueText;

    // private Queue<string> names;
    private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
        // names = new Queue<string>();
        sentences = new Queue<string>();
        canvas.GetComponent<Canvas> ().enabled = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue");
        canvas.GetComponent<Canvas> ().enabled = true;
        
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

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            canvas.GetComponent<Canvas> ().enabled = false;
            return;
        }

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
