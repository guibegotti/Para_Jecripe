using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerTutorial : MonoBehaviour {

	private Rigidbody rig;
	private Animator animator;
	private bool change, start, run, end;
	private float velocity;
	public Text text;


	public GameObject rightFoot, leftFoot, startCanvas, TutorialCanvas, endCanvas;

	void Start () {
	
		rig = GetComponent<Rigidbody>();
		animator = GetComponent<Animator> ();
		startCanvas = GameObject.Find ("StartCanvas");
		endCanvas = GameObject.Find ("Game");
		velocity = 1;
		start = false;
		run = false;
		if (Random.Range (0, 10) > 5) {
			change = true;
		} else {
			change = false;
		}

	}

	void TutorialScreen(GameObject TutorialCanvas, string instrunctions){
		bool b = false;
		while(!b){
			text.text = instrunctions;
			Time.timeScale = 0;
			TutorialCanvas.SetActive (true);
			if(Input.GetKeyDown (KeyCode.Space)){
				TutorialCanvas.SetActive(false);
				b = true;
				Time.timeScale = 1;
			}
		}
	}

	void Move ()
	{
		rig.drag = 0.5f;
		if (rig.velocity != new Vector3 (0, 0, 0)) {
			
			if(rig.velocity.x < 0.7f &&  rig.velocity.x > -0.7f){
				rig.velocity = Vector3.zero;
			}
		}
		
		if (change) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity += velocity * -transform.forward;
				rightFoot.SetActive (true);
				leftFoot.SetActive (false);
				change = false;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity -= velocity * -transform.forward;
			}
			
		} else {
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity += velocity * -transform.forward;
				rightFoot.SetActive (false);
				leftFoot.SetActive (true);
				change = true;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity -= velocity * -transform.forward;
			}
		}
		
	}

	void startGame(){
		if (!run) {
			if (Input.GetKeyDown (KeyCode.Space)) {			
				start = true;
				startCanvas.SetActive (false);			
			}
			if (start) {
				TutorialScreen (TutorialCanvas,"Teste para alerta largada");
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					rightFoot.SetActive (false);
					leftFoot.SetActive (true);
					rig.velocity += -transform.forward * 5;
					run = true;
				}
			}
		}
		else{
			Move ();
		}

		if (this.transform.position.x >= -40) {
	
			TutorialScreen (TutorialCanvas,"Teste para alerta de setas laterais");

		}

		if (this.transform.position.x >= 25) {
			endCanvas.SetActive(true);
			PlayerPrefs.SetInt("AthleticsTutorialFinish",1);
		}
	}

	void Update () {

		functionsScript.Animation (rig, animator,start);
		startGame ();
	
	}
}
