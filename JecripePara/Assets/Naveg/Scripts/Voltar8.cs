using UnityEngine;
using System.Collections;

public class Voltar8 : MonoBehaviour {

	bool clicou;
	float width = 70;
	float top;
	float height = 30;
	public float left;
	
	
	void Start(){
		left = Screen.width * 3/4 - width / 2;
		top = Screen.height * 6/7 - height / 2;
	}
	
	void OnGUI(){
		//left, top, width, height
		if (GUI.Button(new Rect(left, top, width, height), "VOLTAR")){
			
			GetComponent<Left>().nivel = "Esportes";
			GetComponent<Left>().left = left;
			GetComponent<Left>().clicou = true;
		}
		
	}
	
	void Update(){
		if (GetComponent<Left> ().clicou) {
			top += Time.deltaTime * 1350;
		}
	}
}
