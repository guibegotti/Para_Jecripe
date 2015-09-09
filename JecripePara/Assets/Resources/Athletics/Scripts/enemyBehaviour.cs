using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {

	public Rigidbody rig;
	public float velocidade, velfrente, vellado, posidepois,x1,tempotermina;
	public float n;
	public static float nn;
	public bool rota, fim;
	static public float tempocorrida;
	public int sorteio;
	public float x;
	static public bool termina;
	public float tempo;
	public Animator animator;
	public Transform referencia, referencia2;

	void Movimenta(){

		rig.velocity += -transform.forward * velocidade * 0.5f;
		tempo = 0;
	

	}
	void MovimentaCurva(){

		rig.velocity = -transform.forward * velfrente + transform.right * vellado;

	}
	void Rotaciona( Transform referencia){
		float dx = this.transform.position.x - referencia.position.x;
		float dy = this.transform.position.z - referencia.position.z;
		float angle = Mathf.Atan2 (dx, dy) * Mathf.Rad2Deg;
		Quaternion rot = Quaternion.Euler (new Vector3 (0, angle + 90, 0));
		this.transform.rotation = rot;
	}
	

	void Start () {

		termina = false;
		x = referencia.position.x;
		x1 = referencia2.position.x;
		tempocorrida = 0;
		rota = false;
		fim = false;
		nn = n;
		velfrente = 16;
		vellado = 0.5f;

	}
	void Anima(){
		if (!playerBehaviour2.começa) {
			animator.SetBool ("inIdle", false);
			animator.SetBool ("inRun", false);
			animator.SetBool ("inStart", true);
		} else {
			if (rig.velocity != new Vector3 (0, 0, 0)) {
				animator.SetBool ("inIdle", false);
				animator.SetBool ("inRun", true);
				animator.SetBool ("inStart", false);
				
			} else {
				animator.SetBool ("inIdle", true);
				animator.SetBool ("inRun", false);
				animator.SetBool ("inStart", false);
				
			}
		}
	}
	void ControlaPosiçoes(){
		
		if (transform.position.x < x1) {
			Rotaciona (referencia2);
			MovimentaCurva ();			
		} else {
			
			if(transform.position.x < x){
				rota = false;
				if (transform.position.z <= 17f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 2.5f);
					transform.rotation = Quaternion.Euler (new Vector3 (0, 270, 0));
					Movimenta ();
					fim = true;
				} else {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 110);
					transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
					Movimenta ();
					
				}
			}
			else{
				Rotaciona (referencia);
				MovimentaCurva ();
				rota = true;
			}
		}
	}
	
	void Update () {
	
		Anima ();
		print (velocidade);
	    tempo += Time.deltaTime;
		if (transform.position.x < -46 && transform.position.z > 50 && fim) {
			termina = true;
			rig.drag = 1.5f;
			tempotermina += Time.deltaTime;
			if(tempotermina > 0.75f ){
				rig.velocity = Vector3.zero;
			}
		}
		if (tempo >= 0.2f) {
			velocidade = Random.Range (1, 10) * 0.1f + 0.8f;
			tempo = 0;
		} else {
			velocidade = 0;
		}



		if (playerBehaviour2.começa && !termina) {	
			tempocorrida += Time.deltaTime;
			ControlaPosiçoes ();
		}
	
	}
}
