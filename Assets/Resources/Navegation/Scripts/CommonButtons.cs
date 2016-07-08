using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CommonButtons : MonoBehaviour {

	
	public string scene;
	public string text2String;
	GameObject text2;

	public GameObject g1;
	public GameObject g2;

	
	public void QuitApp(){
		
		Application.Quit();
	}
	
	public void MuteSounds(){
		
		if(AudioListener.pause == false){
			AudioListener.pause = true;
		} else {
			AudioListener.pause = false;
		}
	}
	
	public void LoadScene(){
		
		Application.LoadLevel(scene);
	}
	
	
	public void ReloadScene(){
		
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void ShowText(string text){
	
		text2 = GameObject.Find("ChangingText");
		text2.GetComponent<Text>().text = text2String;
	}
	
	public void ClearText(){
	
		text2 = GameObject.Find("ChangingText");
		text2.GetComponent<Text>().text = "";
	}

	public void SetFullscreen() {

		Screen.fullScreen = !Screen.fullScreen; 
	}


	public void ActivateGO(){

		g1.SetActive (true);
		g2.SetActive (false);
	}


	
	
	
}
