using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Animations : MonoBehaviour
{

	//AS ANIMACOES QUE CONTROLAM O ATLETA
	
	public Animator a;
	public bool leftArmStroke;
	public bool rightArmStroke;
	public bool jump;
	public bool turnPlayer;
	
	//public bool jumpIntoWater;
	
	
	CameraController cam;
	PlayerControl pc;
	
	
	Animator p;
	
	
	void Start ()
	{
		a = GetComponent<Animator> ();
		a.runtimeAnimatorController = Resources.Load ("Animacoes/ArmStrokes") as RuntimeAnimatorController;
		p = GameObject.Find ("PlayerParent").GetComponent<Animator>();
		cam = GameObject.Find ("Main Camera").GetComponent<CameraController>();
		pc = GameObject.Find("Player").GetComponent<PlayerControl>();
		jump = false;
		//cam.naoAnimado = false;
		
	}
	
	void Update ()
	{	
		
		if(jump){
			p.SetTrigger("Jump");
			pc.isInTheWater = true;
			jump = false;
			a.SetTrigger("jumpIntoWater");
		}
	
		if (leftArmStroke) {
			a.SetTrigger ("leftArmStrokeTrigger");
			leftArmStroke = false;
		}
			
		if (rightArmStroke) {
			a.SetTrigger ("rightArmStrokeTrigger");
			rightArmStroke = false;
		}
		
		if(turnPlayer) {
			p.SetTrigger("Turn");
		}
		
	}

}
