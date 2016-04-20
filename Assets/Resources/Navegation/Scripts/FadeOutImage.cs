using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeOutImage : MonoBehaviour {

	
	public float startFadeOut;
	public Image i1;
	float cx;
	
	
	void Start(){
	
		cx = i1.color.a;
	}
	
	void Update () {
	
		if(cx > 0 && Time.timeSinceLevelLoad >= startFadeOut){
			
			cx -= 0.7f * Time.deltaTime;
			i1.color = new Color (1, 1, 1, cx);
		}
	
	}
}
