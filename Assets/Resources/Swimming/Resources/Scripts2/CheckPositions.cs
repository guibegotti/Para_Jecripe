using UnityEngine;
using System.Collections;

public class CheckPositions : MonoBehaviour {

	public float finalY;
	public float finalZ;
	SwimmingGameController sc;

	public float yv;
	public float yz;

	public GameObject go;
	public GameObject PositionGo;


	void Update(){

		CheckPosition ();
		yv = transform.localPosition.y;
		yz = this.gameObject.transform.position.z;
	
	}


	void CheckPosition(){

		if (transform.localPosition.y >= finalY || this.gameObject.transform.position.z >= finalZ) {
			 
			CheckIfStopAnimation (go);

			if (sc.firstPlace == null) {
				sc.firstPlace = go;
				Debug.Log ("FIRST PLACE - " + go.name);
				CheckIfGameOver (go, 1);
			} else if (sc.secondPlace == null) {
				sc.secondPlace = go;
				Debug.Log ("SECOND PLACE - " + go.name);
				CheckIfGameOver (go, 2);
			} else if (sc.thirdPlace == null) {
				sc.thirdPlace = go;
				Debug.Log ("THIRD PLACE - " + go.name);
				CheckIfGameOver (go, 3);
			}
			this.enabled = false;
		}

	}


	void CheckIfGameOver(GameObject ath, int place){
		if(ath.name == "Player" && place == 3){
			sc.GameOver(place);
		} else if(place == 3){
			if(sc.firstPlace.name == "Player"){
				sc.GameOver(1);
			} else {
				sc.GameOver(2);
			}
		}

	}

	void CheckIfStopAnimation(GameObject ath){
		if(ath.name != "Player"){
			ath.GetComponent<Animator>().SetBool("Stop",true);
		}
	}

	void Start(){
		sc = GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController>();

	}

}
