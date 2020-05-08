using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButtonCheck : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueManager dm;
    private bool triggerable;
    
    void Update()
    {
        //Debug.Log(dm.dialogueStarted);
        if (triggerable && Input.GetKeyDown(KeyCode.Space) && !dm.dialogueStarted)
        {
            Debug.Log("triggering dialogue");
            trigger.TriggerDialogue();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("triggering");
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
