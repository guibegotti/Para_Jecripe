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
	GameObject ballShooter;
	GameObject clickToPlayCanvas;
	GameObject pauseCanvas;
	public Slider timeBar;
	public GameObject timer;

	void Start ()
	{
		Time.timeScale = 1;
		gameOverCanvas = GameObject.Find ("GameOverCanvas");
		gameOverCanvas.SetActive (false);
		
		TennisSounds = GameObject.Find ("Sounds").GetComponent<TennisSounds> ();
		canvas = GameObject.Find ("Canvas");
		ballShooter = GameObject.Find ("BallShooter");
		clickToPlayCanvas = GameObject.Find ("ClickToPlayCanvas");
		pauseCanvas = GameObject.Find("PauseCanvas");
		pauseCanvas.SetActive(false);
		canvas.SetActive(false);
		
		addPoints (0);
		timer.SetActive(false);
	}
	
	void Update ()
	{
	
		if (countDown) {
			timeBar.value += Time.deltaTime;
			time1 -= Time.deltaTime;
			countDownText.text = time1.ToString ("0.0");
			
			if (time1 <= 0) {
				GameOver ();
			}
		}
		if (Input.GetKeyDown (KeyCode.P)){
			PauseGame();
		}
	}
	
	public void StartGame ()
	{
		canvas.SetActive(true);
		timer.SetActive(true);
		ballShooter.GetComponent<BallShooter> ().start = true;
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
		pointsText.text = points.ToString();
	}
	
	public void Reload ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void BackToMenu ()
	{
		Application.LoadLevel ("PlayTennis");
	}
	
	/// <summary>
	/// Pauses the game.
	/// </summary>
	public void PauseGame()
	{
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			canvas.SetActive(false);
		} else if(Time.timeScale == 0 && time1 > 0){
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			canvas.SetActive(true);
		}
	}
	
}
