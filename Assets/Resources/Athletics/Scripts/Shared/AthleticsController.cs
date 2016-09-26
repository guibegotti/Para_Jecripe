using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AthleticsController : MonoBehaviour
{
	

	GameObject canvas;
	GameObject pauseCanvas;
	GameObject balloon1;
	public GameObject settingsCanvas;
	public bool paused;

	public static bool gameStarted;

	
	void Start () 
	{

		canvas = GameObject.Find("Canvas");
		//balloon1 = GameObject.Find ("balloon1");
		//balloon1.GetComponentInChildren<Text>().text = "";
		pauseCanvas = GameObject.Find ("PauseCanvas");
		pauseCanvas.SetActive(false);
		paused = false;

	}
	
	void Update() 
	{
		
		if(Input.GetKeyDown(KeyCode.P))
		{
			PauseGame();
		}

	}

	
	public void PauseGame()
	{

		if (paused == true) {

			pauseCanvas.SetActive (false);
			settingsCanvas.SetActive (false);
			Time.timeScale = 1;
			paused = false;

		}
		 else 
		{
			pauseCanvas.SetActive (true);
			Time.timeScale = 0;
			paused = true;
		}
	}
	
}