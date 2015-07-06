using UnityEngine;
using System.Collections;

public class Voltar6 : MonoBehaviour {

	public float left;
	float width;
	float height;
	float top;
	bool clicou;

	GameObject Partida;

	void Start(){
		height = 60;
		width = 80;
		top = Screen.height*5/6  - height/2;
		left = Screen.width *5/6 - width / 2;

		Partida = GameObject.Find ("Partida"); 
	}

	void OnGUI(){

		//top left width height
		if (GUI.Button (new Rect (left, top, width, height), "VOLTAR")) {
			clicou = true;
			Debug.Log ("voltar");
		}
	}

	void Update(){
		if (clicou) {
			if(left >= -800){
				left -= Time.deltaTime * 1350;
				Partida.GetComponent<Partida>().left -= Time.deltaTime * 1350;
			}
			else{
				Application.LoadLevel("Menu");
			}
		}
	}


}
