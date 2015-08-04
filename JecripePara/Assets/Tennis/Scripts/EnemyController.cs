using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Rigidbody r;


	public float vMax;

	public GameObject ball;
	private Rigidbody ballRB;

	private GameObject player;
	public GameObject playerTarget;
	public GameObject shootTarget;
	private Rebater hitController;
	public GameObject hitArea;
	private Vector3 rotationTarget;

	public bool interceptBall;
	private Vector3 moveTo;
	private float c;
	public bool lookAtTarget;
	public bool moveToDefault;
	private float delayTime;

	public bool isServing;
	private float serveTime = 1000;

	private Animator a;


	void Start(){
		player = GameObject.Find("player1");
		hitController = hitArea.GetComponent<Rebater>();
		r = GetComponent<Rigidbody> ();
		ballRB = ball.GetComponent<Rigidbody>();
		a = GetComponent<Animator>();
		lookAtTarget = false;
		interceptBall = false;
		moveToDefault = false;
	}

	void Update(){
		if(isServing == true){
			r.velocity = Vector3.zero;
			a.SetFloat("velocidade", 0);
			hitController.isServing = true;
			Serving();
		}
		else{
			if(lookAtTarget == true){
				Vector3 changeTarget;
				float targetX = Random.Range (0f, 3f);
				float targetZ = Random.Range (-8f, -5f);
				
				if(player.transform.position.x>0){
					targetX = - targetX;
				}
				changeTarget = new Vector3(targetX, 0f, targetZ);
				shootTarget.transform.position = changeTarget;
				
				interceptBall = true;
				c = Random.Range (0.2f, 0.50f);
				moveTo = new Vector3 (playerTarget.transform.position.x + (ballRB.velocity.x* c), transform.position.y, playerTarget.transform.position.z+(ballRB.velocity.z*c));
				rotationTarget = moveTo - transform.position;
				lookAtTarget = false;
			}
			if (interceptBall == true) {
				MovingAnimation();
				transform.position = Vector3.MoveTowards(transform.position, moveTo, vMax*Time.deltaTime);
				if(Vector3.SqrMagnitude(moveTo- transform.position) < 0.001f){
					interceptBall = false;
					rotationTarget = new Vector3(0f, 0f, 0f)- transform.position;
				}
			}
			else if(moveToDefault==true){
				MovingAnimation();
				Vector3 defaultPosition = new Vector3  (0f, transform.position.y, 15f);
				rotationTarget = defaultPosition - transform.position;				
				transform.position = Vector3.MoveTowards(transform.position, defaultPosition, vMax*Time.deltaTime);
				if(transform.position.z > defaultPosition.z-0.1f && transform.position.z < defaultPosition.z+0.1f){
					moveToDefault = false;
					rotationTarget = new Vector3(0f, 0f, 0f)- transform.position;
				}
			}
			if (rotationTarget != Vector3.zero) {
				r.rotation = Quaternion.Slerp (r.rotation, Quaternion.Euler (0f, 180f, 0f) * Quaternion.LookRotation (rotationTarget), Time.deltaTime * 5f); 
			}
			
			if(interceptBall== false && moveToDefault == false){
				a.SetFloat("velocidade", 0);
			}
			else{
				a.SetFloat ("velocidade", vMax);
			}
		}
	}

	void MovingAnimation (){
		if (Time.time > 0.4 + delayTime) {
			a.SetTrigger("Mover");
			delayTime = Time.time;
		}
	}

	void Serving(){
		a.SetBool ("estaSacando", true);
		hitController.isServing = true;
		if (Input.GetKeyDown (KeyCode.Space)){
			serveTime = Time.time;
			a.SetTrigger("Saque");
		}
		if (Time.time > serveTime + 1.6f) {
			hitArea.SetActive(true);	
			a.SetBool("estaSacando", false);
		}
		if(Time.time > serveTime + 2f){
			hitController.isServing = false;
			isServing = false;	
			serveTime=1000;
		}
	}
}
