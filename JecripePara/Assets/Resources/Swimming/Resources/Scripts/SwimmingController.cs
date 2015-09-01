using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwimmingController : MonoBehaviour {
	
	public int points = 0;
	public Text pointsText;
	
	
	GameObject gameOverCanvas;
	GameObject breathing;
	GameObject instructions;
	GameObject canvas1;
	GameObject waitGreenSquare;
	GameObject waitButton;
	
	//ArmStrokes b;
	Timer timer;
	SwimmingController SC;
	SwimmingSounds Sounds;
	
	public GameObject moreOx;
	public Text reason;
	
	
	void Start(){
		addPoints(0);
		
		gameOverCanvas = GameObject.Find ("GameOver");
		//b = GameObject.Find ("ArmStrokes").GetComponent<ArmStrokes> ();
		instructions = GameObject.Find ("Instructions");
		canvas1 = GameObject.Find ("Canvas1");
		timer = GetComponent<Timer> ();
		waitGreenSquare = GameObject.Find ("WaitGreenSquare");
		waitButton = GameObject.Find ("Wait");
		SC = GameObject.Find ("SwimmingController").GetComponent<SwimmingController>();
		Sounds = GameObject.Find("Sounds").GetComponent<SwimmingSounds>();
		
		gameOverCanvas.SetActive (false);
		canvas1.SetActive (false);
		Time.timeScale = 0;
	}
	
	void Update ()
	{
		if (moreOx.activeSelf && timer.time >= 3) {
			moreOx.SetActive (false);
			timer.timer = false;
		} else if (waitGreenSquare.activeSelf && timer.time >= 3) {
			waitGreenSquare.SetActive (false);
			timer.timer = false;
		}
	}
	
	public void StartGame ()
	{
		Time.timeScale = 1f;
		instructions.SetActive (false);
		canvas1.SetActive (true);
		moreOx.SetActive (false);
		waitGreenSquare.SetActive (false);
		waitButton.SetActive(false);
		Sounds.PlaySound(Sounds.background);
		Sounds.PlaySound(Sounds.backgroundPeople);
		
	}
	
	public void GameOver (string why)
	{
		if(why == "finished"){
			reason.text = "Parabéns! Você fez " + SC.points + " pontos.";
			Sounds.PlaySound(Sounds.applause);
		}
		
		else{
		}
		gameOverCanvas.SetActive (true);
		canvas1.SetActive(false);
		Sounds.backgroundPeople.Stop();
		Time.timeScale = 0;
		
	}
	
	public void MoreOxWarning ()
	{
		moreOx.SetActive (true);
		timer.SetTimer ();
	}
	
	public void WaitGreenSquareWarning ()
	{
		waitGreenSquare.SetActive (true);
		timer.SetTimer ();
	}
	
	
	public void addPoints(int pointsToAdd){
		points += pointsToAdd;
		pointsText.text = "PONTOS\n" + points.ToString();
	}
	
	public void BackToMenu(){
		
		Application.LoadLevel("PlaySwimming");
	}
	
	public void ReloadLevel(){
	
		Application.LoadLevel(Application.loadedLevel);
	}
	

}
