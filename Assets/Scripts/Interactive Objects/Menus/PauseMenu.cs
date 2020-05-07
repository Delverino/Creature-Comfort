﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject PMenuUI;
	public GameObject AudioSrc;
    private int sceneID; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
        	if(isPaused){
        		Resume();
        	}
        	else{
        		Pause();
        	}
        }
    }
    public void Resume(){
    	PMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	isPaused = false;
    }
    void Pause(){
    	PMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	isPaused = true;
    }
	public void ExitGame(){
		Debug.Log("Exiting...");
		Application.Quit();
	}

    public void SaveGame(){
        sceneID = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SaveL", sceneID);
    }

	public void YesMusic(){
		AudioSrc.SetActive(true);
	}
	public void NoMusic(){
		AudioSrc.SetActive(false);
	}
}