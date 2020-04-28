using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private int destinationScene;

	public void Play(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
	public void ExitGame(){
		Debug.Log("Exiting...");
		Application.Quit();
	}
	public void LoadGame(){
		destinationScene = PlayerPrefs.GetInt("SaveL");
		SceneManager.LoadScene(destinationScene);
	}
}
