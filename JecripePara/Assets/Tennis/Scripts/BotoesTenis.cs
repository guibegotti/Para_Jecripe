using UnityEngine;
using System.Collections;

public class BotoesTenis : MonoBehaviour {

	public Texture2D texture1;

	GameObject atiraBolas;
	GameObject SomFundo;

	bool botJogar;

	void Start(){
		atiraBolas = GameObject.Find ("atiraBolas");
		SomFundo = GameObject.Find ("SomFundo");
		botJogar = true;
	}
	
	public void LoadMenu(){
		Application.LoadLevel("PlayTennis");
	}


	void OnGUI(){

		float width = 100;
		float height = 35;
		
		float width2 = 250;
		float height2 = 60;

		float width3 = 160;
		float height3 = 80;

		GUI.skin.box.normal.background = texture1;
		GUI.skin.box.hover.background = texture1;
		GUI.skin.box.active.background = texture1;

		GUI.skin.box.normal.textColor = Color.black;
		GUI.skin.box.hover.textColor = Color.black;
		GUI.skin.box.active.textColor = Color.black;

		GUI.skin.button.normal.background = texture1;
		GUI.skin.button.hover.background = texture1;
		GUI.skin.button.active.background = texture1;

		GUI.skin.button.normal.textColor = Color.black;
		GUI.skin.button.hover.textColor = Color.blue;
		GUI.skin.button.active.textColor = Color.black;


		if(GUI.Button(new Rect(Screen.width * 4/5 - width/2, Screen.height * 4/5 - height/2, width, height), "REINICAR")){
			Application.LoadLevel(Application.loadedLevel);
		}
		if(GUI.Button(new Rect(Screen.width * 4/5 - width/2, Screen.height * 4/5 + height/2 + 10, width, height), "VOLTAR")){
			Application.LoadLevel("JogarTenis");
		}

		if (botJogar) {

			if(GUI.Button(new Rect(Screen.width * 1/2 - width3/2, Screen.height * 1/2 - height3/2, width3, height3), "CLIQUE PARA\nJOGAR TÊNIS")){
				atiraBolas.GetComponent<atiraBolas>().comecar = true;
				SomFundo.GetComponent<AudioSource>().Play();
				botJogar = false;
			}
		}

		string instrucoes = "INSTRUÇÕES:\nUse as setas para mover-se.\nAperte espaço para rebater a bola.";
		
		//left, top, width, height
		GUI.Box (new Rect (Screen.width * 1/4 - width2/2, Screen.height * 4/5 - height2/2, width2, height2), instrucoes);
		
		
	}

}
