using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Question : MonoBehaviour {

	Quiz quiz;
	QuizButtons quizButtons;
	QuizSounds Sounds;
	
	Button button;
	public string answer;
	int addp;
	
	
	void Start(){
		Sounds = GameObject.Find ("Sounds").GetComponent<QuizSounds>();
		quiz = GameObject.Find("QuizScript").GetComponent<Quiz>();
		quizButtons = GameObject.Find("ButtonScript").GetComponent<QuizButtons>();
	}
	
	
	void Update(){
		answer = GetComponentInChildren<Text>().text;
		
	}
	
	public void ChosenAnswer(){	
		if(answer == quiz.Correct){
			addp = 10;
			Sounds.PlaySound(Sounds.rightAnswerSound);
			
		} else {
			addp = -5;
			Sounds.PlaySound (Sounds.wrongAnswerSound);
		}
		quiz.i = false;
		quizButtons.ChangeScore (addp);
		//quiz.ResetCountDown();
		
	}

}
