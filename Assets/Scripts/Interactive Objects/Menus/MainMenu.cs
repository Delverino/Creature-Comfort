using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private int destinationScene;

	public void Play(){
		destinationScene = PlayerPrefs.GetInt("SaveL");
		SceneManager.LoadScene(destinationScene);
	}
	public void ExitGame(){
		Debug.Log("Exiting...");
		Application.Quit();
	}
	public void NewGame(){
		PlayerPrefs.SetInt("SaveL",1);
		destinationScene = PlayerPrefs.GetInt("SaveL");
		SceneManager.LoadScene(destinationScene);
	}
}
