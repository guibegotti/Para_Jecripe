using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AthleticsController : MonoBehaviour {
	
	
	GameObject gameOverCanvas;
	GameObject canvas;
	public Text result;
	//AthleticsSounds Sounds;
	
	public bool gameOver;
	
	
	void Start () {
		
	
		canvas = GameObject.Find("Canvas");
		//Sounds = GameObject.Find ("Sounds").GetComponent<AthleticsSounds>();
		
		gameOverCanvas.SetActive(false);
		
	}
	
	
	
	public void Reload(){
		
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	public void BackToMenu(){
		Application.LoadLevel ("PlayAthletics");
	}
	
	
	
}