using UnityEngine;
using System.Collections;

public class DialogueContactCheck : MonoBehaviour
{
    public DialogueTrigger trigger;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !trigger.alreadyTriggered)
        {
            trigger.TriggerDialogue();
        }
    }
}
