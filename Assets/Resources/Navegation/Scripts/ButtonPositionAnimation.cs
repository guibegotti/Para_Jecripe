using UnityEngine;
using System.Collections;

public class ButtonPositionAnimation : MonoBehaviour {

	Vector3 position;
	Vector3 finalPosition;
	float xpos;
	
	void Start(){
		
		
		transform.position = new Vector3(-300, transform.position.y, transform.position.z);
	
	}
	
	void Update(){
		

		if(transform.position.x <= 0){
			position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
			position.x = position.x + 20;
			transform.position = position;
		}
		
	}
	
}
