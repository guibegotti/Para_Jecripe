using UnityEngine;
using System.Collections;

public class BallShooter : MonoBehaviour {

	public float delayTime;
	private float delay;
	public GameObject ball;
	private BallController bC;
	private AudioSource aSource;
	public bool start;

	// Use this for initialization
	void Start () {
		aSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > delay && start == true) {
			delay =  Time.time + delayTime;			
			GameObject ballClone = Instantiate (ball, transform.position, Quaternion.Euler (0f, 0f, 0f)) as GameObject;
			bC = ballClone.GetComponent<BallController>();
			bC.ballShooter = true;
			aSource.Play();
		}
	}
}
