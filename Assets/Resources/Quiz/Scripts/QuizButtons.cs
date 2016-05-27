using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizButtons : MonoBehaviour 
{

	public Text pointsText;
	public bool setGameOver;

	private	Quiz quiz;
	private Text finalPoints;
	private Text warningText;
	private StoreDataContainer sD;

	private int points = 0;
	private int countingQ = 1;

	private GameObject canvas;
	private GameObject gameOverCanvas;
	private GameObject instructions;


	/// <summary>
	/// 
	/// </summary>
	void Update()
	{

		if((quiz.timeLeft <= 0.0f && canvas.activeSelf ) || (countingQ>10))
		{
			GameOver();
		}	
		if(setGameOver)
		{
			GameOver();
		}
	}


	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start()
	{
        Time.timeScale = 1;
        instructions = GameObject.Find ("Instructions");
		canvas = GameObject.Find ("Canvas");
		quiz = GameObject.Find ("QuizScript").GetComponent<Quiz>();
		gameOverCanvas = GameObject.Find ("GameOverCanvas");
		finalPoints = GameObject.Find ("FinalPoints").GetComponent<Text>();
		warningText = GameObject.Find ("WarningText").GetComponent<Text>();

		pointsText.text = "0";
		QuestionOnButton.correctNumb = 0 ;
		canvas.SetActive(false);
		gameOverCanvas.SetActive(false);

	}

	/// <summary>
	/// Starts the game.
	/// </summary>
	public void StartGame()
	{
		instructions.SetActive(false);
		canvas.SetActive(true);
		quiz.ResetCountDown();
	}

	/// <summary>
	/// Set Active Game Over.
	/// </summary>
	public void GameOver()
	{
		canvas.SetActive(false);
		gameOverCanvas.SetActive(true);
		finalPoints.text ="Você ganhou \n"+ points.ToString() + "\n moedas";


		if (QuestionOnButton.correctNumb<= 4 )
		{
			warningText.text  = "Achou que ia ser facil, nao? Leia os conteudos do jogo para melhorar sua pontuaçao. ";
		}
		else
		{
			if (QuestionOnButton.correctNumb > 4 && QuestionOnButton.correctNumb <= 6)
			{
				warningText.text  = "Foi bem, mas sabemos que pode fazer melhor, de uma lida nos conteudos!";
			}
			else
			{
				warningText.text  = "Excelente desempenho, continue assim!";
			}
		}
	}

	/// <summary>
	/// Changes the score and counting number of questions
	/// </summary>
	/// <param name="p">P.</param>
	public void ChangeScore(int p)
	{
		points += p;
		sD = StoreDataContainer.Load();
		sD.storeObjects[0].coin += p;
		sD.Save();
		pointsText.text = points.ToString();

		countingQ += 1;
		quiz.questioNumb.text = countingQ.ToString();
	}

	/// <summary>
	/// Backs to menu.
	/// </summary>
	public void BackToMenu()
	{
		Application.LoadLevel("PlayScene");
	}

	/// <summary>
	/// Reload the Scene.
	/// </summary>
	public void Reload ()
	{
		Application.LoadLevel(Application.loadedLevel);
	}


}
