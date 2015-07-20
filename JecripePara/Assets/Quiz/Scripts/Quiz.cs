using UnityEngine;
using System.Collections;

public class Quiz :AsksandSoluitons {

	//initiation Variables
		//Font Default
		public Font	FHind;

		//StartMenu
		private bool StartMenu = true;

		//StartGame
		private bool StartGame = false;
		
		//Hide and Show Answer Buttons.
		bool ShowButtons = true;

		//hold one question and answer
		string Question;
		string AnswerA;
		string AnswerB;
		string AnswerC;
		string AnswerD;
		string Correct;

		// Set the time to countdown.
		public float timeLeft = 30;
		
		// This text explain how to play the game.
		public string StartMenuText = "Jogo de Perguntas\n\n Para jogar e simples, leia a pergunta e as respostas e selecione uma das alternativas durante 30 segudos cada.";

		public Texture CountDownTexture;


	void OnGUI () {


		// apply font to letters and align text according with a box and buttons.
		GUI.skin.font = FHind;
		GUI.skin.box.alignment = TextAnchor.UpperCenter;
		GUI.skin.button.wordWrap = true;
		GUI.skin.box.wordWrap = true;


		//Show StartMenu before game.
		if (StartMenu == true) {

			//create box menu to initiate the game.
			GUI.Box (new Rect (Screen.width / 2 - Screen.width / 3, Screen.height / 3 - Screen.height / 5, Screen.width / 2 + Screen.width / 6, Screen.height / 2 + Screen.height / 10),StartMenuText );

			if (GUI.Button (new Rect (Screen.width / 2 + Screen.width / 6, Screen.height / 2 + Screen.height / 12, Screen.width / 8, Screen.height / 10), "Iniciar")) {

				//Hide menu box
				StartMenu = false;
				StartGame = true;
			}
			if (GUI.Button (new Rect (Screen.width / 8 + Screen.width / 16, Screen.height / 2 + Screen.height / 12, Screen.width / 8, Screen.height / 10), "Voltar")) {
				Application.LoadLevel ("PlayScene");
			}
		}


		if(StartGame==true){
					
			//Pick and hold a question with their answers.
			AnswerA = QuizSolutionA ();
			AnswerB = QuizSolutionB ();
			AnswerC = QuizSolutionC ();
			AnswerD = QuizSolutionD ();
			Correct = QuizCorrectSol();
			Question = QuizQuestion ();


			// Make a background box
			GUI.Box(new Rect(Screen.width/90,Screen.height/20-20,Screen.width-Screen.width/90-20,Screen.height/10), Question);
					
			if(ShowButtons == true) {
						
				// Make the first button on the upper left. 
				if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 2 - Screen.height / 4, Screen.width / 5, Screen.height / 5), AnswerA)) {

					if (AnswerA == Correct) {

						i = false;
						timeLeft = 30;
					
					}
					if (AnswerA != Correct) {
					
						timeLeft = 0;
					}
				}
						
				// Make the second button on the botton left.
				if (GUI.Button (new Rect (Screen.width / 4, Screen.height / 2 + Screen.height /16, Screen.width / 5, Screen.height / 5), AnswerB)) {

					if (AnswerB == Correct) {

						i = false;
						timeLeft = 30;
					
					} else {

						timeLeft = 0;
					}
				}
				// Make the third button on the upper right.
				if (GUI.Button (new Rect (Screen.width / 2 + Screen.width /10, Screen.height / 2 - Screen.height / 4, Screen.width / 5, Screen.height / 5), AnswerC)) {
					if (AnswerC == Correct) {

						i = false;
						timeLeft = 30;	
					
					} else {

						timeLeft = 0;
					}
				}
					
				// Make the fourth button on the bottom right.
				if (GUI.Button (new Rect (Screen.width /2 + Screen.width /10, Screen.height / 2 + Screen.height /16, Screen.width / 5, Screen.height / 5), AnswerD)) {
					if (AnswerD == Correct) {

						i = false;
						timeLeft = 30;
				
					} else {

						timeLeft = 0;
					}
				}
			}
				
			//CountDown
			timeLeft -= Time.deltaTime;
				

			//Show off the End Menu with rematch and return to menu, and countdown numbers. 
			if (timeLeft <= 0) {
						
				ShowButtons=false;

				GUI.Box (new Rect (Screen.width/2-Screen.width/3,Screen.height/3-Screen.height/5, Screen.width/2+Screen.width/6, Screen.height/2+Screen.height/10), "Fim de Jogo");

				if (GUI.Button (new Rect (Screen.width/2+Screen.width/6, Screen.height /2 + Screen.height/12, Screen.width /8, Screen.height /10), "Jogar Novamente")) {

					Application.LoadLevel (Application.loadedLevelName);
				
				}
				if (GUI.Button (new Rect (Screen.width /8+Screen.width/16, Screen.height /2 + Screen.height/12, Screen.width /8, Screen.height /10), "Menu")) {

					Application.LoadLevel ("Menu");
				
				}
			} else {

				GUI.BeginGroup( new Rect (Screen.width/2-60, Screen.height/2-85, 400, 400));

					GUI.DrawTexture( new Rect (0, 0, 200, 200), CountDownTexture);
					GUI.Label(new Rect(0+70,0+85, 100, 30), timeLeft.ToString());

				GUI.EndGroup();
						
			}
		}
	}
}
