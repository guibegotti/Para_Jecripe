using UnityEngine;
using System.Collections;

public class Partida : MonoBehaviour {

	public float left;
	float height;
	bool clicou;
	
	void Start() {
		left = 75;
		height = 80;
	}


	void OnGUI() {

		
		//left, top, width, height
		if (GUI.Button (new Rect (left, Screen.height / 3 - height / 2, 200, height), "ATLETISMO")) {
			clicou = true;
		} else if (GUI.Button (new Rect (left + 325, Screen.height / 2 - height / 2, 200, height), "TENIS")) {
			clicou = true;
		} else if (GUI.Button (new Rect (left, Screen.height * 2 / 3 - height / 2, 200, height), "NATACAO")) {
			clicou = true;
		}
	}
	
	void Update(){

		if (clicou) {
			if(left >= -700){
				left -= Time.deltaTime * 1350;
				GameObject.Find("Voltar").GetComponent<Voltar6>().left -= Time.deltaTime * 1350;
			}
			else{
				Application.LoadLevel("Esporte1");
			}
		}
	}

	

}
