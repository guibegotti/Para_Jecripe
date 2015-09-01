using UnityEngine;
using System.Collections;

public class AthleticsSounds : MonoBehaviour {

	
	public AudioSource background;
	public AudioSource applause;
	public AudioSource gunShot;
	
	
	void Start(){
		
		gunShot = GameObject.Find ("GunshotSound").GetComponent<AudioSource>();
		applause = GameObject.Find ("ApplauseSound").GetComponent<AudioSource>();
		background = GameObject.Find ("BackgroundSound").GetComponent<AudioSource>();
	}
	
	public void PlayAudio(AudioSource audio){
		
		audio.Play ();
	}
}
