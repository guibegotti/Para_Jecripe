using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Athletics_ScoreboardTimer : MonoBehaviour {


	Image timer;

	void Start(){
	
		timer = this.gameObject.GetComponent<Image> ();
	}



	void Update () {

		if (timer.fillAmount < 1) {
		
			timer.fillAmount += Time.deltaTime / 60f;
		} else {

			timer.fillAmount = 0;
		}

	}
}
