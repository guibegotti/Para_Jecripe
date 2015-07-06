using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {

	public Rigidbody rig;
	public float velocidade;
	public bool podesorteio;
	static public float tempocorrida;
	public int sorteio;
	public float x;
	static public bool termina;
	public float tempo;

	void Movimenta(){

		rig.velocity += transform.forward * velocidade;
		tempo = 0;
		podesorteio = false;

	}


	void Start () {

		termina = false;
		x = transform.position.x;
		podesorteio = true;
		tempocorrida = 0;

	}
	
	void Update () {

	    tempo += Time.deltaTime;
		if (tempo >= 0.2f) {

			podesorteio = true;

		}
		if (podesorteio) {

			velocidade = Random.Range (1,10) * 0.1f + 1.5f ;
		

		}

		if (transform.position.x >= x + 158) {
			termina = true;
		}
		if (playerBehaviour2.começa && !termina) {	
			tempocorrida += Time.deltaTime;
			if(podesorteio){
				Movimenta ();
			}
		}
	
	}
}
