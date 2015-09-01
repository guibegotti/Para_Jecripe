using UnityEngine;
using System.Collections;

public class QuestionLoader : MonoBehaviour {


	public const string path = "QuestionsAndAnswers";
	
	private int RandNumb;
	public bool i = false;
	public int[] alreadyAsked = new int[40];
	int j = 0; // the number of questions that were already asked;
	int a;
	int tryQuestion;
	
	QuizButtons quizButtons;
	QuestionContainer qc;
	
	void Start(){
		qc =  QuestionContainer.Load(path);
	}
	
	
	public int RandomNumberfunction() {
	
		if (i==false) {
			RandNumb = Random.Range (0,40);
			a = 0;
			while(a <= j){
				if(RandNumb == alreadyAsked[a]){
					RandNumb = Random.Range (0,40);
					a = 0;
				} else{
					a++;
				}
			}
			j++;
			
			if(j == 39){
				//GameObject.Find ("QuizScript").GetComponent<Quiz>().GameOver();
			} else {
				alreadyAsked[j] = RandNumb;
				i = true;
			}
		}
		return RandNumb;
		
	}
	
	
	public string QuizQuestion(){
		Question question = qc.questions[RandomNumberfunction()];
		return question.q;
	}
	
	public string QuizSolutionA(){
		Question question = qc.questions[RandomNumberfunction()];
		return question.A1;
	}
	
	public string QuizSolutionB(){
		Question question = qc.questions[RandomNumberfunction()];
		return question.A2;
	}
	
	public string QuizSolutionC(){
		Question question = qc.questions[RandomNumberfunction()];
		return question.A3;
	}
	
	public string QuizSolutionD(){
		Question question = qc.questions[RandomNumberfunction()];
		return question.A4;
	}
	
	public string QuizCorrectSol(){
		Question question = qc.questions[RandomNumberfunction()];
		return question.C;
	}
	
	
	
}
