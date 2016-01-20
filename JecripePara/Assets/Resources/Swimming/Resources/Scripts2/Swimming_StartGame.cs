using UnityEngine;
using System.Collections;

public class Swimming_StartGame : MonoBehaviour {

	
	public GameObject text1;
	SwimmingSounds sounds;
	
	void Start(){
	
		text1.SetActive(false);
		Time.timeScale = 1;
		sounds = GameObject.Find("SwimmingSounds").GetComponent<SwimmingSounds>();
		
	}
	
	void Update () {
		
		if(Time.timeSinceLevelLoad >= 1 && Time.timeSinceLevelLoad < 2){
		
			text1.SetActive(true);
		
		} else if(Time.timeSinceLevelLoad >= 2 && Input.GetKeyDown(KeyCode.Space)){
			
			GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController>().StartGame();
			text1.SetActive(false);
			GameObject.Find ("Intro").SetActive(false);
			this.gameObject.SetActive(false);
			sounds.PlaySound(sounds.background);
			sounds.PlaySound(sounds.backgroundPeople);
		}
	
	}
}
