using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	
	public float velMaxima;
	
	private float moverVertical;
	private float moverHorizontal;
	
	private float velocidade;
	
	public GameObject hitArea;
	private Rebater hitController;
	
	public bool estaSacando = false;
	private float tempoSaque = 1000;
	
	private float delay;
	
	private float girar;
	
	private Rigidbody r;
	private Animator a;
	
	
	void Start () {
		r = GetComponent<Rigidbody> ();
		a = GetComponent<Animator> ();
		hitController = hitArea.GetComponent<Rebater>();
		velocidade = 0;
		delay = 0;
	}
	
	void Update () {
		
		if (estaSacando == true) {
			r.velocity = Vector3.zero;
			a.SetFloat("velocidade", 0);
			hitController.isServing = true;
			Sacar ();
		}
		
		else{
			Mover ();
		} 		
	}
	
	
	void Mover(){
		
		if (moverVertical < velMaxima) {
			moverVertical = Input.GetAxis ("Vertical");	
		}
		if (moverHorizontal < velMaxima) {
			moverHorizontal = Input.GetAxis ("Horizontal");
		}
		
		if (Time.time > 0.4 + delay) {
			a.SetTrigger("Mover");
			delay = Time.time;
		}
		a.SetFloat ("velocidade", velocidade);
		Vector3 mover = new Vector3 (moverHorizontal, 0, moverVertical);
		
		
		velocidade = velMaxima * Mathf.Sqrt ((moverHorizontal * moverHorizontal) + (moverVertical * moverVertical));
		if (velocidade > velMaxima) {
			velocidade = velMaxima;
		}
		r.velocity = transform.forward * -velocidade;
		if (mover != Vector3.zero) {
			r.rotation = Quaternion.Slerp (r.rotation, Quaternion.Euler (0f, 180f, 0f) * Quaternion.LookRotation (mover), Time.deltaTime * 10f); 
		}
	}
	void Sacar(){
		a.SetBool ("estaSacando", true);
		hitController.isServing = true;
		if (Input.GetKeyDown (KeyCode.Space)){
			tempoSaque = Time.time;
			a.SetTrigger("Saque");
		}
		if (Time.time > tempoSaque + 1.6f) {
			hitArea.SetActive(true);	
			a.SetBool("estaSacando", false);
		}
		if(Time.time > tempoSaque + 1.8f){
			hitController.isServing = false;
			estaSacando = false;	
			tempoSaque=Mathf.Infinity;
		}
	}
}