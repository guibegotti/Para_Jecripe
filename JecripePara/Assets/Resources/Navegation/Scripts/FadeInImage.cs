using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;


public class FadeInImage : MonoBehaviour {

	
	
	public Image i1;
	float cx; //alpha color i.e. how transparent the image is
	
	public float startFadeIn;
	
	void Start(){
		
		cx = 0;
		i1.color = new Color (1, 1, 1, cx);
	}
	
	void Update(){
		
		if(Time.timeSinceLevelLoad >= startFadeIn){
			cx += 0.6f * Time.deltaTime;
			i1.color = new Color (1, 1, 1, cx);
		}
	}
	
	
	
}
