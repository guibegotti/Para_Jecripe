using UnityEngine;
using System.Collections;

public class EndOfPool : MonoBehaviour {

	Buttons Buttons;

	void Start(){
		
		Buttons = GameObject.Find ("Buttons").GetComponent<Buttons>();
	}

	void OnCollisionEnter(Collision other){
		
		Buttons.GameOver("finished");
	}
}
