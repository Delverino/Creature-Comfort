using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject PMenuUI;
	public GameObject AudioSrc;
    private int sceneID;

    public AudioMixer mixer;

    private void Start()
    {
        AudioSrc = GameObject.FindGameObjectWithTag("Music");
    }

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

	public void YesMusic()
    {
        mixer.SetFloat("MusicVol", 0);
    }

	public void NoMusic()
    {
        mixer.SetFloat("MusicVol", -80);
    }
}
