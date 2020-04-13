using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAreaCheck : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !trigger.alreadyTriggered)
        {
            trigger.TriggerDialogue();
        }
    }
}
