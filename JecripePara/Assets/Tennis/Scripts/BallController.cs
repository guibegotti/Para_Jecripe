using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	private Rigidbody r;
	public bool atiraBolas;
	public bool estaSacando;
	private float tempoSaque=1000;
	

	private float t;

	void Start () {
		r = GetComponent<Rigidbody> ();
		if (atiraBolas == true) {
			r.useGravity = true;
			t = Time.time;
			r.velocity = new Vector3 (Random.Range (-3, 3), Random.Range (4.85f, 5f), Random.Range (-12, -10));
			Destroy (gameObject, 30);
		} 
	}


	void Update () {
		if (estaSacando == true) {
			if(Input.GetKeyDown(KeyCode.Space)){
				tempoSaque = Time.time + 0.84f;
				r.velocity = new Vector3(-0.06f, -0.31f, -0.04f);
			}
			if(Time.time> tempoSaque){				
				r.useGravity = true;
				r.velocity = new Vector3(0f, 4.9f, -0.25f);
				estaSacando = false;
			}
		}
		if (atiraBolas == true && Time.time>= t+5) {
			this.gameObject.tag = "Untagged";			
		}
	}
}
