/// <summary>
/// Question loader.
/// </summary>

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
	
	/// <summary>
	/// It selects a ramdom number.
	/// </summary>
	/// <returns>The random number </returns>
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
	
	/// <summary>
	/// It selects and returns a question in agreement with RandomNumberFunction.
	/// </summary>
	/// <returns>The question.</returns>
	public string QuizQuestion()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.q;
	}



	/// <summary>
	/// It selects and returns an answer in agreement with RandomNumberFunction() and QuizQuestion().
	/// </summary>
	/// <returns>The solution a.</returns>
	public string QuizSolutionA()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A1;
	}



	/// <summary>
	/// It selects and returns an answer in agreement with RandomNumberFunction() and QuizQuestion().
	/// </summary>
	/// <returns>The solution b.</returns>
	public string QuizSolutionB()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A2;
	}


	/// <summary>
	/// It selects and returns an answer in agreement with RandomNumberFunction() and QuizQuestion().
	/// </summary>
	/// <returns>The solution c.</returns>
	public string QuizSolutionC()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A3;
	}


	/// <summary>
	/// It selects and returns an answer in agreement with RandomNumberFunction() and QuizQuestion().
	/// </summary>
	/// <returns>The solution d.</returns>
	public string QuizSolutionD()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.A4;
	}


	/// <summary>
	/// It selects and returns an correct answer in agreement with RandomNumberFunction() and QuizQuestion().
	/// </summary>
	/// <returns>The correct sol.</returns>
	public string QuizCorrectSol()
	{
		Question question = qc.questions[RandomNumberfunction()];
		return question.C;
	}
	
	
	
}
