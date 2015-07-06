using UnityEngine;
using System.Collections;

public class Left : MonoBehaviour {

	public bool clicou;
	public float left;
	public string nivel;
	public float vel;



	void Update () {

		if (clicou) {
			if(left>= -600){
				vel = Time.deltaTime * 1350;
				left -= vel;
			}
			else{
				Application.LoadLevel(nivel);
			}
		}
	
	}
}
