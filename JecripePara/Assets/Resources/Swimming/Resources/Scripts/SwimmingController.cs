using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
///  This is the Game Controller script for the Swimming mini-game.
/// </summary>

/// <remarks> This is a mini-game that has yet to be finished.</remarks>

public class SwimmingController : MonoBehaviour {
	
	/// <summary>
	/// How many points the player has obtained up until that moment.
	/// </summary>
	public int points = 0;
	
	/// <summary>
	/// The canvas that contains all of the main buttons related to the Swimming mini-game: the oxygen slider, the back
	/// button, and the scoreboard.
	/// </summary>
	GameObject canvas1;
	
	/// <summary>
	/// The canvas that contains all of the buttons, images and labels that shows up when the game ends.
	/// </summary>
	GameObject gameOverCanvas;
	
	/// <summary>
	/// The instructions canvas.
	/// </summary>
	GameObject instructionsCanvas;
	
	/// <summary>
	/// The pause canvas.
	/// </summary>
	GameObject pauseCanvas;
	
	/// <summary>
	/// The wait green square.
	/// </summary>
	GameObject waitGreenSquare;
	
	/// <summary>
	/// The wait button.
	/// </summary>
	GameObject waitButton;

	/// <summary>
	/// The Timer script.
	/// </summary>
	Timer timer;
	
	/// <summary>
	/// The script with all the sounds in the Swimming mini-game.
	/// </summary>
	SwimmingSounds Sounds;
	
	/// <summary>
	/// The warning that the player tried to take the next breath too quickly. 
	/// </summary>
	public GameObject moreOx;
	
	/// <summary>
	/// The text that states why the game has finished (if the player won or lost, and why).
	/// </summary>
	public Text reason;
	
	/// <summary>
	/// The text attatched to the scoreboard that displays the player's current score.
	/// </summary>
	public Text pointsText;
	

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start(){
		addPoints(0);
		
		gameOverCanvas = GameObject.Find ("GameOver");
		instructionsCanvas = GameObject.Find ("Instructions");
		canvas1 = GameObject.Find ("Canvas1");
		pauseCanvas = GameObject.Find ("PauseCanvas");
		timer = GetComponent<Timer> ();
		waitGreenSquare = GameObject.Find ("WaitGreenSquare");
		waitButton = GameObject.Find ("Wait");
		Sounds = GameObject.Find("Sounds").GetComponent<SwimmingSounds>();
		
		gameOverCanvas.SetActive (false);
		pauseCanvas.SetActive (false);
		canvas1.SetActive (false);
		Time.timeScale = 0;
	}
	
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update ()
	{
		if (moreOx.activeSelf && timer.time >= 3) {
			moreOx.SetActive (false);
			timer.timer = false;
		} else if (waitGreenSquare.activeSelf && timer.time >= 3) {
			waitGreenSquare.SetActive (false);
			timer.timer = false;
		}
		
		if(Input.GetKeyDown(KeyCode.P)){
			PauseGame();
		}
	}
	
	/// <summary>
	/// The method that starts the game per se.
	/// It is initialized after the instructions have appeared onscreen and the player has pressed the
	/// "play game" button.
	/// </summary>
	public void StartGame ()
	{
		Time.timeScale = 1f;
		instructionsCanvas.SetActive (false);
		canvas1.SetActive (true);
		moreOx.SetActive (false);
		waitGreenSquare.SetActive (false);
		waitButton.SetActive(false);
		Sounds.PlaySound(Sounds.background);
		Sounds.PlaySound(Sounds.backgroundPeople);
		
	}
	
	/// <summary>
	/// Called once the game is over, when the player has either lost or won the game.
	/// </summary>
	/// <param name="why">The reason why the game is over.</param>
	public void GameOver (string why)
	{
		if(why == "finished"){
			reason.text = "Parabéns! Você fez " + points + " pontos.";
			Sounds.PlaySound(Sounds.applause);
		}
		
		else{
		}
		gameOverCanvas.SetActive (true);
		canvas1.SetActive(false);
		Sounds.backgroundPeople.Stop();
		Time.timeScale = 0;
		pointsText.text = "PONTOS\n" + points.ToString();
		
	}
	
	/// <summary>
	/// Called when the player tries to get the athlete to breathe too quickly.
	/// Tells the player to wait more time until the althete takes the next breath.
	/// </summary>
	public void MoreOxWarning ()
	{
		moreOx.SetActive (true);
		timer.SetTimer ();
	}
	
	/// <summary>
	/// Called when the player tries to do an armstroke before one of the lanes has turned green.
	/// Tells the player to wait until the lane has turned green.
	/// </summary>
	public void WaitGreenSquareWarning ()
	{
		waitGreenSquare.SetActive (true);
		timer.SetTimer ();
	}
	
	/// <summary>
	/// Adds points to the player's current score, and also changes the score on the scoreboard on the screen.
	/// </summary>
	/// <param name="pointsToAdd">Points to add.</param>
	public void addPoints(int pointsToAdd){
		points += pointsToAdd;
		pointsText.text = points.ToString ();
	}
	
	/// <summary>
	/// Reloads the Swimming Menu scene.
	/// </summary>
	public void BackToMenu(){
		
		Application.LoadLevel("PlaySwimming");
	}
	
	/// <summary>
	/// Reloads the current level.
	/// </summary>
	public void ReloadLevel(){
	
		Application.LoadLevel(Application.loadedLevel);
	}
	
	/// <summary>
	/// Pause Game
	/// </summary>
	public void PauseGame(){
	
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			canvas1.SetActive(false);
		} else if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			canvas1.SetActive(true);
		}
	}
	
	
	

}
