using UnityEngine;
using System.Collections;

public class DialogueContactCheck : MonoBehaviour
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
