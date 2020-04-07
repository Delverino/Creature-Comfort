using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // TODO: make logic to track how many times been visited 
    // so can use same phone for multiple conversations
    public Dialogue dialogue;
    private int decr_coin = -1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        	// update coin values
            if (ScoreCoins.instance.score > 0)
            {
                ScoreCoins.instance.UpdateScore(decr_coin);
            	TriggerDialogue();
        	}
            else 
            {
                // TODO: issue message if not enough coins
            }
        }
    }

    public void TriggerDialogue()
    {
        Debug.Log("Triggering dialogue");
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
