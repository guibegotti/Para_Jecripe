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
			r.velocity = new Vector3 (Random.Range (-3, 3), Random.Range (5f, 5.3f), Random.Range (-14, -12));
			Destroy (gameObject, 30);
		} 
	}
	
	
	void Update () {
		if (estaSacando == true) {
			r.velocity = Vector3.zero;
			r.useGravity = false;

			if(Input.GetKeyDown(KeyCode.Space)){
				tempoSaque = Time.time + 0.84f;
				r.velocity = new Vector3(-0.06f, -0.31f, -0.04f);
			}

			if(Time.time> tempoSaque){				
				r.useGravity = true;
				r.velocity = new Vector3(0f, 4.9f, 0f);
				estaSacando = false;
				tempoSaque = 1000;
			}
		}
		if (atiraBolas == true && Time.time>= t+5) {
			this.gameObject.tag = "Untagged";			
		}
	}

}


