/// 
/// 10/07/2015
/// 
/// <summary>
/// This script gets sounds for corrects and wrong answers. The function will play the sounds.
/// </summary>

using UnityEngine;
using System.Collections;

public class QuizSounds : MonoBehaviour 
{
	// This variables receives and set the sounds.

	public AudioSource rightSound;
	public AudioSource wrongSound;


	void Start()
	{
		rightSound = GameObject.Find ("RightAnswerSound").GetComponent<AudioSource>();
		wrongSound = GameObject.Find ("WrongAnswerSound").GetComponent<AudioSource>();
	}

	/// <summary>
	/// Plaies the sound.
	/// </summary>
	/// <param name="audio">Audio.</param>
	public void PlaySound(AudioSource audio)
	{
		audio.Play();
	}
}
