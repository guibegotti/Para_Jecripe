using UnityEngine;
using System.Collections;

public class SwimmingTutorial_TriggerCollider : MonoBehaviour {


	void OnTriggerEnter(Collider other){


		Application.LoadLevel ("Swimming");
	}

}
