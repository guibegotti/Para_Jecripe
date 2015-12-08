using UnityEngine;
using System.Collections;

public class Guidebehaviour : MonoBehaviour {
	
	private Rigidbody rig;
	public Rigidbody rigTutorial;
	private Animator animator;
	public GameObject tutorial;
	
	
	
	void Start () {
		animator = GetComponent<Animator>();
		if(tutorial == this){
			rig = rigTutorial;
		} else{
			rig = transform.parent.GetComponent <Rigidbody> ();
		}
		print (animator);
	}
	
	
	void Update () {
		functionsScript.Animation (rig, animator,playerTutorial.start);		                           
	}
}