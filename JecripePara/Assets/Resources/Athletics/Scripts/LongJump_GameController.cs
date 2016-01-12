using UnityEngine;
using System.Collections;

public class LongJump_GameController : MonoBehaviour {

	GameObject pauseCanvas;
	GameObject canvas1;
	
	void Start(){
		
		pauseCanvas = GameObject.Find ("PauseCanvas");
		pauseCanvas.SetActive(false);
		
		canvas1 = GameObject.Find ("Canvas");
	}
	
	void Update(){
		
		if(Input.GetKeyDown(KeyCode.P)){
			
			PauseGame();
		}
	}
	
	
	public void PauseGame(){
	
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			canvas1.SetActive(false);
		} else if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			canvas1.SetActive(true);
		}
	}
	
	
	
	
}
