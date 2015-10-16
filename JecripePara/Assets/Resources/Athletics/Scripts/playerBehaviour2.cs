using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerBehaviour2 : MonoBehaviour
{
	
	public Rigidbody rig;
	public Animator animator;
	public float velocidade, tempocomeça, x, x1, y, velocidadeanimacao, vellado, velfrente, tempoabaixa, n,m, tempotermina;
	public Text tempo;
	public int hit, bonusnumber;
	public bool pronto, esquerda, transformavelocidade,  abaixa, fim;
	public GUIText arrow, bonus;
	
	//AthleticsSounds Sounds;
	
	static public bool começa, termina,start;
	static public float playertime;
	public Transform referencia, referencia2;
	GameObject startButton;
	GameObject waitButton;
	public Text countDown;

	public GameObject canvas;
	
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
		tempocomeça = 3;
		x = referencia.position.x;
		x1 = referencia2.position.x;
		startButton = GameObject.Find ("Start");
		waitButton = GameObject.Find ("Wait");
		start = false;
		n = 0.5f;
		m = 0.003f;		
		rig = GetComponent<Rigidbody>();
		animator = GetComponent<Animator> ();
		//Sounds = GameObject.Find ("Sounds").GetComponent<AthleticsSounds>();

	}
	
	void MovimentaCurva ()
	{
		rig.velocity = velfrente * -transform.forward + vellado * transform.right;
		tempoabaixa += Time.deltaTime;
		
		if (vellado < 0.001) {
			rig.velocity = Vector3.zero;
			hit = 0;
		}
		
		if (tempoabaixa > 0.1f  && vellado > 0 && velfrente > 0) {
			velfrente -= n;
			vellado -= m;
			tempoabaixa = 0;
		}
		
		
		if (esquerda) {
			//numeroApertar.text = "\n \n \n \n4";
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				velfrente += n;
				vellado += m;
				hit +=1;
				arrow.text = "                                >";
				esquerda = false;
				
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				velfrente -= n;
				vellado -= m;
				hit = 0;
			}		
		} else {
			//numeroApertar.text = "\n \n \n \n                    6";
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				velfrente += n;
				vellado += m;
				arrow.text = "<";
				hit += 1;
				esquerda = true;					
			}	
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				velfrente -= n;
				vellado -= m;
				hit =0;
			}
		}
	}
	
	void Movimenta ()
	{
		if (rig.velocity != new Vector3 (0, 0, 0)) {
			rig.drag = 0.8f;
			if(rig.velocity.x < 0.7f &&  rig.velocity.x > -0.7f){
				rig.velocity = Vector3.zero;
				hit = 0;
			}
		}
		
		if (esquerda) {
			//numeroApertar.text = "\n \n \n \n4";
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity += velocidade * -transform.forward;
				arrow.text = "                                >";
				hit +=1;
				esquerda = false;
			}
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity -= velocidade * -transform.forward;
				hit = 0;
			}
			
		} else {
			//numeroApertar.text = "\n \n \n \n                    6";
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				rig.velocity += velocidade * -transform.forward;
				arrow.text = "<";
				hit += 1;
				esquerda = true;
			}
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				rig.velocity -= velocidade * -transform.forward;
				hit = 0;
			}
		}
		
	}
	
	void ControlaPosiçoes ()
	{
		
		if (transform.position.x < x1) {
			functionsScript.Rotation  (referencia2, this.gameObject );
			if (começa) {
				MovimentaCurva ();
			}
			
		} else {
			
			if (transform.position.x < x) {
				Movimenta ();
				if (transform.position.z <= 19f) {
					if(transform.position.z >= 16.5f){
						rig.velocity = new Vector3(rig.velocity.x,0,-20*Time.deltaTime);
					}
					else{
						if(transform.position.z <= 16.3f){
							rig.velocity = new Vector3(rig.velocity.x,0,20*Time.deltaTime);
						}
						else{
							rig.velocity = new Vector3(rig.velocity.x,0,0);
						}
					}
					transform.rotation = Quaternion.Euler (new Vector3 (0, 270, 0));
					vellado = 0;
					velfrente = 0;
					fim = true;
					y = rig.velocity.x;
				} else {
					//<<<<<<< HEAD
					
					if(transform.position.z <= 96.5f){
						rig.velocity = new Vector3(rig.velocity.x,0,20*Time.deltaTime);
					}
					else{
						rig.velocity = new Vector3(rig.velocity.x,0,0);
					}					//=======
					
					//>>>>>>> guibegotti/master
					transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
					if (transform.position.x < -46 && fim) {
						termina = true;
						tempotermina += Time.deltaTime;
						if(tempotermina > 1 ){
							rig.velocity = Vector3.zero;
						}
						rig.drag = 1.5f;
					}
					
				}
			} else {
				functionsScript.Rotation  (referencia, this.gameObject );
				MovimentaCurva ();
				if (!transformavelocidade) {
					velfrente = n *y * 2f;
					vellado = m * y * 2f;
					transformavelocidade = true;				
				}			
				
			}
		}
	}
	
	void Bonus(){
		
		if (hit >= 20) {
			
			bonusnumber += 100; 
			hit = 0;
			
		} 
		bonus.text = hit + "\n" + bonusnumber; 
		
	}
	
	
	
	
	
	// Update is called once per frame
	void Update ()
	{
		functionsScript.Animation (rig, animator);	
		
		
		
		tempo.text = playertime.ToString("0.0");
		
		if (pronto) {
			countDown.text = "" + Mathf.Round (tempocomeça);
			tempocomeça -= Time.deltaTime;
			startButton.SetActive (false);
			if (tempocomeça <= 0.2f) {
				começa = true;
				waitButton.SetActive (false);
				if (!start) {
					if (Input.GetKeyDown (KeyCode.UpArrow)) {
						rig.velocity += -transform.forward * 25;
						velfrente = n * 18;
						vellado = m * 18;
						start = true;
						pronto = false;
					}
				}			
			}
			
		} else {
			if (Input.GetKeyDown (KeyCode.Space)) {
				pronto = true;
				canvas.SetActive(true);
			}
		}
		
		
		if (começa && !termina) {
			playertime += Time.deltaTime;
			if(start){
				ControlaPosiçoes ();
				Bonus ();
			}
		} 
	}
}