using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InitialCountdown : MonoBehaviour {

	GameObject countdownCanvas;
	public AudioSource cdAudio; //gunshot sound
	float countdownTime = 3;
	bool doCountdown;
	
	GameObject startCanvas;
	public playerBehaviour2 p;
	AthleticsSounds s;
	
	
	
	Timer t;
	
	public static int c = 0; //counter so that you can only press the space key to start the game once
	
	
	void Start(){
		
		countdownCanvas = GameObject.Find ("Countdown");
		startCanvas = GameObject.Find ("StartCanvas");
		s = GameObject.Find ("Sounds").GetComponent<AthleticsSounds>(); 

		countdownCanvas.SetActive(false);
		
		t = countdownCanvas.GetComponent<Timer>();
		c = 0; 
	}
	
	void Update(){

		
		if (Input.GetKeyDown (KeyCode.Space) && c == 0) {
			
			countdownCanvas.SetActive (true);
			startCanvas.SetActive (false);
			t.SetTimer ();
			c++;
			doCountdown = true;

		} else if (c == 1) {
			
			if (t.time <= 2.5f) { 
				countdownTime = 3.4f - t.time;
				countdownCanvas.GetComponentInChildren<Text> ().text = countdownTime.ToString ("0");
			} else {

				cdAudio.Play ();
				countdownCanvas.SetActive (false);
				GameObject.Find ("terezinha9").GetComponent<playerBehaviour2> ().pronto = true;
				AthleticsController.gameStarted = true;
				doCountdown = false;
				s.PlayAudio (s.background);
				c++;
			}


		} else if (c == 2) {


			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				p.startRunning ();
				c++;
			}
		
		} else if (c == 3) {

			this.gameObject.SetActive (false);


		}


		
	}
	
}
