using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAreaCheck : MonoBehaviour
{
    public DialogueTrigger trigger;
    public bool triggerByPlayer;
    public bool triggerByAnimal;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((triggerByPlayer && collision.gameObject.tag == "Player") 
              || (triggerByAnimal && collision.gameObject.tag == "Animal")) 
              && !trigger.alreadyTriggered)
        {
            trigger.TriggerDialogue();
        }
    }
}
