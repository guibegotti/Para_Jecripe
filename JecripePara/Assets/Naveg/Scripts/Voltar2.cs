using UnityEngine;
using System.Collections;

public class Voltar2 : MonoBehaviour {

	GameObject Musica;
	GameObject Loja;
	
	bool clicou;
	float left;
	float top;
	float width = 70;
	float height = 50;
	
	void Start(){
		left = Screen.width * 4/5 - width /2;
		top = Screen.height * 7/8 - height / 2;
		Loja = GameObject.Find("Loja");
		Musica = GameObject.Find ("Musica");
	}

	void OnGUI(){
		//left, top, width, height
		if (GUI.Button(new Rect(left, top, width, height), "VOLTAR")){
			
			Musica.GetComponent<AudioSource>().Stop();
			if(GetComponent<AudioSource>().isPlaying == false){
				GetComponent<AudioSource>().Play();
			}
			clicou = true;
		}
	}
	
	void Update(){
		if (clicou){
		
			if(top >= -500){
				top -= Time.deltaTime * 1000;
				Loja.transform.position = new Vector3 (Loja.transform.position.x, Loja.transform.position.y + Time.deltaTime * 30, Loja.transform.position.z);
			}
			else{
				Application.LoadLevel("Menu");
			}
			
		}
	}
}
