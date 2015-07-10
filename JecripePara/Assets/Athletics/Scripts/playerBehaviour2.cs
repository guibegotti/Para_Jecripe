using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerBehaviour2 : MonoBehaviour {
	
	public Rigidbody rig;
	public float velocidade, tempocomeça,x,x1,velocidadeanimacao;
	public GUIText tempo, tela, numeroApertar, teste;
	public bool pronto, podeSortear, esquerda, direita, transformavelocidade, rota, l;
	static public bool começa, termina, perdeu;
	static public float tempocorrida;
	public Animator animator;
	public Transform referencia;
	public int numeroacertos = 0, numeroerros = 0;
	GameObject startButton;
	GameObject waitButton;
	public Text countDown;
	
	public GameObject gameOverCanvas;



	void MovimentaCurva(){
		if (numeroerros >= 5) {
			tempocorrida = 0;
			termina = true;
			perdeu = true;
			print ("Queimou a raia!");
		}

		rig.velocity = -transform.forward * 27.5f + transform.right * 0.5f;
			if (esquerda) {
				numeroApertar.text = "\n \n \n \n 4";
				if (!direita) {
					if (Input.GetKeyUp (KeyCode.LeftArrow )) {
						direita = true;
						numeroacertos +=1;
					} else {
						if (Input.GetKeyDown (KeyCode.RightArrow)) {
						numeroerros += 1;
						}
					}
				}
				if (direita) {
					if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						numeroacertos +=1;
						esquerda = false;
						direita = false;
					} else {
						if (Input.GetKeyDown (KeyCode.LeftArrow)) {
							numeroerros += 1;
						}
					}
				}
			} else {
			numeroApertar.text = "\n \n \n \n                    6";
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					esquerda = true;
					numeroacertos +=1;
				} else {
					if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						numeroerros +=1;
					}
				}

			}


	}
	void Movimenta(){

		if (esquerda && !direita) {
			numeroApertar.text = "\n \n \n \n4";
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity += velocidade* -transform.forward ;
				esquerda = false;
				direita = true;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity += new Vector3(0.01f,0,0);

			}
		} else {
			if (!esquerda && direita) {
				numeroApertar.text = "\n \n \n \n                    6";
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					rig.velocity += velocidade* -transform.forward ;
					esquerda = true;
					direita = false;
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
					rig.velocity += new Vector3(0.01f,0,0);
						
				}
			}
		}
	}
	
	
	void Start () {
		
		pronto = false;
		começa = false;
		termina = false;
		esquerda = true;
		direita = false;
		transformavelocidade = false;
		tempocomeça = 3;
		x = transform.position.x;
		startButton = GameObject.Find ("Start");
		waitButton = GameObject.Find ("Wait");
		gameOverCanvas = GameObject.Find ("GameOver");
		gameOverCanvas.SetActive(false);
		

	}
	void Anima(){
		if (rig.velocity != new Vector3 (0, 0, 0)) {
			animator.SetBool ("inIdle", false);
			animator.SetBool ("inRun", true);
		} else {
			animator.SetBool ("inIdle", true);
			animator.SetBool ("inRun", false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		Anima ();
		// b = Vector3.Distance (referencia.position,transform.position );

		if (transform.position.x >= (x + 120) && transform.position.x < (x+158)&& transform.position.z <=0){				
			teste.text = "Prepare-se para a curva!";				
		}
		else{
			teste.text = "";
		}
		
		
		tempo.text = "Tempo: " + tempocorrida;
		if (transform.position.x >= (x + 158)) {
			float dx = this.transform.position.x - referencia.position.x;
			float dy = this.transform.position.z - referencia.position.z;
			float angle = Mathf.Atan2 (dx, dy) * Mathf.Rad2Deg;
			Quaternion rot = Quaternion.Euler (new Vector3 (0, angle + 90, 0));
			this.transform.rotation = rot;
			if (!rota) {
				rota = true;
			}
		} else {
			if(transform.position.z >=225.3f && !perdeu){
				transform.position = new Vector3(transform.position.x,transform.position.y,225.5f);
				transform.rotation =  Quaternion.Euler (new Vector3 (0,90, 0));
				if(numeroacertos <= 15){
					tempocorrida = 0;
					termina = true;
					perdeu = true;
				}

				if(transform.position.x <= x){
				termina = true;
				}
			}



			rota = false;
		}

		if (termina) {

			numeroApertar.text = "";
			gameOverCanvas.SetActive(true);
			tempo.text = "";

		}

		if (!pronto) {
			tela.text = "Pronto?";
			if(Input.GetKeyDown (KeyCode.Space)){
				pronto = true;
			}
		}
		if (pronto) {
			countDown.text = ""+ Mathf.Round(tempocomeça);
			tempocomeça -= Time.deltaTime;
			startButton.SetActive(false);
		}
		if (tempocomeça <= 0.5f) {
			começa = true;
			tela.text = "   ";
			waitButton.SetActive(false);
			
		}
		velocidade = 1.0f;
		if (começa && !termina) {
			numeroApertar.text = "";
			if(perdeu){
				teste.text = "Queimou a raia!";
			}
			tempocorrida += Time.deltaTime;
			if(!rota){
			Movimenta ();
			}
			else{
				if(!transformavelocidade ){
					x1 = rig.velocity.x;
					rig.velocity = Vector3.zero;
					transformavelocidade = true;
					esquerda = true;
					direita = false;
				
				}
				MovimentaCurva();
			}
		}
	}
}
