using UnityEngine;
using System.Collections;

public class AthleticsSounds : MonoBehaviour {

	
	public AudioSource background;
	public AudioSource applause;
	public AudioSource gunShot;
	public AudioSource step;
	public AudioClip gun;

	
	
	void Start(){
		
		gunShot = GameObject.Find ("GunshotSound").GetComponent<AudioSource>();
		applause = GameObject.Find ("ApplauseSound").GetComponent<AudioSource>();
		background = GameObject.Find ("BackgroundSound").GetComponent<AudioSource>();
		step = GameObject.Find ("StepSound").GetComponent<AudioSource>();


	}
	
	public void PlayAudio(AudioSource audio){

		audio.Play ();
		//audio.mute = true;
		
	}

	void Update(){

		if (playerBehaviour2.começa) {

			gunShot.Play ();

		}

	}

	public void LowerAudio(AudioSource audio, float time){
	
		if (audio.volume > 0) {

			audio.volume = 1 - (Time.deltaTime / time);

		}


	}

	public void HigherAudio(AudioSource audio, float time){
		
		if (audio.volume < 1) {
			
			audio.volume = 0 + (Time.deltaTime / time);
			
		}
		
		
	}

}
