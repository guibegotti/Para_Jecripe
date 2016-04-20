using UnityEngine;
using System.Collections;

/// <summary>
/// The script used on the first scene the player encounters once they open the game.
/// It determines that the menu scene will be loaded after the player clicks or presses any button on the keyboard.
/// </summary>

public class StartScene : MonoBehaviour {

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update(){
		if(Input.anyKeyDown){
			Application.LoadLevel("Menu");
		}
	}
	
}
