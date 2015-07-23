using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TennisController : MonoBehaviour {

	public Text countDownText;
	public Text pointsText;
	
	bool countDown;
	float time1 = 90;
	int points = 0;
	
	
	
	void Update(){
	
		if (countDown){
			time1 -= Time.deltaTime;
			countDownText.text = time1.ToString("0.0");
		}
	}
	
	public void SetCountDown(){
		countDown = true;
	}
	
	public void addPoints(int pointsToAdd){
		
		points += pointsToAdd;
		pointsText.text = points.ToString();
	}
	
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void BackToMenu(){
		Application.LoadLevel("PlayTennis");
	}
	
}
