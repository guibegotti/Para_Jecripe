using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TennisController : MonoBehaviour {

	public Text countDownText;
	public Text pointsText;
	public Text resultText;
	
	GameObject gameOverCanvas;
	GameObject canvas;
	
	bool countDown;
	float time1 = 90;
	int points = 0;
	
	void Start(){
		gameOverCanvas = GameObject.Find("GameOverCanvas");
		gameOverCanvas.SetActive(false);
		
		canvas = GameObject.Find ("Canvas");
		
		addPoints(0);
	}
	
	
	void Update(){
	
		if (countDown){
			time1 -= Time.deltaTime;
			countDownText.text = time1.ToString("0.0");
			
			if (time1 <= 0){
				GameOver();
			}
		}
	}
	
	void GameOver(){
	
		Time.timeScale = 0;
		gameOverCanvas.SetActive(true);
		canvas.SetActive(false);
		resultText.text = "Parabéns!\nVocê fez " + points + " pontos.";
		
	}
	
	public void SetCountDown(){
		countDown = true;
	}
	
	public void addPoints(int pointsToAdd){
		
		points += pointsToAdd;
		pointsText.text = "PONTOS\n" + points;
	}
	
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void BackToMenu(){
		Application.LoadLevel("PlayTennis");
	}
	
}
