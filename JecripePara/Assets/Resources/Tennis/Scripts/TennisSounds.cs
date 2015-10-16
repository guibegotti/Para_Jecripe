using UnityEngine;
using System.Collections;

public class TennisSounds : MonoBehaviour {

	
	public AudioSource applause;
	public AudioSource ball;
	public AudioSource racket;
	public AudioSource playerMoan;
	public AudioSource background;
	
	
	
	void Start () {
		applause = GameObject.Find("ApplauseSound").GetComponent<AudioSource>();
		ball = GameObject.Find("BallSound").GetComponent<AudioSource>();
		racket = GameObject.Find ("RacketSound").GetComponent<AudioSource>();
		playerMoan = GameObject.Find("MoanSound").GetComponent<AudioSource>();
		background = GameObject.Find ("AmbientSound").GetComponent<AudioSource>();
	
	}
	
	
	public void PlaySound(AudioSource audio){
		audio.Play();
	}
	
	public void StopPlaying(AudioSource audio){
		audio.Pause();
	}
	
}
