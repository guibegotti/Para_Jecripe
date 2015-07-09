using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour
{

	
	public float seconds = 3;
	bool showCountdown;
	bool countdown;
	Timer Timer;
	
	
	void Start ()
	{
		Timer = GetComponent<Timer>();
	}
	
	void Update(){
		
		if(countdown){
			DoCountdown();
		}
	}
	
	
	public void SetCountdown ()
	{
		Timer.SetTimer();
		seconds = 3;
		showCountdown = true;
		countdown = true;
		
	}
	
	void DoCountdown(){
		if(seconds > 0){
			seconds -= Time.deltaTime;
		} else if (seconds <= 0){
			countdown = false;
			showCountdown = false;
		}
	}

	void OnGUI ()
	{
		
		float width = 20;
		float height = 50;
		
		GUI.skin.label.fontSize = 26;
		GUI.skin.label.normal.textColor = Color.black;
		GUI.skin.label.hover.textColor = Color.black;
		
		if(showCountdown){
			GUI.Label (new Rect (Screen.width * 1 / 2 - width * 1 / 2, Screen.height * 1 / 5 - height * 1 / 2, width, height), seconds.ToString ("0"));
		}
		
	}
	
}
