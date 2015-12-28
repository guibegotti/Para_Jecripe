using UnityEngine;
using System.Collections;

public class Guidebehaviour : MonoBehaviour {
	
	private Rigidbody rig;
	public Rigidbody rigTutorial;
	private Animator animator;
	public GameObject tutorial;
	
	public bool ttuturial;
	
	
	
	void Start () {
		animator = GetComponent<Animator>();
		if(tutorial == this){
			rig = rigTutorial;
		} else{
			rig = transform.parent.GetComponent <Rigidbody> ();
		}
	}
	
	
	void Update () {
		
		if(ttuturial == false){
			functionsScript.Animation (rig, animator,playerBehaviour2.começa);       
		} else {
			functionsScript.Animation (rig, animator, playerTutorial.start);       
		}
		                       
	}
	
	
	
}