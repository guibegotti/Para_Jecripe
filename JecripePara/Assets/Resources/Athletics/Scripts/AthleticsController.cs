using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AthleticsController : MonoBehaviour {

	
	public GameObject gameOverCanvas;
	GameObject canvas;
	public Text result;
	GameObject pauseCanvas;
	//AthleticsSounds Sounds;
	
	public bool gameOver;
	
	
	
	
	void Start () {
	
		canvas = GameObject.Find("Canvas");
		//Sounds = GameObject.Find ("Sounds").GetComponent<AthleticsSounds>();
		canvas.SetActive (false);
		gameOverCanvas.SetActive(false);
		pauseCanvas = GameObject.Find ("PauseCanvas 1");
		pauseCanvas.SetActive(false);
		
	}
	
	void Update() {
		
		if(Input.GetKeyDown(KeyCode.P)){
			PauseGame();
		}
	}
	
	public void Reload(){
		
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	public void BackToMenu(){
	
		Application.LoadLevel ("PlayAthletics");
	}
	
	
	public void PauseGame(){
		
		if(pauseCanvas.activeSelf == true){
			pauseCanvas.SetActive(false);
		} else {
			pauseCanvas.SetActive(true);
		}
		
	}
	
	
}