using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TennisTutorialController : MonoBehaviour {

	public GameObject okMessage;
	private float timer;
	private bool waiting;
	private bool canContinue;
	public int okCount;
	public GameObject instructionWindow;
	public Text instWindowText;
	public GameObject inGameInstruction;
	public Text inGameInstText;
	public GameObject ballShooter;
	public GameObject tutorialFinished;
	public int hit;
	private bool hitLeft, hitRight;

	void Start () {
		hit = 0;
		okCount = 0;
		timer = 0;
		canContinue = false;
		waiting = false;
		instructionWindow.SetActive(true);
		inGameInstruction.SetActive(false);
		ballShooter.SetActive(false);
		tutorialFinished.SetActive(false);
		hitLeft=false;
		hitRight=false;
	}

	void Update () {
		if(canContinue== false && waiting==false){			
			if(okCount == 2){
				if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
					canContinue = true;
					okMessage.SetActive(true);
					timer = Time.time;
					waiting = true;
				}
			}
		}


		else if(Time.time >= timer + 3){
			ballShooter.SetActive(false);
			okMessage.SetActive(false);
			instructionWindow.SetActive(true);
			inGameInstruction.SetActive(false);
			if(okCount == 2){
				instWindowText.text = "Muito bem! Agora tente rebater tres bolas.\nMova-se ate as bolas para rebate-las. \nLEMBRE-SE: No tenis em cadeira" +
					" de rodas, a bola pode quicar duas vezes antes de ser rebatida.";
			}
			else if (okCount == 4){
				instWindowText.text = "A direçao da bola rebatida depende de para que lado o jogador esta virado. \nGire para a esquerda e rebata a bola" +
					" para a esquerda.";
			}
			else if(okCount == 6){
				instWindowText.text = "Otimo! Agora tente rebater para a direita.";
			}
			else if(okCount == 8){
				instructionWindow.SetActive(false);
				tutorialFinished.SetActive (true);
			}
			canContinue = false;
			waiting = false;
			timer = Mathf.Infinity;
			okCount++;
		}
	}

	public void OKPressed () {
		if(okCount == 0){
			instructionWindow.SetActive(true);
			inGameInstruction.SetActive(false);
			instWindowText.text = "Use as SETAS ou WASD para se mover";
		}
		if(okCount == 1){
			instructionWindow.SetActive(false);
			inGameInstruction.SetActive(true);
			inGameInstText.text = "Use as SETAS ou WASD para se mover";
		}
		if(okCount==3){
			ballShooter.SetActive(true);
			instructionWindow.SetActive(false);
			inGameInstruction.SetActive(true);
			inGameInstText.text = "Mova-se ate as bolas para rebate-las";
		}
		if(okCount==5){
			ballShooter.SetActive(true);
			instructionWindow.SetActive(false);
			inGameInstruction.SetActive(true);
			inGameInstText.text = "Rebata a bola para a esquerda. \n(DICA: Gire para a esquerda antes de rebater)";
		}
		if(okCount==7){
			ballShooter.SetActive(true);
			instructionWindow.SetActive(false);
			inGameInstruction.SetActive(true);
			inGameInstText.text = "Rebata a bola para a direita. \n(DICA: Gire para a direita antes de rebater)";
		}
		okCount ++;
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("Ball")){
			Destroy(g);
		 }

	}

	public void AddHit(){
		hit++;
		if(hit >= 6 && okCount == 4){
			canContinue = true;
			okMessage.SetActive(true);
			timer = Time.time ;
			waiting = true;
		}
	}

	public void HitLeft(){
		if(okCount == 6 && hitLeft == false){
			canContinue = true;
			okMessage.SetActive(true);
			timer = Time.time;
			waiting = true;
			hitLeft = true;
		}
	}
	public void HitRight(){
		if(okCount == 8 && hitRight == false){
			canContinue = true;
			okMessage.SetActive(true);
			timer = Time.time;
			waiting = true;
			hitRight = true;
		}
	}

	public void LoadGame(){
		Application.LoadLevel("main");
	}
	public void LoadTraining(){
		Application.LoadLevel("treino");
	}
	public void LoadMenu(){
		Application.LoadLevel("PlayTennis");
	}
}
