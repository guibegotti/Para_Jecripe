using UnityEngine;
using System.Collections;

public class Button1 : MonoBehaviour {

	float left;
	bool clicou;
	string nivel;
	
	float yy = Screen.height*1/6; //o y onde começa o menu, em cima
	float dif = Screen.height*1/6;
	float height = 55;

	void Start(){
		clicou = false;
		left = Screen.width/2 - 75;
	}


	void OnGUI(){
	
	//left, top, width, height
		GUI.Button (new Rect(left, yy + dif, 150, height), "LOJA");
		GUI.Button (new Rect(left, yy + dif * 2, 150, height), "CONFIGURAÇÕES");

		if(GUI.Button(new Rect(left, yy, 150, height), "JOGAR")){
			clicou = true;
			nivel = "Modalidades";
		}
		else if(GUI.Button (new Rect(left, yy + dif * 3, 150, height), "SAIR")){
			Application.Quit();
		}





	}
	

	void Update(){
		if(clicou){
			left -= Time.deltaTime * 1350;
			if(left <= -500){
				Application.LoadLevel(nivel);
			}
		}
		
	}
	
	
	
	
}
