using UnityEngine;
using System.Collections;

public class SpinWheels : MonoBehaviour {

	private Rigidbody parentRB;
	public float direction;

	// Use this for initialization
	void Start () {
		parentRB = GetComponentInParent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update(){
		transform.Rotate (0,0, direction*Vector3.Magnitude(parentRB.velocity), Space.Self);
	}
}
