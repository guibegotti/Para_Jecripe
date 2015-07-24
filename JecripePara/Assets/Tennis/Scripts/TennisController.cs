using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TennisController : MonoBehaviour
{

	public Text countDownText;
	public Text pointsText;
	public Text resultText;
	TennisSounds TennisSounds;
	GameObject gameOverCanvas;
	GameObject canvas;
	bool countDown;
	float time1 = 90;
	int points = 0;
	GameObject atiraBolas;
	GameObject SomFundo;
	GameObject buttons;
	GameObject clickToPlayCanvas;
	
	void Start ()
	{
		gameOverCanvas = GameObject.Find ("GameOverCanvas");
		gameOverCanvas.SetActive (false);
		
		TennisSounds = GameObject.Find ("Sounds").GetComponent<TennisSounds> ();
		canvas = GameObject.Find ("Canvas");
		atiraBolas = GameObject.Find ("atiraBolas");
		SomFundo = GameObject.Find ("SomFundo");
		clickToPlayCanvas = GameObject.Find ("ClickToPlayCanvas");
		
		addPoints (0);
	}
	
	void Update ()
	{
	
		if (countDown) {
			time1 -= Time.deltaTime;
			countDownText.text = time1.ToString ("0.0");
			
			if (time1 <= 0) {
				GameOver ();
			}
		}
	}
	
	public void StartGame ()
	{
	
		atiraBolas.GetComponent<atiraBolas> ().comecar = true;
		DestroyImmediate (clickToPlayCanvas);
		SetCountDown ();
		TennisSounds.PlaySound(TennisSounds.background);
		
	}
	
	void GameOver ()
	{
	
		TennisSounds.StopPlaying(TennisSounds.background);
		TennisSounds.PlaySound(TennisSounds.applause);
		Time.timeScale = 0;
		gameOverCanvas.SetActive (true);
		canvas.SetActive (false);
		resultText.text = "Parabéns!\nVocê fez " + points + " pontos.";
		
	}
	
	public void SetCountDown ()
	{
		countDown = true;
	}
	
	public void addPoints (int pointsToAdd)
	{
		
		points += pointsToAdd;
		pointsText.text = "PONTOS\n" + points;
	}
	
	public void Reload ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void BackToMenu ()
	{
		Application.LoadLevel ("PlayTennis");
	}
	
}
