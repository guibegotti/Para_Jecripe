using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {

	public Rigidbody rig;
	public float velocidade, velfrente, vellado, posidepois;
	public bool rota;
	static public float tempocorrida;
	public int sorteio;
	public float x;
	static public bool termina;
	public float tempo;
	public Animator animator;
	public Transform referencia;

	void Movimenta(){

		rig.velocity += -transform.forward * velocidade;
		tempo = 0;
	

	}
	void MovimentaCurva(){

		rig.velocity = -transform.forward * velfrente + transform.right * vellado;

	}


	void Start () {

		termina = false;
		x = transform.position.x;
		tempocorrida = 0;
		rota = false;

	}
	void Anima(){
		if (rig.velocity != new Vector3 (0, 0, 0)) {
			animator.SetBool ("inIdle", false);
			animator.SetBool ("inRun", true);
		} else {
			animator.SetBool ("inIdle", true);
			animator.SetBool ("inRun", false);
		}
	}
	
	void Update () {

		Anima ();
	    tempo += Time.deltaTime;
		if (tempo >= 0.2f) {
			velocidade = Random.Range (1,10) * 0.1f + 1.5f ;
		}

		if (transform.position.x >= x + 158) {
			float dx = this.transform.position.x - referencia.position.x;
			float dy = this.transform.position.z - referencia.position.z;
			float angle = Mathf.Atan2 (dx, dy) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.Euler (new Vector3 (0, angle + 90, 0));
			this.transform.rotation = rot;
			rota = true;
		} else {
			if (transform.position.z >= 221f) {
				transform.position = new Vector3 (transform.position.x, transform.position.y, posidepois );
				transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
				if(transform.position.x <= x){
					termina = true;
				}
			}
		}


		if (playerBehaviour2.começa && !termina) {	
			tempocorrida += Time.deltaTime;
			if(tempo > 0.2f && !rota){
				Movimenta ();
			}

			if(rota){
				MovimentaCurva ();
			}
		}
	
	}
}
