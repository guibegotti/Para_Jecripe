using UnityEngine;
using System.Collections;

public class BotoesTenis : MonoBehaviour {

	public Texture2D texture1;

	GameObject atiraBolas;
	GameObject SomFundo;
	GameObject buttons;
	GameObject clickToPlayCanvas;
	
	TennisController TC;

	void Start(){
		atiraBolas = GameObject.Find ("atiraBolas");
		SomFundo = GameObject.Find ("SomFundo");
		clickToPlayCanvas = GameObject.Find ("ClickToPlayCanvas");
		TC = GameObject.Find ("TennisController").GetComponent<TennisController>();
	}
	
	public void LoadMenu(){
		Application.LoadLevel("PlayTennis");
	}



}
