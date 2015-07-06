using UnityEngine;
using System.Collections;

public class IniciarJogo : MonoBehaviour {

	public float top;
	float left;
	float width = 100;
	float height = 50;
	
	//left, top, width, height
	
	void Start(){
		
		top = Screen.height * 5/7 - height/2;
		left = Screen.width * 3/4 - width/2;
	}
	
	void OnGUI(){
		
		if (GUI.Button (new Rect (left, top, width, height), "INICIAR")) {

			if(Application.loadedLevelName == "JogoTenis"){
				Application.LoadLevel("treino");
			}
			else if(Application.loadedLevelName == "JogoNatacao"){
				Application.LoadLevel("Natacao");
			}
		}
	}
	
	void Update(){
		if (GetComponent<Left> ().clicou) {
			top += Time.deltaTime * 1350;
		}
	}
}
