using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwimmingTutorial : MonoBehaviour
{

	
	public Text balloonText1;
	GameObject balloon2;
	GameObject balloon3;
	GameObject balloon4;
	GameObject balloon5;
	GameObject arrow1;
	Timer timer;
	bool part1 = true;
	bool part2;
	bool part3;
	bool part4;
	public bool part5;

	public GameObject settingsCanvas;


	SwimmingSounds sounds;
	
	
	void Start ()
	{

        Time.timeScale = 1;
		balloon2 = GameObject.Find ("TextBalloon2");
		balloon2.SetActive (false);
		
		balloon3 = GameObject.Find ("TextBalloon3");
		balloon3.SetActive (false);
		
		balloon4 = GameObject.Find ("TextBalloon4");
		balloon4.SetActive (false);
		
		balloon5 = GameObject.Find ("TextBalloon5");
		balloon5.SetActive (false);
		
		arrow1 = GameObject.Find ("Arrow1");
		arrow1.SetActive (false);

		sounds = GameObject.Find ("Soundscript").GetComponent<SwimmingSounds> ();
		

		
		timer = GetComponent<Timer> ();
	}
	
	void JumpIntoWater ()
	{
	
		GameObject.Find("Player").GetComponent<Animator>().SetBool ("jumpp",true);
		GameObject.Find("PlayerParent").GetComponent<Animator>().SetTrigger("Jump");

		
	}
	
	void Update ()
	{
		
		
		
		if (part1) {
		
			if (Time.timeSinceLevelLoad >= 1.8 && Time.timeSinceLevelLoad < 3.3) {
				
				balloonText1.text = "Seja bem-vindo(a) ao jogo de natação!";
			} else if (Time.timeSinceLevelLoad >= 3.3) {
				
				balloonText1.text = "Aperte ENTER para aprender a jogar!";
			}
			if (Input.GetKeyDown (KeyCode.Return)) {
			
				Destroy (GameObject.Find ("TextBalloon1"));
				timer.SetTimer ();
				part1 = false;
				part2 = true;
				balloon2.SetActive (true);
			}
			
		} else if (part2) {
			
			
			if (timer.time > 0.7f) {
				balloon2.GetComponentInChildren<Text> ().text = "Use ESPAÇO para o Clodoaldo Silva entrar na água";
				if (Input.GetKeyDown (KeyCode.Space)) {
					JumpIntoWater ();
					sounds.WaitPlay(1f,sounds.dive);
					Destroy (balloon2);
					timer.SetTimer ();
					part2 = false;
					part3 = true;
				}
			} 
			
		} else if (part3) {
			
			balloon3.SetActive (true);
			
			if (timer.time > 0.7f && timer.time < 1.5f) {
				GetComponent<SwimmingTutorial_Oxygen> ().oxGoDownOK = true;
				balloon3.GetComponentInChildren<Text> ().text = "Muito bem!";
			} else if (timer.time >= 1.5f) {
				balloon3.GetComponentInChildren<Text> ().text = "Aperte a SETA DA DIREITA";
				GetComponent<SwimmingTutorial_Player> ().armStrokesOK = true;
				if (Input.GetKey (KeyCode.RightArrow)) {
					balloon3.GetComponentInChildren<Text> ().text = "Isso! Use as SETAS para dar braçadas";
					timer.SetTimer ();
					part3 = false;
					part4 = true;
					
				}
			}
			
		} else if (part4) {
			
			if (timer.time > 2f && timer.time < 2.4f) {
				Destroy (balloon3);
				arrow1.SetActive (true);
				balloon4.SetActive (true);
				
			} else if (timer.time >= 2.4f && timer.time < 4f) {
			
				balloon4.GetComponentInChildren<Text> ().text = "Aqui é o OXIGÊNIO";
				
			} else if (timer.time >= 4 && timer.time < 6) {
				
				balloon4.GetComponentInChildren<Text> ().text = "Não deixe ele acabar!";
			
			} else if (timer.time >=6 && timer.time < 8) {
				
				balloon4.GetComponentInChildren<Text> ().text = "Quando ele estiver na parte VERDE,";
			} else if (timer.time >= 8){
			
				
				balloon4.GetComponentInChildren<Text> ().text = "aperte ESPAÇO para respirar";

			}

            if (Input.GetKeyDown(KeyCode.Space))
            {

				sounds.PlaySound (SwimmingSounds.breathing);
                GetComponent<SwimmingTutorial_Oxygen>().rechargeOxygen = true;
                part4 = false;
                Destroy(arrow1);
                Destroy(balloon4);
                timer.SetTimer();
                part5 = true;
            }

        } else if (part5) {
			
			balloon5.SetActive (true);
			
			if (timer.time >= 1 && timer.time < 3.5f) {
				
				balloon5.GetComponentInChildren<Text> ().text = "Parabéns! Você já sabe como jogar";
			} else if (timer.time >= 3.5 && timer.time < 6f) {
			
				balloon5.GetComponentInChildren<Text> ().text = "Agora ajude o Clodoaldo a vencer seus oponentes!";
			} else if (timer.time >= 6f) {
			
				GetComponent<SwimmingTutorial_Player> ().armStrokesOK = false;
				balloon5.GetComponentInChildren<Text> ().text = "Para começar o jogo, aperte ENTER";
				if(Input.GetKeyDown(KeyCode.Return)){
					Application.LoadLevel("Swimming");
				}
				
			}
		}
		
		
	}
}
