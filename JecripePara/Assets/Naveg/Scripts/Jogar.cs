using UnityEngine;
using System.Collections;

public class Jogar : MonoBehaviour {

	public bool jogar;
	bool clicou;
	float left;
	float width = 120;
	float height = 60;

	//left, top, width, height
	void OnGUI(){
	
		if(jogar){
			if (GUI.Button(new Rect(left - width/2, Screen.height*5/7, width, height), "JOGAR")){
				GetComponent<Left>().nivel = "Menu";
				GetComponent<Left>().left = left;
				GetComponent<Left>().clicou = true;
			}
			if (GUI.Button(new Rect(left - width/2, Screen.height*6/7, width, height*1/2), "CREDITOS")){
				GetComponent<Left>().nivel = "Creditos";
				GetComponent<Left>().left = left;
				GetComponent<Left>().clicou = true;
			}

		}	
	}
	
	void Start(){
		left = Screen.width * 6/7;
	}
	
	void Update(){
		if (GetComponent<Left> ().clicou) {
			left -= GetComponent<Left>().vel;
		}
	}

}
