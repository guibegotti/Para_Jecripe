using UnityEngine;
using System.Collections;

public class Esporte1 : MonoBehaviour {

	public float left;
	float height;
	
	void Start() {
		left = Screen.width/2 - 100;
		height = 70;

	}
	
	
	void OnGUI() {
		
		//left, top, width, height
		if (GUI.Button (new Rect (left, Screen.height / 5 - height / 2, 200, height), "JOGO")) {

			if(Application.loadedLevelName == "PlayTennis"){
				GetComponent<Left>().nivel = "treino";
			}
			else if(Application.loadedLevelName == "PlaySwimming"){
				GetComponent<Left>().nivel = "Natacao";
			}
			else if(Application.loadedLevelName == "PlayAthletics"){
				GetComponent<Left>().nivel = "game";
			}
			else{
				GetComponent<Left>().nivel = "Voltar";	
			}
			GetComponent<Left>().clicou = true;
		}
		
		GUI.Button (new Rect(left, Screen.height *2/5  - height/2, 200, height), "ATLETA");
		
		GUI.Button (new Rect(left, Screen.height*3/5 - height/2, 200, height), "CURIOSIDADES");	

		GUI.Button (new Rect(left, Screen.height*4/5 - height/2, 200, height), "REGRAS E INSTRUCOES");
	}

	void Update(){
		if (GetComponent<Left> ().clicou) {
			left -= GetComponent<Left>().vel;
		}
	}
	

}
