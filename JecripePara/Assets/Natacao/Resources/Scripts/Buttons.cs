using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
	
	GameObject gameOver;
	GameObject breathing;
	GameObject instructions;
	GameObject canvas1;
	Bracadas b;
	
	void Start(){
		gameOver = GameObject.Find ("GameOver");
		gameOver.SetActive(false);
		b = GameObject.Find("Bracadas").GetComponent<Bracadas>();
		instructions = GameObject.Find ("Instructions");
		canvas1 = GameObject.Find ("Canvas1");
		canvas1.SetActive(false);
		Time.timeScale = 0;
		
		//breathing = GameObject.Find ("Breathing").GetComponent<Breathing>();
	}
	
	
	public void ReloadLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void GameOver(){
		gameOver.SetActive(true);
		b.armStrokeOK = false;
		b.square.enabled = false;
		Time.timeScale = 0;
	}
	
	public void StartGame(){
		Time.timeScale = 1;
		instructions.SetActive(false);
		canvas1.SetActive(true);
	}
	
	public void LoadMenu(){
		Application.LoadLevel("Menu");
	}

	
}
