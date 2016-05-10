using UnityEngine;
using System.Collections;

public class LongJumpSounds : MonoBehaviour {

	public AudioSource background;
	public AudioSource applause;


	void Start(){

		applause = GameObject.Find ("ApplauseSound").GetComponent<AudioSource>();
		background = GameObject.Find ("BackgroundSound").GetComponent<AudioSource>();
	}


	public void PlayAudio(AudioSource audio){
		
		audio.Play ();
	}
		


}
