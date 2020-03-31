using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mo_Coin : MonoBehaviour
{
	public AudioSource Coin_Sound;
	
	private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Coins")){
    		Destroy(other.gameObject);
    		Coin_Sound.Play();
    	}
    }
}
