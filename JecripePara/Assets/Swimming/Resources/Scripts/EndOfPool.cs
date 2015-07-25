using UnityEngine;
using System.Collections;

public class EndOfPool : MonoBehaviour {

	SwimmingController SC;

	void Start(){
		
		SC = GameObject.Find ("SwimmingController").GetComponent<SwimmingController>();
	}

	void OnCollisionEnter(Collision other){
		
		SC.GameOver("finished");
	}
}
