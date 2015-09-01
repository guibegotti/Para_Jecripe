using UnityEngine;
using System.Collections;

public class GirarRoda : MonoBehaviour {

	private Rigidbody p;
	public string objeto;
	public float sentido;

	// Use this for initialization
	void Start () {
		p = GetComponentInParent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update(){
		transform.Rotate (0,0, sentido*Vector3.Magnitude(p.velocity), Space.Self);
	}
}
