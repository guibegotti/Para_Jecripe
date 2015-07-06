using UnityEngine;
using System.Collections;

public class Voltar3 : MonoBehaviour {

	GameObject Musica;
	GameObject Creditos;
	bool clicou;
	float left;
	float top;
	

	void Start(){
		
		Creditos = GameObject.Find ("Creditos");
		left = Screen.width / 2 - 40;
		Musica = GameObject.Find("Musica");
	}
	
	void OnGUI(){
		//left, top, width, height
		if (GUI.Button(new Rect(left, top, 80, 50), "VOLTAR")){
			
			
			Musica.GetComponent<AudioSource>().Stop();
			if(GetComponent<AudioSource>().isPlaying == false){
				GetComponent<AudioSource>().Play();
			}
			clicou = true;
		}
	}
	
	void Update(){
		
		top = Creditos.GetComponent<Creditos>().top + Creditos.GetComponent<Creditos>().height + 20;
		
		if (clicou){
			if (left >= -500){
				left -= Time.deltaTime * 1350;
				Creditos.GetComponent<Creditos>().left -= Time.deltaTime * 1350;
				
			}
			else{
				Application.LoadLevel ("Inicio");
			}
		}
	}
	
	
}
