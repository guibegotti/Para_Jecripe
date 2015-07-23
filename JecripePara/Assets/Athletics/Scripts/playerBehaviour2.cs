using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerBehaviour2 : MonoBehaviour
{
	
	public Rigidbody rig;
	public float velocidade, tempocomeça, x, x1, velocidadeanimacao, vellado, velfrente, tempoabaixa;
	public GUIText tela, numeroApertar, teste;
	public Text tempo;
	public bool pronto, podeSortear, esquerda, direita, transformavelocidade, rota, abaixa, start;
	static public bool começa, termina, perdeu;
	static public float tempocorrida;
	public Animator animator;
	public Transform referencia, referencia2;
	GameObject startButton;
	GameObject waitButton;
	public Text countDown;

	void MovimentaCurva ()
	{
		rig.velocity = velfrente * -transform.forward + vellado * transform.right;
		tempoabaixa += Time.deltaTime;

		if (tempoabaixa > 0.15f && vellado > 0 && velfrente > 0) {
			velfrente -= 1.375f;
			vellado -= 0.025f;
			tempoabaixa = 0;
		}
	

		if (esquerda) {
			numeroApertar.text = "\n \n \n \n4";
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				velfrente += 1.375f;
				vellado += 0.025f;
				esquerda = false;
			}
		} else {
			numeroApertar.text = "\n \n \n \n                    6";
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				velfrente += 1.375f;
				vellado += 0.025f;
				esquerda = true;					
			}				
		}
	}

	void Movimenta ()
	{
		if (rig.velocity != new Vector3 (0, 0, 0)) {
			rig.drag = 0.2f;
		}

		if (esquerda) {
			numeroApertar.text = "\n \n \n \n4";
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity += velocidade * -transform.forward;
				esquerda = false;
			}
		} else {
			numeroApertar.text = "\n \n \n \n                    6";
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity += velocidade * -transform.forward;
				esquerda = true;
			}
		}

	}

	void ControlaPosiçoes ()
	{
	
		if (transform.position.x < x1) {
			Rotaciona (referencia2);
			if (começa) {
				MovimentaCurva ();
			}

		} else {

			if (transform.position.x < x) {
				rota = false;
				if (transform.position.z < -3.2f) {
					transform.position = new Vector3 (transform.position.x, transform.position.y, -3.5f);
					transform.rotation = Quaternion.Euler (new Vector3 (0, 270, 0));
					vellado = 0;
					velfrente = 0;
				} else {
					transform.position = new Vector3 (transform.position.x, transform.position.y, 228.3f);
					transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));

				}
			} else {
				Rotaciona (referencia);
				if (!perdeu) {
					MovimentaCurva ();
				}
				rota = true;
			}
		}
	}
	
	void Start ()
	{

		velocidade = 1;
		pronto = false;
		começa = false;
		termina = false;
		esquerda = true;
		direita = false;
		transformavelocidade = false;
		tempocomeça = 3;
		x = referencia.position.x;
		x1 = referencia2.position.x;
		startButton = GameObject.Find ("Start");
		waitButton = GameObject.Find ("Wait");
		start = false;
		

	}

	void Anima ()
	{
		print (rig.velocity);
		if (start) {
			if (rig.velocity != new Vector3 (0, 0, 0)) {
				animator.SetBool ("inIdle", false);
				animator.SetBool ("inRun", true);
				animator.SetBool ("inStart", false);
			} else {
				animator.SetBool ("inIdle", true);
				animator.SetBool ("inRun", false);
				animator.SetBool ("inStart", false);
			}
		} else {
			animator.SetBool ("inIdle", false);
			animator.SetBool ("inRun", false);
			animator.SetBool ("inStart", true);
		}
	}

	void Rotaciona (Transform referencia)
	{
		float dx = this.transform.position.x - referencia.position.x;
		float dy = this.transform.position.z - referencia.position.z;
		float angle = Mathf.Atan2 (dx, dy) * Mathf.Rad2Deg;
		Quaternion rot = Quaternion.Euler (new Vector3 (0, angle + 90, 0));
		this.transform.rotation = rot;
	}
	
	// Update is called once per frame
	void Update ()
	{

		Anima ();
		if (transform.position.x < 0 && transform.position.z > 200) {
			termina = true;
			rig.drag = 1.5f;
		}
		tempo.text = tempocorrida.ToString("0.0");
		if (pronto) {
			countDown.text = "" + Mathf.Round (tempocomeça);
			tempocomeça -= Time.deltaTime;
			startButton.SetActive (false);

		} else {
			tela.text = "Pronto?";
			if (Input.GetKeyDown (KeyCode.Space)) {
				pronto = true;
			}
		}
		if (tempocomeça <= 0.5f) {
			começa = true;
			tela.text = "   ";
			waitButton.SetActive (false);
			if (!start) {
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					velfrente = 1.375f * 20;
					vellado = 0.025f * 20;
					start = true;
				}
			}			
		}

		if (começa && !termina && start) {
			tempocorrida += Time.deltaTime;
			ControlaPosiçoes ();
			if (!rota) {
				Movimenta ();
			
			} else {
				if (!transformavelocidade) {
					rig.velocity = Vector3.zero;
					velfrente = 1.375f * 12;
					vellado = 0.025f * 12;
					transformavelocidade = true;				
				}
			}
		} else {
			numeroApertar.text = "";

			if (perdeu) {
				tempocorrida = 0;
			}
		}
	}
}
