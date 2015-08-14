using UnityEngine;
using System.Collections;


[RequireComponent (typeof(Animations))]
public class PlayerControl : MonoBehaviour
{

	/*
		Esse script é para fazer o atleta se mover para a frete,
		para ver se ele está dentro da piscina.
		Os códigos referente às braçadas estão no script Bracadas.
	*/

	public float speed = 20;
	public bool voltando;
	public bool isInTheWater;
	Vector3 movement;
	private Rigidbody rb;
	CameraController cam;
	
	SwimmingSounds Sounds;
	
	//scriptss
	Animations animations;
	ArmStrokes b;
	
	
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.mass = 0.5f;
		movement = new Vector3 (0, 0, 1); //a força sobre o atleta para move-lo para a frente
		animations = GetComponent<Animations>();
		b = GameObject.Find ("ArmStrokes").GetComponent<ArmStrokes>();
		cam = GameObject.Find ("Main Camera").GetComponent<CameraController>();
		Sounds = GameObject.Find ("Sounds").GetComponent<SwimmingSounds>();
		
	}
	
	void FixedUpdate(){
			
		if(isInTheWater == false && cam.naoAnimado && Input.GetKey(KeyCode.UpArrow)){
			animations.jump = true;
			Sounds.WaitPlay(0.7f, Sounds.dive);
			//pra ele pular na água
		} 
		
		//transform.position = new Vector3(0, transform.position.y, transform.position.z);
		//para que o atleta não se mova para os lados
	}
	
	
	public void MoveAthlete ()
	{
		if(isInTheWater){
			if(voltando){
				movement = new Vector3 (0, 0, -9.5f);
			} else {
				movement = new Vector3 (0, 0, 11f);
			}
		}
			
		rb.AddForce (movement * 20);
		//To move the athlete forward
		
	}
	
	

	
}
