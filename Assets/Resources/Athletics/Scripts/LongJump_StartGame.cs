using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LongJump_StartGame : MonoBehaviour {



	static int c;
	GameObject startCanvas;
	public GameObject countdown;
	LongJump_GameController gc;
	Timer t;
	float countdownTime = 3;


	void Start () {
	
		c = 0;
		startCanvas = GameObject.Find ("StartCanvas");
		gc = GameObject.Find ("GameController").GetComponent<LongJump_GameController> ();
		t = GetComponent<Timer> ();

	}

	void Update () {


		if (c == 0 && Input.GetKeyDown (KeyCode.Space)) {

			startCanvas.SetActive (false);
			countdown.SetActive (true);
			c++;
			t.SetTimer ();


		} else if (c == 1) {

			if (t.time <= 2.5f) { 
				countdownTime = 3.4f - t.time;
				countdown.GetComponentInChildren<Text> ().text = countdownTime.ToString ("0");

			} else {
				
				countdown.SetActive (false);
				gc.StartGame ();
				c++;
			}
		} else if (c == 2) {

			this.gameObject.SetActive (false); 
		}
	
	}
}
