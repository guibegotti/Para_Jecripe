using UnityEngine;
using System.Collections;

public class TennisTrainning_StartGame : MonoBehaviour {


	public GameObject startText;
	
	
	void Start () {
	
		startText.SetActive(false);
	
	}
	
	
	void Update () {
	
		if(Time.timeSinceLevelLoad > 1.2f){
			
			startText.SetActive (true);
			if(Input.GetKeyDown(KeyCode.Space)){
				
				GameObject.Find ("TennisController").GetComponent<TennisController>().StartGame();
				this.gameObject.SetActive(false);
			}
		}
		
		
	
	}
}
