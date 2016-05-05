using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AthleticsController : MonoBehaviour
{
	

	GameObject canvas;
	GameObject pauseCanvas;
	GameObject balloon1;

	public static bool gameStarted;

	
	void Start () 
	{

		canvas = GameObject.Find("Canvas");
		balloon1 = GameObject.Find ("balloon1");
		balloon1.GetComponentInChildren<Text>().text = "";
		pauseCanvas = GameObject.Find ("PauseCanvas");
		pauseCanvas.SetActive(false);
		
	}
	
	void Update() 
	{
		
		if(Input.GetKeyDown(KeyCode.P))
		{
		
			PauseGame();
		}
		
		if (Time.timeSinceLevelLoad >= 1.3f && InitialCountdown.c == 0)
		{
			
			balloon1.GetComponentInChildren<Text>().text = "Aperte ESPAÇO para começar! Boa sorte!";
		}
	}
	
	public void Reload(){
		
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	public void BackToMenu()
	{

		Application.LoadLevel ("PlayAthletics");
	}
	
	
	public void PauseGame()
	{
		
		if (pauseCanvas.activeSelf == true) 
		{
			pauseCanvas.SetActive (false);
			Time.timeScale = 1;

		} else 
		{
		
			pauseCanvas.SetActive (true);
			Time.timeScale = 0;
		}
	}
	
}