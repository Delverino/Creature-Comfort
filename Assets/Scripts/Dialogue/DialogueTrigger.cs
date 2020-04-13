using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // TODO: make logic to track how many times been visited 
    // so can use same phone for multiple conversations
    public Dialogue dialogue;
    public bool alreadyTriggered;

    void Start()
    {
        alreadyTriggered = false;
    }
    
    public void TriggerDialogue()
    {
        Debug.Log("Triggering dialogue");
        alreadyTriggered = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
