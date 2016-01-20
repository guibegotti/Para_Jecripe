using UnityEngine;
using System.Collections;

public class SwimmingSounds : MonoBehaviour {

	
	//public AudioSource armStroke;
	public AudioSource mark;
	public AudioSource dive;
	public AudioSource applause;
	public AudioSource leg;
	public AudioSource background;
	static public AudioSource breathing;
	
	public AudioSource armstroke1;
	public AudioSource armstroke2;
	
	public AudioSource backgroundPeople;
	
	AudioSource a;
	bool wait;
	float waitTime;
	float currentWaitingTime = 0;
	
	
	void Start(){
		
		mark = GameObject.Find ("MarkSound").GetComponent<AudioSource>();
		dive = GameObject.Find ("DiveSound").GetComponent<AudioSource>();
		applause = GameObject.Find("ApplauseSound").GetComponent<AudioSource>();
		leg = GameObject.Find ("LegSound").GetComponent<AudioSource>();
		background = GameObject.Find ("AmbientSound").GetComponent<AudioSource>();
		breathing = GameObject.Find ("BreathingSound").GetComponent<AudioSource>();
		backgroundPeople = GameObject.Find ("BackgroundNoise").GetComponent<AudioSource>();
		armstroke1 = GameObject.Find("ArmStrokeSound1").GetComponent<AudioSource>();
		armstroke2 = GameObject.Find("ArmStrokeSound2").GetComponent<AudioSource>();
	}
	
	void Update(){
	
		if(wait){
			if(currentWaitingTime < waitTime){
				currentWaitingTime += Time.deltaTime;
			} else {
				currentWaitingTime = 0;
				PlaySound(a);
				wait = false;
			}
		}
		
	}
	
	public void PlaySound(AudioSource audio){
	
		audio.Play();
	}
	
	public void WaitPlay(float time, AudioSource audio){
	
		a = audio;
		waitTime = time;
		wait = true;
	}
	
	public void MuteSounds(bool b){
	
		//armStroke.mute = !b;
		breathing.mute = !b;
		
		
	}
	
	public void ArmStrokeSound(){
		
		if(armstroke1.isPlaying == false){
			armstroke1.PlayDelayed(0.3f);
		} else {
			armstroke2.PlayDelayed(0.3f);
		}
	}
	
}
