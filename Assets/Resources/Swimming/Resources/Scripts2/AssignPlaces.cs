using UnityEngine;
using System.Collections;

public class AssignPlaces : MonoBehaviour {

	SwimmingGameController sc;

	public GameObject op1;
	public GameObject op2;
	public GameObject player;


	public float op1Final;
	public float op2Final;
	public float playerFinal;


	void Update(){
	}


	void CheckPositiosOfPlayers(){

		CheckPositions (op1, op1Final);
		CheckPositions (op2, op2Final);
		CheckPositions (player, playerFinal);
	}


	void CheckPositions(GameObject go, float pos){

		if (go.transform.position.y >= pos) {

			CheckIfStopAnimation(go);

			if(sc.firstPlace == null)
			{
				sc.firstPlace = go;
				Debug.Log ("FIRST PLACE - " + go.name);
				CheckIfGameOver(go, 1);
			} 

			else if (sc.secondPlace == null)
			{
				sc.secondPlace = go;
				Debug.Log ("SECOND PLACE - " + go.name);
				CheckIfGameOver(go, 2);
			}

			else  if (sc.thirdPlace == null) 
			{
				sc.thirdPlace = go;
				Debug.Log ("THIRD PLACE - " + go.name);
				CheckIfGameOver(go, 3);
			}
		}

	}


	
	void CheckIfGameOver(GameObject ath, int place){
		if(ath.name == "Clodoaldo Silva" && place == 3){
			sc.GameOver(place);
		} else if(place == 3){
			if(sc.firstPlace.name == "Clodoaldo Silva"){
				sc.GameOver(1);
			} else {
				sc.GameOver(2);
			}
		}
		
	}
	
	void CheckIfStopAnimation(GameObject ath){
		if(ath.name != "Clodoaldo Silva"){
			ath.GetComponent<Animator>().SetBool("Stop",true);
		}
	}
	
	void Start(){
		sc = GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController>();
	}
}
