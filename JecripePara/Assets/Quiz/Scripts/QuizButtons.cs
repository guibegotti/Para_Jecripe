using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizButtons : MonoBehaviour {
	
	GameObject instructions;
	GameObject canvas;
	GameObject gameOverCanvas;
	Quiz quiz;
	Text finalPoints;
	public bool ana;
	
	public Text pointsText;
	int points = 0;
	
	void Update(){
		
		if(quiz.timeLeft <= 0.0f && canvas.activeSelf){
			GameOver();
		}	
		if(ana){
			GameOver();
		}
	}
	
	void Start(){
		instructions = GameObject.Find ("Instructions");
		canvas = GameObject.Find ("Canvas");
		quiz = GameObject.Find ("QuizScript").GetComponent<Quiz>();
		gameOverCanvas = GameObject.Find ("GameOverCanvas");
		finalPoints = GameObject.Find ("FinalPoints").GetComponent<Text>();
		
		pointsText.text = "PONTOS\n" + 0;
		canvas.SetActive(false);
		gameOverCanvas.SetActive(false);
		
	}

	
	public void StartGame(){
		instructions.SetActive(false);
		canvas.SetActive(true);
		quiz.ResetCountDown();
		
	}
	
	public void GameOver(){
		canvas.SetActive(false);
		gameOverCanvas.SetActive(true);
		finalPoints.text = "SUA PONTUAÇÃO:\n" + points.ToString();
	}
	
	public void ChangeScore(int p){
		points += p;
		pointsText.text = "PONTOS\n" + points.ToString();
	}
	
	public void BackToMenu(){
		Application.LoadLevel("PlayScene");
	}
	
	public void Reload (){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	
	
	
	
	


}
