using UnityEngine;
using System.Collections;

public class QuizButtons : MonoBehaviour {
	
	GameObject instructions;
	GameObject canvas;
	Quiz quiz;
	
	void Start(){
		instructions = GameObject.Find ("Instructions");
		canvas = GameObject.Find ("Canvas");
		quiz = GameObject.Find ("QuizScript").GetComponent<Quiz>();
		
		canvas.SetActive(false);
		
	}

	
	public void StartGame(){
		instructions.SetActive(false);
		canvas.SetActive(true);
		quiz.StartGame = true;
		
	}


}
