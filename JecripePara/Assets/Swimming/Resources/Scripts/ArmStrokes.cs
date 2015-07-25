using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Timer))]
public class ArmStrokes : MonoBehaviour
{

	GameObject player;
	
	//scripts
	Timer Timer;
	PlayerControl p;
	Animations animations;
	CameraController cam;
	CountDown countDown;
	SwimmingController SC;
	SwimmingSounds Sounds;
	
	public RawImage square1;
	public RawImage square2;
	public bool changeToRed;
	
	public bool freeze;
	public bool armStrokeOK;
	public bool leftStrokeOK;
	public bool rightStrokeOK;
	
	RawImage squareA;
	RawImage squareB;
	
	void Start ()
	{
		player = GameObject.Find ("Player");
		p = player.GetComponent<PlayerControl> ();
		Timer = GetComponent<Timer> ();
		animations = player.GetComponent<Animations> ();
		cam = GameObject.Find ("Main Camera").GetComponent<CameraController> ();
		countDown = GameObject.Find ("Countdown").GetComponent<CountDown> ();
		SC = GameObject.Find ("SwimmingController").GetComponent<SwimmingController>();
		Sounds = GameObject.Find ("Sounds").GetComponent<SwimmingSounds>();
		
		armStrokeOK = true;
		leftStrokeOK = true;
		rightStrokeOK = true;
		square1.enabled = false;
		square2.enabled = false;
		
	}
	
	void Update ()
	{
		
		if (p.isInTheWater && cam.naoAnimado && (freeze == false)) {
		
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (leftStrokeOK) {
					LeftArmStroke ();
				} else {
					WrongArmStroke ();
				}
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (rightStrokeOK) {
					RightArmStroke ();
				} else {
					WrongArmStroke ();
				}
			}
		} else if (freeze) {
			Freeze ();
		}
		
		if (changeToRed) {
			ChangeToRed (squareA, squareB);
		}
		
	}
	
	void RightArmStroke ()
	{
		SC.addPoints(10);
		Sounds.WaitPlay(0.2f,Sounds.armStroke);
		
		
		squareA = square2;
		squareB = square1;
		
		changeToRed = true;
		Timer.SetTimer ();
		animations.rightArmStroke = true;
		p.MoveAthlete ();
		
		armStrokeOK = false;
		rightStrokeOK = false;
		leftStrokeOK = false;
		
	}
	
	void LeftArmStroke ()
	{
		SC.addPoints(10);
		Sounds.WaitPlay(0.1f,Sounds.armStroke);
		
		squareA = square1;
		squareB = square2;
		changeToRed = true;
		
		Timer.SetTimer ();
		animations.leftArmStroke = true;
		p.MoveAthlete ();
		
		armStrokeOK = false;
		rightStrokeOK = false;
		leftStrokeOK = false;
	}
	

	
	void WrongArmStroke ()
	{
		
		countDown.SetCountdown (); 
		SC.WaitGreenSquareWarning ();
		Freeze ();
		SC.addPoints(-55);
	}
	
	public void Freeze ()
	{
		
		//When the user makes a mistake e.g. tries swim when the square is red
		if (countDown.seconds >= 0) {
			freeze = true;
			square1.color = Color.red;
			square2.color = Color.green;
		} else {
			freeze = false;
			square1.color = Color.green;
			square2.color = Color.green;
		}
	}
	
	void ChangeToRed (RawImage squareA, RawImage squareB)
	{
		//To change the square to red for 0.7s and then back to green
		if (freeze == false) {
			
			if (Timer.time < 0.65f) {
				squareA.color = Color.red;
				squareB.color = Color.red;
				armStrokeOK = false;
			} else {
				squareB.color = Color.green;
				armStrokeOK = true;
				leftStrokeOK = true;
				rightStrokeOK = true;
				Timer.timer = false;
			}
					
		}
		
	}
	
	
}
