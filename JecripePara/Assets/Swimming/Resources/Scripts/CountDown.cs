using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour
{

	
	public float seconds = 3;
	bool showCountdown;
	bool countdown;
	Timer Timer;
	public string secString;
	public GameObject waitButton;
	public Text waitText;
	
	
	
	void Start ()
	{
		Timer = GetComponent<Timer>();
		waitButton = GameObject.Find ("Wait");
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
			secString = seconds.ToString("0");
			waitButton.SetActive(true);
			waitText.text = "AGUARDE\n " + secString;
		} else if (seconds <= 0){
			countdown = false;
			showCountdown = false;
			waitButton.SetActive(false);
		}
	}

	/*
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
		
	}*/
	
}
