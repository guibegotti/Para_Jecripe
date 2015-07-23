using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwimmingController : MonoBehaviour {
	
	public int points = 0;
	public Text pointsText;
	
	
	void Start(){
		addPoints(0);
	}
	
	
	
	public void addPoints(int pointsToAdd){
		points += pointsToAdd;
		pointsText.text = "PONTOS\n" + points.ToString();
	}
	
	public void BackToMenu(){
		
		Application.LoadLevel("PlaySwimming");
	}
	

}
