using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AthleticsController : MonoBehaviour {


	GameObject gameOverCanvas;
	GameObject canvas;
	public Text result;

	
	void Start () {
		
		gameOverCanvas = GameObject.Find ("GameOverCanvas");
		canvas = GameObject.Find("Canvas");
		
		gameOverCanvas.SetActive(false);
		
	
	}

	
	public void GameOver(string loser, string winner, float loserTime, float winnerTime){
	
		gameOverCanvas.SetActive(true);
		canvas.SetActive(false);
		
		result.text = "RESULTADOS:\n\n1. " + winner + ": " + winnerTime.ToString("0.0") + "\n2. " + loser + ": " + loserTime.ToString("0.0");
	}
}
