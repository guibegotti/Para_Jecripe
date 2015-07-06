using UnityEngine;
using System.Collections;

public class Voltar5 : MonoBehaviour {

	float left;
	bool clicou;

	void Start(){
		left = Screen.width / 2 - 35;
	}

	void OnGUI(){

		//left, top, width, height
		if (GUI.Button (new Rect (left, Screen.height / 2 - 20, 70, 40), "VOLTAR")) {
			clicou = true;
		}
	}

	void Update(){
		if(clicou){
			if(left <= -500){
				Application.LoadLevel("Menu");
				clicou = false;
			}
			else{
				left -= Time.deltaTime * 1350;
			}
			
		}
	}
}
