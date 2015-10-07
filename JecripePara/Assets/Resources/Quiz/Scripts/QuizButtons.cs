using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizButtons : MonoBehaviour 
{
	public Text pointsText;
	public bool setGameOver;

	private	Quiz quiz;
	private Text finalPoints;

	private int points = 0;

	private GameObject canvas;
	private GameObject gameOverCanvas;
	private GameObject instructions;
	

	void Update()
	{
		
		if(quiz.timeLeft <= 0.0f && canvas.activeSelf)
		{
			GameOver();
		}	
		if(setGameOver)
		{
			GameOver();
		}
	}
	
	void Start()
	{
		instructions = GameObject.Find ("Instructions");
		canvas = GameObject.Find ("Canvas");
		quiz = GameObject.Find ("QuizScript").GetComponent<Quiz>();
		gameOverCanvas = GameObject.Find ("GameOverCanvas");
		finalPoints = GameObject.Find ("FinalPoints").GetComponent<Text>();
		
		pointsText.text = "0";
		canvas.SetActive(false);
		gameOverCanvas.SetActive(false);

	}


	public void StartGame()
	{
		instructions.SetActive(false);
		canvas.SetActive(true);
		quiz.ResetCountDown();
		
	}

	
	public void GameOver()
	{
		canvas.SetActive(false);
		gameOverCanvas.SetActive(true);
		finalPoints.text ="MOEDAS\n"+ points.ToString();
	}


	public void ChangeScore(int p)
	{
		points += p;
		pointsText.text = points.ToString();
	}

	
	public void BackToMenu()
	{
		Application.LoadLevel("PlayScene");
	}


	public void Reload ()
	{
		Application.LoadLevel(Application.loadedLevel);
	}


}
