using UnityEngine;
using System.Collections;

public class Modalidades : MonoBehaviour {

	public float left;
	float height = 80;
	float width = 180;
	float xdif;
	float ydif;
	float top;

	
	void Start(){

		left = Screen.width * 2/7 - width/2;
		xdif = Screen.width * 2/6;

		top = Screen.height * 2/8 - height/2;
		ydif = Screen.height * 1/3;
	}

	void OnGUI(){
	
		//left, top, width, height
		if (GUI.Button (new Rect (left, top, width, height), "PARTIDA")) {
			GetComponent<Left>().nivel = "Esportes";
			GetComponent<Left>().left = left;
			GetComponent<Left>().clicou = true;
		}
		
		GUI.Button (new Rect(left + xdif, top, width, height), "QUIZ");
		
		GUI.Button (new Rect(left, top + ydif, width, height), "OUTROS ESPORTES");
		
		GUI.Button (new Rect(left + xdif, top + ydif, width, height), "HISTORIA PARALIMPICA");
	}

	void Update(){
		if (GetComponent<Left> ().clicou) {
			left -= GetComponent<Left>().vel;
		}
	}


}
