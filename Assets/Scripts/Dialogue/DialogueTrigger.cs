using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // TODO: make logic to track how many times been visited 
    // so can use same phone for multiple conversations
    public Dialogue dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        Debug.Log("Triggering dialogue");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
