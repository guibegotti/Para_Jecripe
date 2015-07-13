using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour
{

	
	public float seconds = 3;
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
		countdown = true;
		waitButton.SetActive(true);
		
	}
	
	void DoCountdown(){
		if(seconds > 0){
			seconds -= Time.deltaTime;
			secString = seconds.ToString("0");
			waitText.text = "AGUARDE\n " + secString;
		} else if (seconds <= 0){
			countdown = false;
			waitButton.SetActive(false);
		}
	}


	
}
