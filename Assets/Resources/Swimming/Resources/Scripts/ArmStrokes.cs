using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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
	
	public bool changeToRed;
	
	public List<GameObject> armstrokesSounds;
	
	
	public bool freeze;
	public bool armStrokeOK;
	public bool leftStrokeOK;
	public bool rightStrokeOK;
	
	public Material material1;
	public Material material2;
	
	public Material materialA;
	public Material materialB;
	
	ParticleSystem waterSprayLeft;
	ParticleSystem waterSprayRight;
	
	public 
	
	
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
		waterSprayRight = GameObject.Find("SwimmingWaterParticlesR").GetComponent<ParticleSystem>();
		waterSprayLeft = GameObject.Find("SwimmingWaterParticlesL").GetComponent<ParticleSystem>();
		
		armStrokeOK = true;
		leftStrokeOK = true;
		rightStrokeOK = true;
		
	}
	/*
	void Update ()
	{
		
		//if (p.isInTheWater && cam.naoAnimado && (freeze == false)) {
		
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
			ChangeToRed (materialA, materialB);
		}
		
	}*/
	
	void RightArmStroke ()
	{
		SC.addPoints(10);
		ArmstrokeSounds();
	
		materialA = material2;
		materialB = material1;
		
		waterSprayRight.Play();
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
		ArmstrokeSounds();
		
		materialA = material1;
		materialB = material2;
		
		waterSprayLeft.Play();
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
	
	void ArmstrokeSounds(){
		
		if(armstrokesSounds[0].GetComponent<AudioSource>().isPlaying == false){
			armstrokesSounds[0].GetComponent<AudioSource>().PlayDelayed(0.25f);
		} else {
			armstrokesSounds[1].GetComponent<AudioSource>().PlayDelayed(0.25f);
		}
	}
	
	
	public void Freeze ()
	{
		
		//When the user makes a mistake e.g. tries swim when the square is red
		if (countDown.seconds >= 0) {
			freeze = true;
			material1.color = Color.green;
			material2.color = Color.green;
		} else {
			freeze = false;
			material1.color = Color.green;
			material2.color = Color.green;
		}
	}
	
	void ChangeToRed (Material materialA, Material materialB)
	{
		//To change the square to red for 0.7s and then back to green
		if (freeze == false) {
			
			if (Timer.time < 0.65f) {
				materialA.color = Color.red;
				materialB.color = Color.red;
				armStrokeOK = false;
			} else {
				materialB.color = Color.green;
				armStrokeOK = true;
				leftStrokeOK = true;
				rightStrokeOK = true;
				Timer.timer = false;
			}
					
		}
		
	}
	
	
}
