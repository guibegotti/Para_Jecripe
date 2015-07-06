using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	
	public float velMaxima;
	
	private float moverVertical;
	private float moverHorizontal;
	
	public float velocidade;
	
	public GameObject areaAcerto;
	private Collider aAcerto;
	private float tempoAtivacao;
	
	public bool estaSacando = false;
	private float tempoSaque = 1000;
	
	private float delay;
	
	private float girar;
	
	private Rigidbody r;
	private Animator a;
	
	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody> ();
		a = GetComponent<Animator> ();
		aAcerto = areaAcerto.GetComponent<Collider> ();
		velocidade = 0;
		delay = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (estaSacando == true) {
			Sacar ();
		}
		
		else{
			if (Input.GetKeyDown (KeyCode.Space)) {
				aAcerto.enabled = true;
				tempoAtivacao = Time.time + 1f;
				if (transform.eulerAngles.y >= 135 && transform.eulerAngles.y < 190) {
					a.SetTrigger ("Backhand_frente");
				} else if (transform.eulerAngles.y >= 190 && transform.eulerAngles.y <= 225) {
					a.SetTrigger ("Forehand_frente");
				}
				else if (transform.eulerAngles.y < 135 && transform.eulerAngles.y > 0) {
					a.SetTrigger ("Backhand_lado");
				} else if (transform.eulerAngles.y > 225 && transform.eulerAngles.y <= 360) {
					a.SetTrigger ("Forehand_lado");
				}
			} 		
			if (Time.time > tempoAtivacao-0.2f) {
				aAcerto.enabled = false;
				tempoAtivacao = 0;
				
				Mover();
			}
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
		if (Input.GetKeyDown (KeyCode.Space)){
			tempoSaque = Time.time;
			a.SetTrigger("Saque");
		}
		if (Time.time > tempoSaque + 1.875f) {
			estaSacando = false;			
			a.SetBool("estaSacando", false);
		}
		if (Time.time > tempoSaque + 1.556) {
			aAcerto.enabled = true;
		}
	}
	
}