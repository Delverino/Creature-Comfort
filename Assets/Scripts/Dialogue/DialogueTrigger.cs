using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
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
