using UnityEngine;
using System.Collections;

public class Voltar : MonoBehaviour {

	float top;
	float width = 75;
	float height = 50;
	public float left;
	//public Texture2D fundo;

	
	void Start(){
		left = Screen.width * 7/9 - width/2;
		top = Screen.height * 7/9;

	}

	void OnGUI(){
		//left, top, width, height
		if (GUI.Button(new Rect(left, top, width, height), "VOLTAR")){

			if(Application.loadedLevelName == "Modalidades"){
				GetComponent<Left>().nivel = "Menu";
			}
			else{
				GetComponent<Left>().nivel = "Modalidades";
			}
			GetComponent<Left>().left = left;
			GetComponent<Left>().clicou = true;
		}
		
	}
	
	void Update(){
		if (GetComponent<Left> ().clicou) {
			left -= GetComponent<Left>().vel;
		}
	}
}
