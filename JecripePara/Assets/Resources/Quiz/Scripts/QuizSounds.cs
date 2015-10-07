using UnityEngine;
using System.Collections;

public class QuizSounds : MonoBehaviour 
{

	public AudioSource rightAnswerSound;
	public AudioSource wrongAnswerSound;
	
	void Start()
	{
		rightAnswerSound = GameObject.Find ("RightAnswerSound").GetComponent<AudioSource>();
		wrongAnswerSound = GameObject.Find ("WrongAnswerSound").GetComponent<AudioSource>();
	}
	
	public void PlaySound(AudioSource audio)
	{
		audio.Play();
	}
}
