using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCoinCheck : MonoBehaviour
{

    private int decr_coin = -1;
    public DialogueTrigger trigger;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !trigger.alreadyTriggered)
        {
        	// update coin values
            if (ScoreCoins.instance.score > 0)
            {
                ScoreCoins.instance.UpdateScore(decr_coin);
            	trigger.TriggerDialogue();
        	}
            else 
            {
                // TODO: issue message if not enough coins
            }
        }
    }
}
