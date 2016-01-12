using UnityEngine;
using System.Collections;

public class veronica_Behaviour : MonoBehaviour {

	private int pontos = 0;
	private int nro_salto = 1;
	public UnityEngine.UI.Text placar, entreSaltos, pontuacao;
	public bool comeca, esquerda, salto, chao, ar, final, queimou, uma_vez, tutorial_window = true;
	public GameObject janelaStart, rightFoot, leftFoot, janelaError, janelaResultado, pule_text, janelaEntreSaltos;
	public GameObject janelaTutorial; 
	public UnityEngine.UI.Button botaoSim, botaoNao;
	public Rigidbody rig;
	public float velocidade, distancia, posicao_final, salto1 = -1f, salto2 = -1f, salto3 = -1f;
	public Animator animator;
	public Transform referencia, salto_invalido;
	float adversario1, adversario2, adversario3, adversario4;
	//float[][] resultados = new float[2][5];
	string adversarios_name0;
	string adversarios_name1;
	string adversarios_name2;
	string adversarios_name3;
	string adversarios_name4;
	string adversarios_name5;
	string adversarios_name6;
	string adversarios_name7;
	string adversarios_name8;
	string adversarios_name9;

	private bool canContinue;
	private bool canRun;

	public void tutorial(){
		print ("TUTORIAL");
		tutorial_window = false;
		this.Start ();
	}

	public void sem_tutorial(){
		tutorial_window = false;
		janelaTutorial.SetActive(false);
		this.Start ();
	}


	void Start () {
		canRun = true;
		canContinue = false;

		janelaTutorial.SetActive(false);
		if (false){ //tutorial_window
			janelaStart.SetActive(false);
			janelaTutorial.SetActive(true);
		}

		pontuacao.text = pontos.ToString ();
		uma_vez = true;
		chao = true;
		pule_text.SetActive (false);
		janelaError.SetActive(false);
		janelaResultado.SetActive(false);
		janelaEntreSaltos.SetActive(false);
		salto = false;
		ar = false;
		final = false;

		comeca = true;
		if (nro_salto == 1){
			comeca = false;
		}

		esquerda = true;
		queimou = false;
		velocidade = 1.5f;
		rig = GetComponent<Rigidbody>();
		animator = GetComponent<Animator> ();
		adversario1 = Random.Range(3.4f, 4.2f);
		adversario2 = Random.Range(4.0f, 4.7f);
		adversario3 = Random.Range(4.2f, 4.9f);
		adversario4 = Random.Range(4.5f, 5.0f);
		//print ("adversario1 " + adversario1 + " adversario2 " + adversario2 + " adversario3 " + adversario3 + " adversario4 " + adversario4);

		adversarios_name0 = "Manuela Larreta";
		adversarios_name1 = "Yanis Kyrgiakos";
		adversarios_name2 = "Ellen Banes";
		adversarios_name3 = "Mi Yang Fu";
		adversarios_name4 = "Olga Gouvêia";
		adversarios_name5 = "Chidinma Essien";
		adversarios_name6 = "Anouka Aymee";
		adversarios_name7 = "Marie-Soleil Beau";
		adversarios_name8 = "Rien Husen";
		adversarios_name9 = "Liang Jin";

		if (nro_salto == 1)
			entreSaltos.text = "Parabéns, seu salto foi válido!\nVoce ganhou 200 moedas!\n\n";

	}




	// Update is called once per frame
	void Update () {
		animator.SetFloat("speed", rig.velocity.magnitude);

		if (!ar && chao && (transform.position.x <= salto_invalido.position.x)){
			canRun = false;
			janelaError.SetActive(true);
			janelaResultado.SetActive(false);
			animator.SetBool("idle", true);
			animator.SetBool("run", false);
			animator.SetBool("jump", false);
			queimou = true;
			if (uma_vez){
				entreSaltos.text += nro_salto+"º salto invalido!\n";
				uma_vez = false;
			}


			rig.velocity.Set(0f,0f,0f);

			if (salto1 == -1f && nro_salto == 1){
				salto1 = 0f;
				salto2 = -2f;
			} else {
				if (salto2 == -2f && nro_salto == 2){
					salto2 = 0f;
					salto3 = -3f;
				} else {
					if (salto3 == -3f && nro_salto == 3){
						salto3 = 0f;
					}
				}
			}
			if (canContinue == true) {
				canContinue = false;
				nro_salto++;
				rig.velocity = Vector3.zero;
				animator.SetBool("idle", true);
				animator.SetBool("run", false);
				animator.SetBool("jump", false);
				transform.position = new Vector3(60.95f,3.7256f,152.71f);
				rightFoot.SetActive (false);
				leftFoot.SetActive (false);
				
				this.Start();
			}

		}

		if (salto && chao) {

			if(transform.position.x < -21f && transform.position.x > -37.5f){
				pule_text.SetActive (true);
			} else {
				pule_text.SetActive (false);
			}

			if (Input.GetKeyDown (KeyCode.UpArrow) && !queimou) {
				animator.SetBool("idle", false);
				animator.SetBool("run", false);
				animator.SetBool("jump", true);
				rig.velocity -= velocidade * -transform.forward;
				rig.AddForce(Vector3.up * 250f);			
				ar = true;
				chao = false;

			}
		}

		if(ar){
			if(transform.position.y < 3.72){
				animator.SetBool("idle", true);
				animator.SetBool("run", false);
				animator.SetBool("jump", false);
				if(!final){
					posicao_final = transform.position.x;
					distancia = (((posicao_final + 45f) / -19f) * 1.4f) + 3.5f;
					final = true;
				}


				if (salto1 == -1f && nro_salto == 1){
					salto1 = distancia;
					salto2 = -2f;
				} else {
					if (salto2 == -2f && nro_salto == 2){
						salto2 = distancia;
						salto3 = -3f;
					} else {
						if (salto3 == -3f && nro_salto == 3){
							salto3 = distancia;
						}
					}
				}


				

				if (salto3 > -1f){

					if (salto1 > salto2 && salto1 > salto3){
						distancia = salto1;
					} else {
						if (salto2 > salto1 && salto2 > salto3){
							distancia = salto2;
						} else {
							if (salto3 > salto2 && salto3 > salto1){
								distancia = salto3;
							}
						}
					}

					float[] resultado = new float[5];
					resultado[0] = distancia;
					resultado[1] = adversario1;
					resultado[2] = adversario2;
					resultado[3] = adversario3;
					resultado[4] = adversario4;


					float aux;
					for(int k = 0; k < 4; k++){
						for(int l = k+1; l < 5; l++){
							if (resultado[k] < resultado[l]){
								aux = resultado[k];
								resultado[k] = resultado[l];
								resultado[l] = aux;
							}
						}
					}

					float primeiro = resultado[0], segundo = resultado[1], terceiro = resultado[2], quarto = resultado[3], quinto = resultado[4];

					string[] resultados_nome = new string[5];
					int adv = Random.Range(0,6);

					if(primeiro == distancia){
						resultados_nome[0] = "Veronica Hipolito";
						resultados_nome[1] = adversarios_name0;
						resultados_nome[2] = adversarios_name1;
						resultados_nome[3] = adversarios_name2;
						resultados_nome[4] = adversarios_name3;
					} else {
						resultados_nome[0] = adversarios_name4;
						if(segundo == distancia){
							resultados_nome[1] = "Veronica Hipolito";
							resultados_nome[2] = adversarios_name5;
							resultados_nome[3] = adversarios_name6;
							resultados_nome[4] = adversarios_name7;
						} else {
							resultados_nome[1] = adversarios_name8;
							if(terceiro == distancia){
								resultados_nome[2] = "Veronica Hipolito";
								resultados_nome[3] = adversarios_name9;
								resultados_nome[4] = adversarios_name8;
							} else {
								resultados_nome[2] = adversarios_name7;
								if(quarto == distancia){
									resultados_nome[3] = "Veronica Hipolito";
									resultados_nome[4] = adversarios_name6;
								} else {
									resultados_nome[3] = adversarios_name5;
									if(quinto == distancia){
										resultados_nome[4] = "Veronica Hipolito";
									} else {
										resultados_nome[4] = adversarios_name4;
									}
								}

							}

						}


					}

				
					string prize_veronica;
					if(resultados_nome[0] == "Veronica Hipolito"){
						prize_veronica = "Parabéns, você ganhou medalha de ouro!\nVoce ganhou 1500 moedas!\n";
					} else{
						if(resultados_nome[1] == "Veronica Hipolito"){
							prize_veronica = "Parabéns, você ganhou medalha de prata!\nVoce ganhou 1000 moedas!\n";
						} else{
							if(resultados_nome[2] == "Veronica Hipolito"){
								prize_veronica = "Parabéns, você ganhou medalha de bronze!\nVoce ganhou 600 moedas!\n";
							} else {
								prize_veronica = "Não foi dessa vez! Tente mais vezes e conquiste medalhas!\n";
							}
						}
					}

					if (uma_vez){
						pontos += 200;
						entreSaltos.text += nro_salto+"º salto - Resultado: "+salto3.ToString("0.00")+"m.\n";
						uma_vez = false;
					}
					canRun = false;
					//janelaResultado.SetActive(false);
					//janelaEntreSaltos.SetActive(true);
					janelaResultado.SetActive(true);

					print ("salto1: "+salto1+"; "+"salto2: "+salto2+"; "+"salto3: "+salto3+"!");
					placar.text = prize_veronica+"Resultado final:\n"
						+"1ª\t"+resultados_nome[0]+"\t"+primeiro.ToString("0.00")+"m\n"
							+"2ª\t"+resultados_nome[1]+"\t"+segundo.ToString("0.00")+"m\n"
							+"3ª\t"+resultados_nome[2]+"\t"+terceiro.ToString("0.00")+"m\n"
							+"4ª\t"+resultados_nome[3]+"\t"+quarto.ToString("0.00")+"m\n"
							+"5ª\t"+resultados_nome[4]+"\t"+quinto.ToString("0.00")+"m\n";



				}//if 3 saltos
				else {
					print ("salto1: "+salto1+"; "+"salto2: "+salto2+"; "+"salto3: "+salto3+"!");
					canRun = false;
					janelaResultado.SetActive(false);
					janelaEntreSaltos.SetActive(true);
					if (uma_vez){
						pontos += 200;
						entreSaltos.text += nro_salto+"º salto - Resultado: "+distancia.ToString("0.00")+"m.\n";
						uma_vez = false;
					}
					if (canContinue == true) {
						canContinue = false;
						rig.velocity = Vector3.zero;
						animator.SetBool("idle", true);
						animator.SetBool("run", false);
						animator.SetBool("jump", false);
						nro_salto++;
						transform.position = new Vector3(60.95f,3.7256f,152.71f);
						rightFoot.SetActive (false);
						leftFoot.SetActive (false);

						this.Start();
					}
				}



			}
			
		}

		if (transform.position.x < referencia.position.x) {
			salto = true;
		}
	

		if (comeca) {

			janelaStart.SetActive(false);
			if(canRun){
				if (esquerda) {

					if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						animator.SetBool("idle", false);
						animator.SetBool("run", true);
						animator.SetBool("jump", false);

						rig.velocity += velocidade * -transform.forward;
						rightFoot.SetActive (true);
						leftFoot.SetActive (false);
						esquerda = false;
					}
					if (Input.GetKeyDown (KeyCode.RightArrow)) {
						rig.velocity -= velocidade * -transform.forward;
					}
					
				} else {

					if (Input.GetKeyDown (KeyCode.RightArrow)) {
						animator.SetBool("idle", false);
						animator.SetBool("run", true);
						animator.SetBool("jump", false);

						rig.velocity += velocidade * -transform.forward;
						rightFoot.SetActive (false);
						leftFoot.SetActive (true);
						esquerda = true;
					}
					if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						rig.velocity -= velocidade * -transform.forward;
					}
				}
			}

		} else {
			janelaStart.SetActive(true);
			if (Input.GetKeyDown (KeyCode.Space)) {
				comeca = true;

				animator.SetBool("idle", true);
				animator.SetBool("run", false);
				animator.SetBool("jump", false);
			}
		}
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void BackToMenu(){
		Application.LoadLevel ("");
	}

	public void Continue(){
		canContinue = true;
	}

}
