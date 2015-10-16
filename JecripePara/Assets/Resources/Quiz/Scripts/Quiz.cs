using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Quiz :QuestionLoader
{

	//initiation Variables
	public Text time;
	public Slider timeBar;

	public int points;

	// Set the time to countdown.
	public float timeLeft = 90;
	public string Correct;

	public Text questionText;
	public Text A1;
	public Text A2;
	public Text A3;
	public Text A4;
	public Text pointsText;
	public Text questioNumb;

	//hold one question and answer
	private string Question;
	private string AnswerA;
	private string AnswerB;
	private string AnswerC;
	private string AnswerD;

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		
		//CountDown
		timeLeft -= Time.deltaTime;
		time.text = timeLeft.ToString ("0.0");

		timeBar.value += Time.deltaTime;
		
		A1.text = QuizSolutionA ();
		A2.text = QuizSolutionB ();
		A3.text = QuizSolutionC ();
		A4.text = QuizSolutionD ();
		Correct = QuizCorrectSol();
		
		questionText.text = QuizQuestion ();
		
		
	}

	/// <summary>
	/// Resets the count down.
	/// </summary>
	public void ResetCountDown(){
		timeLeft = 90;
	}

}
