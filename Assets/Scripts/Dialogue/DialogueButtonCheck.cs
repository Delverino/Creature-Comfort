using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonCheck : MonoBehaviour
{
    public DialogueTrigger trigger;
    private bool triggerable;
    
    void Update()
    {
        if (triggerable && Input.GetKeyDown(KeyCode.E))
        {
            trigger.TriggerDialogue();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            triggerable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggerable = false;
        }
    }
}
