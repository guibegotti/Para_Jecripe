using UnityEngine;
using System.Collections;

public class PlayAudioWhen : MonoBehaviour {

	public float startAudio;
	public AudioSource a;
	
	void Update(){
	
		if(Time.timeSinceLevelLoad >= startAudio){
		
			a.Play();
			DestroyImmediate(this);
		}
		
	}
}
