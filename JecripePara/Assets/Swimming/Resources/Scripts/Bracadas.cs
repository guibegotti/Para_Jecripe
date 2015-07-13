using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof (Timer))]
public class Bracadas : MonoBehaviour {

	GameObject player;
	
	//scripts
	Timer Timer;
	PlayerControl p;
	Animations animations;
	CameraController cam;
	CountDown countDown;
	Buttons buttons;

	public RawImage square;
	
	public bool changeToRed;
	public bool freeze;
	
	public bool armStrokeOK;
	
	
	void Start()
	{
		player = GameObject.Find("Player");
		p = player.GetComponent<PlayerControl>();
		Timer = GetComponent<Timer>();
		animations = player.GetComponent<Animations>();
		cam = GameObject.Find ("Main Camera").GetComponent<CameraController>();
		countDown = GameObject.Find("Countdown").GetComponent<CountDown>();
		buttons = GameObject.Find ("Buttons").GetComponent<Buttons>();
		
		armStrokeOK = true;
		square.enabled = false;
		
	}
	
	void Update()
	{
		
		if (p.isInTheWater && cam.naoAnimado && (freeze == false)){
		
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				if(armStrokeOK){
					LeftArmStroke();
				} else {
					countDown.SetCountdown();
					buttons.WaitGreenSquareWarning();
					Freeze();
				}
			}
			else if(Input.GetKeyDown(KeyCode.RightArrow)){
				if(armStrokeOK){
					RightArmStroke();
				} else {
					countDown.SetCountdown();
					buttons.WaitGreenSquareWarning();
					Freeze();
				}
			}
		}
		
		else if (freeze){
			Freeze();
		}
		
		if(changeToRed){
			ChangeToRed();
		}
		
	}
	
	
	void LeftArmStroke(){
		
		Timer.SetTimer();
		changeToRed = true;
		animations.leftArmStroke = true;
		p.MoveAthlete();
		armStrokeOK = false;
	}
	
	void RightArmStroke(){
		
		Timer.SetTimer();
		changeToRed = true;
		animations.rightArmStroke = true;
		p.MoveAthlete();
		armStrokeOK = false;
		
	}
	
	public void Freeze(){
		
		//Quando o usuario comete um erro e.g. tenta dar uma bracada quando o quadrado vermelho esta na tela
	
		if(countDown.seconds >= 0){
			freeze = true;
			square.color = Color.red;
		} else {
			freeze = false;
			square.color = Color.green;
		}
	}
	
	void ChangeToRed(){
		//Para fazer o quadrado mudar para vermelho por 0.7s e depois de volta para verde
		if(freeze == false){
			if(Timer.tempo < 0.65f){
				square.color = Color.red;
				armStrokeOK = false;
			} else {
				square.color = Color.green;
				armStrokeOK = true;
			}
		}
		
	}
	

	
}
