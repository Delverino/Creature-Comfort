using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCoins : MonoBehaviour
{	
	public static ScoreCoins instance;
	public Text text;
	public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("TotalC");
        text.text = "x" + score.ToString();
        if(instance == null)
        {
        	instance = this;
        }
    }

    public void UpdateScore(int num)
    {
    	score += num;
        PlayerPrefs.SetInt("TotalC", score);
    	text.text = "x" + score.ToString();
    }
}
