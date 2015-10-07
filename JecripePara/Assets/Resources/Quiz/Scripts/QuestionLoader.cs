using UnityEngine;
using System.Collections;

public class QuestionLoader : MonoBehaviour 
{

	public const string PATH = "QuestionsAndAnswers";

	public bool setRand = false;
	public int [] alreadyAsked = new int[60];

	
	private int alreadyNumb = 0; // the number of questions that were already asked;
	private int countNumber;
	private int RandNumb;
	private int tryQuestion;
	
	QuizButtons quizButtons;
	QuestionContainer qc;
	
	void Start()
	{
		qc =  QuestionContainer.Load(PATH);
	}
	
	
	public int RandomNumberfunction()
	{
	
		if (setRand ==false) 
		{
			RandNumb = Random.Range (0,40);
			countNumber = 0;
			while(countNumber <= alreadyNumb)
			{
				if(RandNumb == alreadyAsked[countNumber])
				{
					RandNumb = Random.Range (0,40);
					countNumber = 0;

				} else{
					countNumber++;
				}
			}
			alreadyNumb++;
			
			if(alreadyNumb == 39)
			{
				//GameObject.Find ("QuizScript").GetComponent<Quiz>().GameOver();
			} 
			else 
			{
				alreadyAsked[alreadyNumb] = RandNumb;
				setRand = true;
			}
		}
		return RandNumb;
		
	}
	
	
	public string QuizQuestion()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.q;
	}
	
	public string QuizSolutionA()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A1;
	}
	
	public string QuizSolutionB()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A2;
	}
	
	public string QuizSolutionC()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A3;
	}
	
	public string QuizSolutionD()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A4;
	}
	
	public string QuizCorrectSol()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.C;
	}
	
	
	
}
