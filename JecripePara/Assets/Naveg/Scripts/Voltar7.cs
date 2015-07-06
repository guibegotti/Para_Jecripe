using UnityEngine;
using System.Collections;

public class Voltar7 : MonoBehaviour {

	
	bool clicou;
	float width = 90;
	float top;
	float height = 50;
	public float left;
	
	
	void Start(){
		left = Screen.width * 7/8 - width / 2;
		top = Screen.height * 7/8 - height / 2;
	}
	
	void OnGUI(){
		//left, top, width, height
		if (GUI.Button(new Rect(left, top, width, height), "VOLTAR")){
			
			GetComponent<Left>().nivel = "SportsScene";
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
