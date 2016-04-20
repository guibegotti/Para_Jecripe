using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TennisTutorialController : MonoBehaviour
{

	public GameObject okMessage;
	private float timer;
	private bool waiting;
	private bool canContinue;
	public int okCount;
	public GameObject instructionWindow;
	public Text instWindowText;
	public GameObject ballShooter;
	public GameObject tutorialFinished;
	public int hit;
	private bool hitLeft, hitRight;
	GameObject b2, b3, b4, b5, b6;
	Timer t;

	void Start ()
	{
		hit = 0;
		okCount = 0;
		timer = 0;
		canContinue = false;
		waiting = false;
		instructionWindow.SetActive (true);
		ballShooter.SetActive (false);
		tutorialFinished.SetActive (false);
		hitLeft = false;
		hitRight = false;
		
		b2 = GameObject.Find ("Balloon2");
		b2.SetActive (false);
		b3 = GameObject.Find ("Balloon3");
		b3.SetActive (false);
		b4 = GameObject.Find ("Balloon4");
		b4.SetActive(false);
		b5 = GameObject.Find ("Balloon5");
		b5.SetActive(false);
		b6 = GameObject.Find ("Balloon6");
		b6.SetActive(false);
		
		instWindowText.text = "";
		
		t = GetComponent<Timer> ();
	}

	void Update ()
	{
	
		if (okCount == 0) {
			
			if (Time.timeSinceLevelLoad > 0.8 && Time.timeSinceLevelLoad < 3) {
				instWindowText.text = "Seja bem-vindo ao jogo de tênis em cadeira de rodas!";
			} else if (Time.timeSinceLevelLoad >= 3) {
				instWindowText.text = "Aperte ENTER para aprender a jogar!";
				if (Input.GetKeyDown (KeyCode.Return)) {
					okCount++;
					GameObject.Find ("Balloon1").SetActive (false);
					b2.SetActive (true);
					t.SetTimer ();
				}
			} 
			
			
		} else if (okCount == 1) {
		
			if (t.time > 0.5) {
				b2.GetComponentInChildren<Text> ().text = "Use as SETAS ou WASD para se mover";
				if (canContinue == false && waiting == false) {		
					if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
						okCount++;
						t.SetTimer ();
					}
				}
			}
		} 
		
		
		else if (okCount == 2) {
			
			if (t.time > 0.8 && t.time < 1.8) {
				b2.SetActive (false);
				b3.SetActive (true);
			} else if (t.time >= 1.8 && t.time < 3) {
				b3.GetComponentInChildren<Text> ().text = "Muito bem!";
			} else if (t.time >= 3 && t.time < 5.8) {
				b3.GetComponentInChildren<Text> ().text = "Agora tente rebater TRÊS bolas.";
				ballShooter.SetActive (true);
			} else if (t.time >= 5.8 && t.time < 6) {
				b3.GetComponentInChildren<Text> ().text = "Mova-se até as bolas para rebatê-las.";
			} else if (t.time >= 6) {
				if (hit == 6) {
					okCount++;
					b3.GetComponentInChildren<Text>().text = "Isso!";
					t.SetTimer ();
					ballShooter.SetActive(false);
				}
			}
		} 
		
		
		else if (okCount == 3){
		
			if(t.time > 0.8 && t.time < 1.8){
				if (b3.activeSelf == true) {
					b3.SetActive (false);
					DestroyBalls();
				}
				b4.SetActive(true);
			} else if (t.time >= 1.8){
				if(t.time < 4.6){
					b4.GetComponentInChildren<Text>().text = "Agora rebata uma bola para a esquerda!";
				} else if (t.time >= 4.6){
					b4.GetComponentInChildren<Text>().text = "Dica: gire para a esquerda antes de rebater";
				}
				ballShooter.SetActive(true);
				if(hitLeft == true){
					b4.GetComponentInChildren<Text>().text = "Ótimo!";
					okCount++;
					ballShooter.SetActive(false);
					DestroyBalls();
					t.SetTimer();
				}
			} 
			
		}
		
		else if (okCount == 4){
			if(t.time > 1.8 && t.time < 3){
				b4.SetActive(false);
				b5.SetActive(true);
			} else if (t.time >= 3){
				ballShooter.SetActive(true);
				if(t.time < 7){
					b5.GetComponentInChildren<Text>().text = "Agora rebata uma bola para a direita!";
				} else {
					b5.GetComponentInChildren<Text>().text = "Dica: gire para a direita antes de rebater";
				} 
				if(hitRight == true){
					b5.GetComponentInChildren<Text>().text = "Ótimo!";
					ballShooter.SetActive(false);
					okCount++;
					t.SetTimer();
				}
			}
		}
		
		else if (okCount == 5){
			b6.SetActive(true);
			if(t.time > 0.5 && t.time < 1.8){
				b5.SetActive(false);
			}
			if(t.time > 1.8 && t.time < 4.5){
				b6.GetComponentInChildren<Text>().text = "Parabéns! Você já sabe jogar tênis em cadeira de rodas!";
			} else if (t.time > 4.5 && t.time < 8.3){
				b6.GetComponentInChildren<Text>().text = "Lembre-se: a bola pode quicar DUAS vezes antes de ser rebatida";
			} else if (t.time >= 8.3){
				b6.GetComponentInChildren<Text>().text = "Aperte ENTER para jogar";
				if(Input.GetKeyDown(KeyCode.Return)){
					tutorialFinished.SetActive(true);
				}
			}
		}	
	}
		
		
		
		
		
	
		/*LEMBRE-SE: No tenis em cadeira" +
					" de rodas, a bola pode quicar duas vezes antes de ser rebatida*/
		


	public void AddHit ()
	{
		
		hit++;
		if (hit >= 6 && okCount == 4) {
			waiting = true;
		}
	}

	public void HitLeft ()
	{
		if (okCount == 3 && hitLeft == false) {
			Debug.Log ("Hitleft");
			hitLeft = true;
		}
	}

	public void HitRight ()
	{
		if (okCount == 4 && hitRight == false) {
			Debug.Log ("HitRight");
			hitRight = true;
		}
	}
	
	void DestroyBalls(){
		
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Ball")) {
			Destroy (g);
		}
	}
	

}
