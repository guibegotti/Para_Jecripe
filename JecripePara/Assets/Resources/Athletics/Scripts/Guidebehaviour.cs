using UnityEngine;
using System.Collections;

public class Guidebehaviour : MonoBehaviour {

	private Rigidbody rig;
	private Animator animator;


	void Anima ()
	{
		
		if (playerBehaviour2.start ) {
			if (rig.velocity != new Vector3 (0, 0, 0)) {
				animator.SetBool ("inIdle", false);
				animator.SetBool ("inRun", true);
				animator.SetBool ("inStart", false);
			} else {
				animator.SetBool ("inIdle", true);
				animator.SetBool ("inRun", false);
				animator.SetBool ("inStart", false);
			}
		} else {
			animator.SetBool ("inIdle", false);
			animator.SetBool ("inRun", false);
			animator.SetBool ("inStart", true);
		}
	}
	void Start () {
		rig = GameObject.Find ("Terezinha").GetComponent<Rigidbody >();
		animator = GameObject.Find ("Guilherme").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Anima ();
	}
}
