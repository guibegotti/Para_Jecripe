using UnityEngine;
using System.Collections;

public class LongJump_GameController : MonoBehaviour {

	GameObject pauseCanvas;
	GameObject canvas1;
	GameObject startCanvas;

	LongJumpSounds sounds;

	public GameObject settingsCanvas;


	bool started;
	
	void Start(){
		
		pauseCanvas = GameObject.Find ("PauseCanvas");
		pauseCanvas.SetActive(false);
        started = false;
		canvas1 = GameObject.Find ("Canvas");
		sounds = GameObject.Find ("Sounds").GetComponent<LongJumpSounds> ();
		
		startCanvas = GameObject.Find ("StartCanvas");
        Time.timeScale =  1;
	}
	
	void Update(){
		
		if(Input.GetKeyDown(KeyCode.P)){
			
			PauseGame();
			
		}
		
	}

	public void StartGame(){

		started = true;
		startCanvas.SetActive(false);
		GameObject.Find ("veronica3").GetComponent<veronica_Behaviour>().NewJump();
		sounds.PlayAudio (sounds.background);
	}

	public void PauseGame(){
	
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			canvas1.SetActive(false);
		} else if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			settingsCanvas.SetActive (false);
			canvas1.SetActive(true);
		}
	}
	
	
	
	
}
