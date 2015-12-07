using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tutorialController : MonoBehaviour {

	private GameObject TutorialCanvas, GameOver, TutorialInstructions;
	public Text text;

	void Start () {

		TutorialCanvas = GameObject.Find ("TutorialCanvas");
		GameOver = GameObject.Find ("Game");
		GameOver.SetActive(false);
		TutorialCanvas.SetActive (false);

	}

	void TutorialScreen(GameObject TutorialCanvas, string instrunctions, Text text){
		bool b = false;
		while(!b){
			text.text = instrunctions;
			Time.timeScale = 0;
			TutorialCanvas.SetActive (true);
			if(Input.GetKeyDown (KeyCode.Space)){
				TutorialCanvas.SetActive(false);
				b = true;
				Time.timeScale = 1;
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
