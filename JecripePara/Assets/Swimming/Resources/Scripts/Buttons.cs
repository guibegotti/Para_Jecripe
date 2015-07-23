using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
	
	GameObject gameOver;
	GameObject breathing;
	GameObject instructions;
	GameObject canvas1;
	GameObject waitGreenSquare;
	GameObject waitButton;
	
	ArmStrokes b;
	Timer timer;
	SwimmingController SC;
	SwimmingSounds Sounds;
	
	public GameObject moreOx;
	public Text reason;
	
	void Start ()
	{
		gameOver = GameObject.Find ("GameOver");
		b = GameObject.Find ("ArmStrokes").GetComponent<ArmStrokes> ();
		instructions = GameObject.Find ("Instructions");
		canvas1 = GameObject.Find ("Canvas1");
		timer = GetComponent<Timer> ();
		waitGreenSquare = GameObject.Find ("WaitGreenSquare");
		waitButton = GameObject.Find ("Wait");
		SC = GameObject.Find ("SwimmingController").GetComponent<SwimmingController>();
		Sounds = GameObject.Find("Sounds").GetComponent<SwimmingSounds>();
		
		gameOver.SetActive (false);
		canvas1.SetActive (false);
		Time.timeScale = 0;
	}
	
	public void ReloadLevel ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void StartGame ()
	{
		Time.timeScale = 1;
		instructions.SetActive (false);
		canvas1.SetActive (true);
		moreOx.SetActive (false);
		waitGreenSquare.SetActive (false);
		waitButton.SetActive(false);
		Sounds.PlaySound(Sounds.background);
		
	}
	
	public void GameOver (string why)
	{
		if(why == "finished"){
			reason.text = "Parabéns! Você fez " + SC.points + " pontos.";
			Sounds.PlaySound(Sounds.applause);
		}
		
		else{
		}
		gameOver.SetActive (true);
		b.armStrokeOK = false;
		b.square1.enabled = false;
		b.square2.enabled = false;
		Time.timeScale = 0;
		
	}
	
	
	
	public void LoadSwimmingMenu ()
	{
		Application.LoadLevel ("PlaySwimming");
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
	
	




	
}
