using UnityEngine;
using System.Collections;

public class SwimmingTimeController : MonoBehaviour {

	Timer gameTimer;
	public bool gameStarted;
	public bool raceStarted;
	
	SwimmingSounds sounds;
	
	float time;
	
	void Start () {
		
		gameTimer = GetComponent<Timer>();
		sounds = GameObject.Find ("Sounds").GetComponent<SwimmingSounds>();
	}
	
	
	void Update () {
	
		time = gameTimer.time;
		
		if(time >= 3.5){
			Debug.Log ("3.5 segundos!!");
			sounds.PlaySound(sounds.mark);
			gameStarted = true;
			StopCountingTime();
		}
	}
	
	public void StartCountingTime(){
	
		gameTimer.SetTimer();
	}
	
	void StopCountingTime(){
		
		gameTimer.ResetTimer();
	}
}
