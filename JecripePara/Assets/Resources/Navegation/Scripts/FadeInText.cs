using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FadeInText : MonoBehaviour {

	
	public Text t1;
	float cx; //alpha color i.e. how transparent the image is
	public float startFadeIn;
	
	
	void Start(){
	
		cx = 0;
		t1.color = new Color(1, 1, 1, cx);
	}
	
	void Update(){
		
		if(Time.timeSinceLevelLoad >= startFadeIn){
			t1.color = new Color (1, 1, 1, cx);
			cx += 0.8f * Time.deltaTime;
		}
		
	}
	
}
