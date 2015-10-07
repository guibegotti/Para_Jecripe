﻿using UnityEngine;
using System.Collections;

public class Guidebehaviour : MonoBehaviour {
	
	private Rigidbody rig;
	private Animator animator;
	
	
	
	void Start () {
		rig = transform.parent.GetComponent <Rigidbody> ();
		animator = GetComponent<Animator>();
		
	}
	
	
	void Update () {
		functionsScript.Animation (rig, animator);		                           
	}
}