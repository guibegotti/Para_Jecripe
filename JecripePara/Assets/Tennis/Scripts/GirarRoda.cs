using UnityEngine;
using System.Collections;

public class GirarRoda : MonoBehaviour {

	private PlayerController p;
	public string objeto;
	public float sentido;

	// Use this for initialization
	void Start () {
		GameObject g = GameObject.Find(objeto);
		p = g.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update(){
		transform.Rotate (0,0, sentido*p.velocidade, Space.Self);
	}
}
