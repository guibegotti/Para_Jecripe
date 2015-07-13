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
	
	//scriptss
	Animations animations;
	Bracadas b;
	
	
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.mass = 0.5f;
		movement = new Vector3 (0, 0, 1); //a força sobre o atleta para move-lo para a frente
		animations = GetComponent<Animations>();
		b = GameObject.Find ("Bracadas").GetComponent<Bracadas>();
		
	}
	
	void FixedUpdate(){
			
		if(isInTheWater == false && Input.GetKey(KeyCode.UpArrow)){
			animations.jump = true;
			//pra ele pular na água
		} 
		
		//transform.position = new Vector3(0, transform.position.y, transform.position.z);
		//para que o atleta não se mova para os lados
	}
	
	
	public void MoveAthlete ()
	{
		if(isInTheWater){
			b.square.enabled = true;
			if(voltando){
				movement = new Vector3 (0, 0, -9.5f);
			} else {
				movement = new Vector3 (0, 0, 9.5f);
			}
		}
			
		rb.AddForce (movement * 20);
		//para mover o atleta para a frente
		
	}
	
	/*
	//Se o atleta está na piscina	
	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Pool") {
			isInTheWater = true;
			Debug.Log (isInTheWater);
			MoveAthlete();
		}
	}*/

	
}
