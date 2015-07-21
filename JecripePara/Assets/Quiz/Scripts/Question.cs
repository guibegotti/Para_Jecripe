using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Question : MonoBehaviour {

	Quiz quiz;
	QuizButtons quizButtons;
	Button button;
	public string answer;
	int addp;
	
	
	void Start(){
		quiz = GameObject.Find("QuizScript").GetComponent<Quiz>();
		quizButtons = GameObject.Find("ButtonScript").GetComponent<QuizButtons>();
	}
	
	
	void Update(){
		answer = GetComponentInChildren<Text>().text;
		
	}
	
	public void ChosenAnswer(){	
		if(answer == quiz.Correct){
			addp = 10;
		} else {
			addp = -5;
		}
		quiz.i = false;
		quizButtons.ChangeScore (addp);
		//quiz.ResetCountDown();
		
	}

}
