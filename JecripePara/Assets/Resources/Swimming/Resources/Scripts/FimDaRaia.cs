using UnityEngine;
using System.Collections;

public class FimDaRaia : MonoBehaviour
{

	GameObject Cam;
	GameObject MainCam;
	GameObject Scripts;
	
	//Scripts
	CameraController camController;
	PlayerControl playerController;
	Timer t;
	
	Animations animations;
	
	void Start ()
	{
		Cam = GameObject.Find ("Cam");
		MainCam = GameObject.Find ("Main Camera");
		animations = GameObject.Find ("Player").GetComponent<Animations>();
		
		t = GetComponent<Timer> ();
		camController = MainCam.GetComponent<CameraController> ();
		playerController = GameObject.Find ("Player").GetComponent<PlayerControl>();
		
	}
	
	/*
		Procedimento:
		Quando o atleta colide com o final da raia, a animação da camera inicia.
		A animação dura 4 segundos, durante os quais o usuario nao pode controlar o aleta com as setas.
	*/
	
	
	//Quando o atleta chega no final da raia
	void OnCollisionEnter (Collision other)
	{
		camController.naoAnimado = false;
		Cam.GetComponent<Animator> ().SetTrigger ("girarCam");
		t.SetTimer (); //contar até o final da animaçao da camera
		playerController.voltando = true;
		animations.turnPlayer = true;
		
	}
	
	void Update ()
	{
		if (t.time >= 3.3f) {
			camController.naoAnimado = true;
		}
	}
	
	
	

}
