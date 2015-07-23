using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TennisController : MonoBehaviour {

	public Text countDownText;
	
	bool countDown;
	float time1 = 90;
	
	void Update(){
	
		if (countDown){
			time1 -= Time.deltaTime;
			countDownText.text = time1.ToString("0.0");
		}
	}
	
	public void SetCountDown(){
		countDown = true;
	}
	
}
