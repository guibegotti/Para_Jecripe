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
		ballSpeed = 16f;
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


		else if(c.gameObject.tag == "Ball"){
			if(isTraining==false){
				gController.ResetBounce();
				if(isPlayer == true){
					gController.playerTurn = false;
				}
				else if(isPlayer == false){
					gController.playerTurn = true;
				}
			}
			else{
				TC.addPoints(20);
			}
			TennisSounds.PlaySound(TennisSounds.ball);
			TennisSounds.PlaySound(TennisSounds.playerMoan);
			TennisSounds.PlaySound(TennisSounds.racket);
			
			tempoAlvo = (alvo.transform.position.z - transform.position.z)/ballSpeed;
			c.attachedRigidbody.velocity = side*Velocidade(tempoAlvo);
			
			if(isPlayer == true && isTraining==false){
				eController.lookAtTarget = true;
			}
			else if(isPlayer == false&&isTraining == false){
				eController.interceptBall = false;
				eController.moveToDefault = true;
			}
			if(isServing == false){				
				ballSpeed = 14f;
				if(isPlayer==true){
					Vector3 gameTarget = new Vector3(0f,0f, side*5f);
					alvo.transform.position = gameTarget;
				}
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
