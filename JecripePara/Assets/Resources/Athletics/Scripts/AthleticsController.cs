using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AthleticsController : MonoBehaviour {
	
	
	public GameObject gameOverCanvas;
	GameObject canvas;
	GameObject pauseCanvas;
	//AthleticsSounds Sounds;
	
	public bool gameOver;
	
	
	
	
	void Start () {

		canvas = GameObject.Find("Canvas");
		//canvas.SetActive (false);
		//gameOverCanvas.SetActive(false);
		pauseCanvas = GameObject.Find ("PauseCanvas");
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
		
		if (pauseCanvas.activeSelf == true) {
			pauseCanvas.SetActive (false);
			Time.timeScale = 1;

		} else {
			pauseCanvas.SetActive (true);

			Time.timeScale = 0;
		}
	}
	
	
	
	
}