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
	
	CameraController cam;
	
	
	Animator p;
	
	
	void Start ()
	{
		a = GetComponent<Animator> ();
		a.runtimeAnimatorController = Resources.Load ("Animacoes/ArmStrokes") as RuntimeAnimatorController;
		p = GameObject.Find ("PlayerParent").GetComponent<Animator>();
		cam = GameObject.Find ("Main Camera").GetComponent<CameraController>();
		
		cam.naoAnimado = false;
		
	}
	
	void Update ()
	{	
		
		if(jump){
			p.SetTrigger("Jump");
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
