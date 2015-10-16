using UnityEngine;
using System.Collections;

public class SetTimeScale : MonoBehaviour {

	public bool timeScale03;
	

	void Update () {
	
	
		/// <summary>
		/// Sets the time Scale to 0.3
		/// </summary>
		if(timeScale03){
			Time.timeScale = 0.3f;
		}
		
	
	}
	
	
	
}
