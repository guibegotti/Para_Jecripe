using UnityEngine;
using System.Collections;

public class Rebater : MonoBehaviour {

	public GameObject alvo;
	
	private float tempoAlvo;

	public bool isServing;
	private float t;

	private int side;

	private GameObject forehand_lado;
	private GameObject forehand_frente;
	private GameObject backhand_lado;
	private GameObject backhand_frente;

	TennisController TC;
	TennisSounds TennisSounds;

	private Animator a;

	public float ballSpeed;

	public bool isTraining;

	public bool isPlayer;
	private EnemyController eController;

	private GameController gController;

	// Use this for initialization
	void Start () {
		if(isTraining == false){
			gController = GameObject.Find("GameController").GetComponent<GameController>();
			eController = GameObject.Find("player2").GetComponent<EnemyController>();
		}
		else{
			TC = GameObject.Find ("TennisController").GetComponent<TennisController> ();
		}
		TennisSounds = GameObject.Find ("Sounds").GetComponent<TennisSounds>();
		a = GetComponentInParent<Animator>();
		ballSpeed = 17f;
		if(isPlayer == false){
			side = -1;
		}
		else{
			side = 1;
		}
	}

	void OnTriggerEnter (Collider c){
		if (c.gameObject.tag == "animationTrigger" && isServing == false) {
			float rotationY = transform.eulerAngles.y;
			if(side == -1){
				rotationY += 180f;
				if(rotationY > 360){
					rotationY-=360;
				}
			}

			if(isTraining == true){
				if (rotationY < 135 && rotationY > 0) {
					a.SetTrigger ("Backhand_lado");
				} 
				else if (rotationY > 225 && rotationY <= 360) {
					a.SetTrigger ("Forehand_lado");
				}
				else if (c.transform.position.x+ (c.attachedRigidbody.velocity.x*Time.deltaTime)  - transform.position.x <= 0) {
					a.SetTrigger ("Backhand_frente");
				} else if (c.transform.position.x + (c.attachedRigidbody.velocity.x*Time.deltaTime) - transform.position.x > 0) {
					a.SetTrigger ("Forehand_frente");
				}
			}
			else{			
				if (rotationY >= 135 && rotationY < 190) {
					a.SetTrigger ("Backhand_frente");
				} else if (rotationY >= 190 && rotationY <= 225) {
					a.SetTrigger ("Forehand_frente");
				}
				else if (rotationY < 135 && rotationY > 0) {
					a.SetTrigger ("Backhand_lado");
				} else if (rotationY > 225 && rotationY <= 360) {
					a.SetTrigger ("Forehand_lado");
				}
			}
		}


		else if(c.gameObject.tag == "Ball"){
			if(isTraining==false){
				gController.ResetBounce();
				if(isPlayer == true){
					gController.playerTurn = false;
				}
				else if(isPlayer == false){
					gController.playerTurn = true;
				}
				if(isPlayer == true && isTraining==false){
					eController.lookAtTarget = true;
				}
				else if(isPlayer == false&&isTraining == false){
					eController.interceptBall = false;
					eController.moveToDefault = true;
				}
			}
			else{
				TC.addPoints(20);
			}
			TennisSounds.PlaySound(TennisSounds.ball);
			TennisSounds.PlaySound(TennisSounds.playerMoan);
			TennisSounds.PlaySound(TennisSounds.racket);


			if(isPlayer == true && isServing==false){
				float playerRot = transform.eulerAngles.y;
				float x=0;

				if(playerRot>=0 && playerRot<90){
					x = playerRot/25;
				}
				else if(playerRot>=90 && playerRot<=270){
					x = (180-playerRot)/25;
				}
				else if (playerRot>270 && playerRot<=360){
					x = -(360-playerRot)/25;
				}
				float z = (transform.position.z /4.4f) + 8.1f;
				Vector3 playerTargetPos = new Vector3(-x, 0f, z);
				alvo.transform.position = playerTargetPos;
			}

			tempoAlvo = (alvo.transform.position - transform.position).magnitude/ballSpeed;
			if(isPlayer == false){
				tempoAlvo = tempoAlvo * -1;
			}
			c.attachedRigidbody.velocity = side*Velocidade(tempoAlvo);
			
			if(isServing == false){				
				ballSpeed = 15.3f;
			}
		}
	}


	Vector3 Velocidade(float tempoAteAlvo) {
		Vector3 distancia = alvo.transform.position - transform.position;
		Vector3 direcao = distancia;
		direcao.y = 0;
		
		float y = distancia.y;
		float xz = direcao.magnitude;
		
		float t = tempoAteAlvo;
		float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
		float v0xz = xz / t;
		
		Vector3 result = direcao.normalized;        
		result *= v0xz;                                
		result.y = v0y;                                
		
		return result;
	}
}
