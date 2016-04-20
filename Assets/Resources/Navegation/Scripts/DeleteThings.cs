using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeleteThings : MonoBehaviour {

	
	public List<GameObject> delete;
	
	
	public float deleteWhen;
	
	
	void Update(){
	
		if(Time.timeSinceLevelLoad >= deleteWhen){
		
			foreach(GameObject g in delete){
				DestroyImmediate(g);
			}
		}
	}
	
	
}
