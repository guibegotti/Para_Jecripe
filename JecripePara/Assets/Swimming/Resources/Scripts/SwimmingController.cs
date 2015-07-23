using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwimmingController : MonoBehaviour {
	
	public int points = 0;
	public Text pointsText;
	
	
	void Update(){
		
		pointsText.text = points.ToString();
		
		
	}
	
	public void addPoints(int pointsToAdd){
		points += pointsToAdd;
	}
	

}
