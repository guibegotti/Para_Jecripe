using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameObject bola;
	private Rigidbody rBola;
	private Rigidbody r;
	public bool rebater;

	public Vector3 meetingPlace;

	private Vector3 posicaoBola;
	private Vector3 velocidadeBola;

	public float velocidade=6f;
	
	void Start () {
		r = GetComponent<Rigidbody> ();
		bola = GameObject.FindGameObjectWithTag ("Player");
		rBola = bola.GetComponent<Rigidbody> ();
	}


	void Update () {
		/*if (bola == null) {
			bola = GameObject.FindGameObjectWithTag("Bola");
			rBola = bola.GetComponent<Rigidbody> ();
		}*/
		if (rebater == true) {
			posicaoBola = new Vector3(bola.transform.position.x, transform.position.y, bola.transform.position.z);
			velocidadeBola = new Vector3 (rBola.velocity.x, 0f, rBola.velocity.z);

			 meetingPlace = posicaoBola + velocidadeBola.normalized * Vector3.Dot(velocidadeBola.normalized, transform.position - posicaoBola);
			 //meetingPlace = new Vector3(meetingPlace.x, transform.position.y, meetingPlace.z);

			//rebater = false;
		}
		r.rotation = Quaternion.Slerp(r.rotation,Quaternion.Euler (0f, 180f, 0f) * Quaternion.LookRotation(meetingPlace), Time.deltaTime*10f);
		
		//r.velocity = transform.forward * -6;
	}
}
