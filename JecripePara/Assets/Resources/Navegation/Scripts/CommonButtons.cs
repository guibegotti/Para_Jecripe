using UnityEngine;
using System.Collections;

public class CommonButtons : MonoBehaviour {

	
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
	
	
}
