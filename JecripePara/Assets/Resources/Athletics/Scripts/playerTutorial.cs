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

	public GameObject rightFoot, leftFoot, startCanvas, TutorialCanvas, endCanvas;

	void Start () {

		print ("começou");
		rig = GetComponent<Rigidbody>();
		animator = GetComponent<Animator> ();
		startCanvas = GameObject.Find ("StartCanvas");
		velocity = 1;
		TutorialCanvas.SetActive (false);
		start = false;
	}

	void TutorialScreen(GameObject TutorialCanvas, string instrunctions, KeyCode key){
	
		if(!b){
			onTutorial = true;
			text.text = instrunctions;
			Time.timeScale = 0;
			TutorialCanvas.SetActive (true);
	
			if(Input.GetKeyDown (key)){

				TutorialCanvas.SetActive(false);
				onTutorial = false;
				b = true;
				Time.timeScale = 1;
			}
		}
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

	void startGame(){


		if (!run) {
			
			if (Input.GetKeyDown (KeyCode.Space)) {			
				start = true;
				startCanvas.SetActive (false);	
				b = false;

			}
			if (start) {
				TutorialScreen (TutorialCanvas,"Para dar a largada aperte a seta para cima", KeyCode.UpArrow);
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
						
					rig.velocity += -transform.forward * 10;
					run = true;

				}
			}
		}
		else{
			if (this.transform.position.x >= -41 && this.transform.position.x <=-40) {
				if(!aux){
					b = false;
					aux = true;
					leftFoot.SetActive(true);
				}

				TutorialScreen (TutorialCanvas,"Para correr aperte a seta do lado correspondente à pegada na tela", KeyCode.LeftArrow );
			
			}
			if (this.transform.position.x >= 40) {

				rig.drag = 1f;
				endCanvas.SetActive(true);
				
			}
			else{
				if(!onTutorial){
					Move ();
				}
			}
		}
		if (this.transform.position.x >= -15) {



		}
	}

	void Update () {


		functionsScript.Animation (rig, animator,start);
		startGame ();

	}
}
