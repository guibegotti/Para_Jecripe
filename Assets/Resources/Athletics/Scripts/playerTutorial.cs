using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerTutorial : MonoBehaviour {

	private Rigidbody rig;
	private Animator animator;
	private bool change,run, end, b, onTutorial, aux;
	private float velocity;
	public Text text;
	public static bool start;
	
	public int okCount = 0;

	public GameObject rightFoot, leftFoot, startCanvas, TutorialCanvas, endCanvas;
	
	GameObject b1, b2, b3;
	
	Timer t;

	void Start () {
        Time.timeScale = 1;
		print ("começou");
		rig = GetComponent<Rigidbody>();
		animator = GetComponent<Animator> ();
		startCanvas = GameObject.Find ("StartCanvas");
		velocity = 1;
		TutorialCanvas.SetActive (false);
		start = false;
		
		b1 = GameObject.Find ("b1");
		b1.GetComponentInChildren<Text>().text = "";
		
		b2 = GameObject.Find ("b2");
		b2.SetActive(false);
		
		b3 = GameObject.Find ("b3");
		b3.SetActive(false);
		
		t = GameObject.Find ("Timer").GetComponent<Timer>();
	}


	void Move ()
	{
		rig.drag = 0.65f;
		if (rig.velocity != new Vector3 (0, 0, 0)) {
			
			if(rig.velocity.x < 0.8f){
				rig.velocity = Vector3.zero;
			}
		}
		
		if (!change) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity += velocity * -transform.forward;
				rightFoot.SetActive (true);
				leftFoot.SetActive (false);
				change = true;
			}
		} else {
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity += velocity * -transform.forward;
				rightFoot.SetActive (false);
				leftFoot.SetActive (true);
				change = false;
			}
		}
		
	}
	
	

	void Update () {


		functionsScript.Animation (rig, animator,start);
		
		if(okCount == 0){
			
			if(Time.timeSinceLevelLoad >= 0.9 && Time.timeSinceLevelLoad < 3.4){
 				b1.GetComponentInChildren<Text>().text = "Seja bem-vindo ao jogo de corrida!";
			} else if (Time.timeSinceLevelLoad >= 3.4){
				b1.GetComponentInChildren<Text>().text = "Aperte ENTER para aprender a jogar!";
			}
			
			
			if(Input.GetKeyDown(KeyCode.Return)){
				okCount++;
				start = true;
				b = false;
			}
			
		} else if (okCount == 1){
			
			b1.GetComponentInChildren<Text>().text = "Para dar a largada, aperte a SETA PARA CIMA.";
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				rig.velocity += -transform.forward * 10;
				run = true;
				b1.SetActive(false);
				okCount++;
				t.SetTimer();
			}
			
		} else if (okCount == 2){
			
			if(t.time > 0.5f){
				b2.SetActive(true);
				Time.timeScale = 0;
				leftFoot.SetActive(true);
				if(Input.GetKey(KeyCode.LeftArrow)){
					okCount++;
					Time.timeScale = 1;
					leftFoot.SetActive(false);
					b2.SetActive(false);
					Move();
				}
				
			}
			
			
		} else if (okCount == 3){
		
			Move ();
			if (this.transform.position.x >= 40) {
				okCount++;
				t.SetTimer();
			}
			
		} else if (okCount == 4){
			
			rig.drag = 1f;
			b3.SetActive(true);
			rig.velocity = Vector3.zero;
			leftFoot.SetActive(false);
			rightFoot.SetActive(false);
			
			if(t.time > 2.5){
				
				b3.GetComponentInChildren<Text>().text = "Agora ajude a Terezinha Guilhermina a vencer! Aperte ENTER para jogar";
				if(Input.GetKeyDown(KeyCode.Return)){
					Application.LoadLevel("AthleticsGame");
				}
			}
		}
		
		
		

	}
}





















