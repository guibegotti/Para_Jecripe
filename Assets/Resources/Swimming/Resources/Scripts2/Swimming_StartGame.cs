using UnityEngine;
using System.Collections;

public class Swimming_StartGame : MonoBehaviour {

	
	public GameObject text1;
	SwimmingSounds sounds;
	Timer t;

	public bool b = false;
	
	void Start(){
	
		text1.SetActive(false);
		Time.timeScale = 1;
		sounds = GameObject.Find("SwimmingSounds").GetComponent<SwimmingSounds>();
		t = GetComponent<Timer> ();
		
	}
	
	void Update () {
		
		if (Time.timeSinceLevelLoad >= 1 && Time.timeSinceLevelLoad < 2) {
		
			text1.SetActive (true);
		
		} else if (Time.timeSinceLevelLoad >= 2 && Input.GetKeyDown (KeyCode.Space)) {

			b = true;
			GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController> ().StartGame ();
			text1.SetActive (false);
			GameObject.Find ("Intro").SetActive (false);
			sounds.PlaySound (sounds.background);
			sounds.PlaySound (sounds.backgroundPeople);

			t.SetTimer ();

		} else if (t.time >= 1.12f) {

			t.ResetTimer ();
			this.gameObject.SetActive (false);
			GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController> ().inWater = true;

		}
	
	}
}
