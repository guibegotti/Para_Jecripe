using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionOnButton : MonoBehaviour {

	Quiz quiz;
	QuizButtons quizButtons;
	QuizSounds sounds;
	
	Button button;
	public string answer;
	int addp;
	
	
	void Start(){
		sounds = GameObject.Find ("Sounds").GetComponent<QuizSounds>();
		quiz = GameObject.Find("QuizScript").GetComponent<Quiz>();
		quizButtons = GameObject.Find("ButtonScript").GetComponent<QuizButtons>();
	}
	
	void Update(){
		answer = GetComponentInChildren<Text>().text;
		
	}
	
	public void ChosenAnswer(){	
		if(answer == quiz.Correct){
			addp = 1000;
			sounds.PlaySound(sounds.rightAnswerSound);
			
		} else {
			addp = 0;
			quiz.timeLeft = quiz.timeLeft - Time.deltaTime - 10;
			sounds.PlaySound (sounds.wrongAnswerSound);
		}
		quiz.i = false;
		quizButtons.ChangeScore (addp);
		//quiz.ResetCountDown();
		
	}

}
