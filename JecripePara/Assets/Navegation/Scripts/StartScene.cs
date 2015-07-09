using UnityEngine;
using System.Collections;

public class StartScene : MonoBehaviour {

	void Update(){
		if(Input.anyKeyDown){
			Application.LoadLevel("Menu");
		}
	}
	
}
