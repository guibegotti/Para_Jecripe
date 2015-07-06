using UnityEngine;
using System.Collections;

public class CorBotoes : MonoBehaviour {

	public Texture2D texture1;

	void OnGUI(){
	
		
		//left, top, width, height
		
		GUI.skin.button.hover.textColor = Color.blue;
		GUI.skin.button.normal.textColor = Color.black;
		
		GUI.skin.button.normal.background = texture1;
		GUI.skin.button.hover.background = texture1;
		GUI.skin.button.active.background = texture1;

		
		
	}
}
