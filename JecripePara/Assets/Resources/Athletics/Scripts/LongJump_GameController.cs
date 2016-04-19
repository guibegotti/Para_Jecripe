using UnityEngine;
using System.Collections;

public class LongJump_GameController : MonoBehaviour {

	GameObject pauseCanvas;
	GameObject canvas1;
	GameObject startCanvas;
	
	bool started;
	
	void Start(){
		
		pauseCanvas = GameObject.Find ("PauseCanvas");
		pauseCanvas.SetActive(false);
        started = false;
		canvas1 = GameObject.Find ("Canvas");
		
		startCanvas = GameObject.Find ("StartCanvas");
	}
	
	void Update(){
		
		if(Input.GetKeyDown(KeyCode.P)){
			
			PauseGame();
			
		} else if (started == false){
			if(Input.GetKeyDown(KeyCode.Space)){
                started = true;
				startCanvas.SetActive(false);
				GameObject.Find ("veronica3").GetComponent<veronica_Behaviour>().NewJump();
			}
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
