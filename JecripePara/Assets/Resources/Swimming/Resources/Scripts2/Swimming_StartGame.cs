using UnityEngine;
using System.Collections;

public class Swimming_StartGame : MonoBehaviour {

	
	public GameObject text1;
	
	void Start(){
	
		text1.SetActive(false);
		
	}
	
	void Update () {
		
		if(Time.timeSinceLevelLoad >= 1 && Time.timeSinceLevelLoad < 2){
		
			text1.SetActive(true);
		
		} else if(Time.timeSinceLevelLoad >= 2 && Input.GetKeyDown(KeyCode.Space)){
			
			GetComponent<SwimmingGameController>().StartGame();
			text1.SetActive(false);
			Destroy(GameObject.Find ("Intro"));
		}
	
	}
}
