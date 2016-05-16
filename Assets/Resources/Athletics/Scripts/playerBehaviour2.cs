using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class playerBehaviour2 : MonoBehaviour
{
	static public int hit, bonusnumber;
	static public bool começa, termina, start;
	static public float playertime;

	public float velocidade, tempocomeça, x, x1, y, velocidadeanimacao, vellado, velfrente, tempoabaixa, n, m, tempotermina;
	public bool pronto, esquerda, transformavelocidade, abaixa, fim, p;
	public Rigidbody rig;
	public Animator animator;
	public Text bonus;
	public Text tempo;
	public Text countDown;
	public GameObject rightFoot, leftFoot;
	public GameObject footSupports;
	public Transform referencia, referencia2;

	bool footSupportsDeleted;
	public static bool startedRunning;

	GameObject startButton;
	Timer t;
	//timer that is set when the player starts running

	FallingCoin fallingCoin;
	AthleticsSounds Sounds;

	public GameObject sbtimer;

	public GameObject v1;
	public GameObject v2;
	public GameObject v3;
	public GameObject v4;
	public GameObject v5;



	public float e1;
	public float e2;
	public float e3;
	public float e4;

	void Start ()
	{
		hit = 0;
		bonusnumber = 0;
		playertime = 0;		
		velocidade = 1;
		pronto = false;
		começa = false;
		termina = false;
		esquerda = true;
		transformavelocidade = false;
		x = referencia.position.x;
		x1 = referencia2.position.x;
		startButton = GameObject.Find ("Start");
		start = false;
		n = 0.4f;
		m = 0.003f;		
		rig = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		p = true;
		
		t = GetComponent<Timer> ();
		
		fallingCoin = GameObject.Find ("FallingCoin").GetComponent<FallingCoin> ();
		

	

		Sounds = GameObject.Find ("Sounds").GetComponent<AthleticsSounds> ();



	}

	void MovimentaCurva ()
	{
		rig.velocity = velfrente * -transform.forward + vellado * transform.right;





		tempoabaixa += Time.deltaTime;
		if (vellado < 0.001) {
			rig.velocity = Vector3.zero;
			hit = 0;
		}


		if (velfrente >= 7) {
			n = 0.2f;
			m = 0.002f;	
		} else {
			if (velfrente >= 5) {
				n = 0.3f;
				m = 0.0035f;	
			} else { 
				n = 0.5f;
				m = 0.004f;	
			}
		}
		
		if (tempoabaixa > 0.3f && vellado > 0 && velfrente > 0) {
			velfrente -= 0.6f;
			vellado -= 0.006f;
			tempoabaixa = 0;
		}
		
		
		if (esquerda) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				velfrente += n;
				vellado += m;
				hit += 1;
				rightFoot.SetActive (true);
				leftFoot.SetActive (false);
				esquerda = false;
				
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				velfrente -= n;
				vellado -= m;
				hit = 0;
			}		
		} else {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				velfrente += n;
				vellado += m;
				rightFoot.SetActive (false);
				leftFoot.SetActive (true);
				hit += 1;
				esquerda = true;					
			}	
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				velfrente -= n;
				vellado -= m;
				hit = 0;
			}
		}
	}

	void Movimenta ()
	{




		if (rig.velocity != new Vector3 (0, 0, 0)) {

			if (rig.velocity.x < 1.2f && rig.velocity.x > -1.2f) {
				rig.velocity = Vector3.zero;
				hit = 0;
			}
		}
		
		if (esquerda) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity += velocidade * -transform.forward * 1.4f;
				rightFoot.SetActive (true);
				leftFoot.SetActive (false);
				hit += 1;
				esquerda = false;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity -= velocidade * -transform.forward * 1.4f;
				hit = 0;
			}
			
		} else {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity += velocidade * -transform.forward * 1.4f;
				rightFoot.SetActive (false);
				leftFoot.SetActive (true);
				hit += 1;
				esquerda = true;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity -= velocidade * -transform.forward * 1.4f;
				hit = 0;
			}
		}
		
	}

	void ControlaPosiçoes ()
	{
		
		if (transform.position.x < x1) {
			functionsScript.Rotation (referencia2, this.gameObject);
			if (AthleticsController.gameStarted) {
				MovimentaCurva ();
			}
			
		} else {
			
			if (transform.position.x < x) {
				Movimenta ();
				if (transform.position.z <= 19f) {
					rig.drag = 0.8f;
					rig.velocity = new Vector3 (rig.velocity.x, 0, 0);
					transform.rotation = Quaternion.Euler (new Vector3 (0, 270, 0));
					vellado = 0;
					velfrente = 0;
					fim = true;
					y = rig.velocity.x;
				} else {

					rig.velocity = new Vector3 (rig.velocity.x, 0, 0);	
					transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
					if (transform.position.x < -46 && fim) {
						termina = true;
						Sounds.PlayAudio (Sounds.applause);
						functionsScript.stopMove (rig);
						sbtimer.SetActive (false);
					}
					
				}
			} else {
				functionsScript.Rotation (referencia, this.gameObject);
				rig.drag = 1f;
				MovimentaCurva ();
				if (!transformavelocidade) {
					velfrente = n * y * 1.4f;
					vellado = m * y * 1.4f;
					transformavelocidade = true;				
				}			
				
			}
		}
	}

	void Bonus ()
	{
		
		if (hit >= 20) {
			
			bonusnumber += 10; 
			fallingCoin.coinFallAnimation ();
			hit = 0;
			
		} 
		bonus.text = "" + bonusnumber; 
		
	}

	public void startRunning ()
	{
		
		rightFoot.SetActive (false);
		leftFoot.SetActive (true);
		rig.velocity += -transform.forward * 25;
		velfrente = n * 20;
		vellado = m * 20;
		start = true;
		pronto = false;
		t.SetTimer ();
		startedRunning = true;
	
	}






	
	void Update ()
	{
	
		float m = 1;


		e1 = Mathf.Abs (rig.velocity.x);
		e2 = Mathf.Abs (rig.velocity.y);
		e3 = Mathf.Abs (rig.velocity.z);
		e4 = e1 + e3;
		
		if (e4 >= 1f) {
			v1.SetActive (true);
			if (e4 * m >= 3f) {
				v2.SetActive (true);

				if (e4 * m >= 7f) {
					v3.SetActive (true);

					if (e4 * m >= 9f) {
						v4.SetActive (true);

						if (e4 * m >= 10.5f) {
							v5.SetActive (true);
						} else {
							v5.SetActive (false);
						}
					} else {
						v4.SetActive (false);
						v5.SetActive (false);
					}
				} else {
					v3.SetActive (false);
					v4.SetActive (false);
					v5.SetActive (false);
				}
			} else {
				v2.SetActive (false);
				v3.SetActive (false);
				v4.SetActive (false);
				v5.SetActive (false);
			}
		} else {
			v1.SetActive (false);
			v2.SetActive (false);
			v3.SetActive (false);
			v4.SetActive (false);
		}




	
		//tempo.text = playertime.ToString ("0.0");


		if (t.time >= 3 && footSupportsDeleted == false) {
			
			footSupports.SetActive (false);
			footSupportsDeleted = true;
			t.ResetTimer ();
		}
		

		functionsScript.Animation (rig, animator);
		if (startedRunning && !termina) {
		
			playertime += Time.deltaTime;
			if (start) {
				ControlaPosiçoes ();
				Bonus ();

			}
		} 
	}
}