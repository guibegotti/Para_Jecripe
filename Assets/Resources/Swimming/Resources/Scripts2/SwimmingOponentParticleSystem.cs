using UnityEngine;
using System.Collections;

public class SwimmingOponentParticleSystem : MonoBehaviour {

	Timer t;
	SwimmingController sc;

	public ParticleSystem LParticleSystem1;
	public ParticleSystem LParticleSystem2;

	public ParticleSystem RParticleSystem1;
	public ParticleSystem RParticleSystem2;

	float i;

	bool leftSide;


	void Start(){

		t = GetComponent<Timer> ();
		t.SetTimer ();
		leftSide = false;
		i = 1.08f;

	}


	void Update(){

		if (t.time >= i) {

			leftSide = !leftSide;
			OponentParticleSystem (leftSide);
			t.SetTimer ();
			i = 0.8f;
		}
	}

	void OponentParticleSystem(bool leftSide){

		if (leftSide) {

			LParticleSystem1.Play ();
			LParticleSystem2.Play ();

		} else {

			RParticleSystem1.Play ();
			RParticleSystem2.Play ();
		}
	}


}
