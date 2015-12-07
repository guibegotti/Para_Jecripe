using UnityEngine;
using System.Collections;

public class AssignPlaces : MonoBehaviour {

	SwimmingGameController sc;

	void OnTriggerEnter(Collider other){
		
		
		if(sc.firstPlace == null)
		{
			sc.firstPlace = other.gameObject;
			Debug.Log ("FIRST PLACE - " + other.gameObject.name);
			CheckIfGameOver(other.gameObject, 1);
		} 
		
		else if (sc.secondPlace == null)
		{
			sc.secondPlace = other.gameObject;
			Debug.Log ("SECOND PLACE - " + other.gameObject.name);
			CheckIfGameOver(other.gameObject, 2);
		}
		
		else  if (sc.thirdPlace == null) 
		{
			sc.thirdPlace = other.gameObject;
			Debug.Log ("THIRD PLACE - " + other.gameObject.name);
			CheckIfGameOver(other.gameObject, 3);
		}
	}
	
	void CheckIfGameOver(GameObject ath, int place){
		if(ath.name == "clodoaldo" && place == 3){
			sc.GameOver(place);
		} else if(place == 3){
			if(sc.firstPlace.name == "clodoaldo"){
				sc.GameOver(1);
			} else {
				sc.GameOver(2);
			}
		}
		
	}
	
	void Start(){
		sc = GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController>();
	}
}
