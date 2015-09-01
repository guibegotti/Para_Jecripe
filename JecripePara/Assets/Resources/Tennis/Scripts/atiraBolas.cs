using UnityEngine;
using System.Collections;

public class atiraBolas : MonoBehaviour {

	public float tempoDelay;
	private float delay;
	public GameObject bola;
	private BallController b;
	private AudioSource a;
	public bool comecar;

	// Use this for initialization
	void Start () {
		a = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > delay && comecar == true) {
			delay =  Time.time + tempoDelay;			
			GameObject bolaClone = Instantiate (bola, transform.position, Quaternion.Euler (0f, 0f, 0f)) as GameObject;
			b = bolaClone.GetComponent<BallController>();
			b.atiraBolas = true;
			a.Play();
		}
	}
}
