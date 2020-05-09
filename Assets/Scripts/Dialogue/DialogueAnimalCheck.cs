using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimalCheck : MonoBehaviour
{
    public DialogueTrigger trigger;
    private bool triggerable;
    
    void Update()
    {
        if (triggerable && Input.GetKeyDown(KeyCode.Space))
        {
            trigger.TriggerDialogue();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Animal")
        {
            Debug.Log("Triggerable true");
            triggerable = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Animal")
        {
            Debug.Log("Triggerable false");
            triggerable = false;
        }
    }
}
