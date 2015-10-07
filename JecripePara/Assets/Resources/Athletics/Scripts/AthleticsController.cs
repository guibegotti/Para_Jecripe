using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AthleticsController : MonoBehaviour {


	GameObject gameOverCanvas;
	GameObject canvas;
	public Text result;
	//AthleticsSounds Sounds;
	
	public bool gameOver;

	
	void Start () {
		
		gameOverCanvas = GameObject.Find ("GameOverCanvas");
		canvas = GameObject.Find("Canvas");
		//Sounds = GameObject.Find ("Sounds").GetComponent<AthleticsSounds>();
		
		gameOverCanvas.SetActive(false);
		
	
	}
	
	void StartGame(){
		
		
	}
	
	public void Reload(){
		
		Application.LoadLevel(Application.loadedLevel);
	
	}
	
	public void BackToMenu(){
		Application.LoadLevel ("PlayAthletics");
	}
	

	
	public void GameOver(string loser, string winner, float loserTime, float winnerTime){
	
		gameOverCanvas.SetActive(true);
		canvas.SetActive(false);
		result.text = "RESULTADOS\n  \n1. " + winner + " -  " + winnerTime.ToString ("0.0") + "s" + 
			"\n2. " + loser + " - " + loserTime.ToString ("0.0") + "s";
									//"\n3. " + third + " - " + thirdTime.ToString("0.0") + "s" +
									//"\n4. " + fourth + " - " + fourthTime.ToString("0.0") + "s";
	}
}
