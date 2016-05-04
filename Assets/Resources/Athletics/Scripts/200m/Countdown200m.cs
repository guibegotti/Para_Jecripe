using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Countdown200m : MonoBehaviour {

	GameObject countdownCanvas;
	public AudioSource cdAudio; //gunshot sound
	float countdownTime = 3;
	bool doCountdown;

	GameObject startCanvas;



	Timer t;

	public static int c = 0; //counter so that you can only press the space key to start the game once


	void Start(){

		countdownCanvas = GameObject.Find ("Countdown");
		startCanvas = GameObject.Find ("StartCanvas");
		countdownCanvas.SetActive(false);

		t = countdownCanvas.GetComponent<Timer>();
		c = 0; 
	}

	void Update(){

		if(doCountdown){
			if(t.time <= 2.5f){ 

				countdownTime = 3.4f - t.time;
				countdownCanvas.GetComponentInChildren<Text>().text = countdownTime.ToString("0");


			} else {

				cdAudio.Play();
				countdownCanvas.SetActive(false);
				GameObject.Find("terezinha9").GetComponent<terezinhaBehaviour_200m>().pronto = true;
				doCountdown = false;
			}
		}


		if(Input.GetKeyDown(KeyCode.Space) && c == 0){

			countdownCanvas.SetActive(true);
			startCanvas.SetActive(false);
			t.SetTimer();
			c++;
			doCountdown = true;
		}

	}

}
