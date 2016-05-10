using UnityEngine;
using System.Collections;

public class LongJump_TriggerCollider : MonoBehaviour {


	void OnTriggerEnter(Collider other){

		LongJump_Tutorial.count = 4;
	
	}
}
