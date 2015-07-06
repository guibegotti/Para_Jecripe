using UnityEngine;
using System.Collections;

public class Esportes : MonoBehaviour {

	public float left;
	float height = 75;
	float width = 180;
	float ydif = Screen.height * 2/9;
	float top;
	
	void Start(){
		
		left = Screen.width / 2 - width / 2;
		top = Screen.height * 2/7 - height /2;
		
		
	}
	
	void OnGUI(){
		
		//left, top, width, height
		
		if(GUI.Button(new Rect(left, top, width, height), "TENIS")){
			GetComponent<Left>().nivel = "JogarTenis";
			GetComponent<Left>().left = left;
			GetComponent<Left>().clicou = true;
		}
		
		if(GUI.Button (new Rect(left, top + ydif, width, height), "NATAÇÃO")){
			GetComponent<Left>().nivel = "JogarNatacao";
			GetComponent<Left>().left = left;
			GetComponent<Left>().clicou = true;
		}
		
		if(GUI.Button (new Rect(left, top + 2 * ydif, width, height), "ATLETISMO")){
			GetComponent<Left>().nivel = "JogarAtletismo";
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
