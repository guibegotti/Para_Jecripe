using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loja : MonoBehaviour {

	KeyCode DIREITA = KeyCode.RightArrow;
	KeyCode ESQUERDA = KeyCode.LeftArrow;
	
	bool trocarDireita;
	bool trocarEsquerda;
	bool setTimer;
	bool ww; //determina se o proximo item da loja já foi até o meio
	
	float timer;
	int i;
	
	GameObject Ll;
	GameObject loja1;
	GameObject loja2;

	
	public List<GameObject> lista = new List<GameObject>();	
	
	
	void Start(){
		timer = 0;
		setTimer = false;
		i = 0;
		loja1 = Instantiate(lista[i], Vector3.zero, Quaternion.identity) as GameObject;
		Ll = GameObject.Find ("Loja");
		loja1.transform.parent = Ll.transform;
		ww = true;

	}
	
	void Update(){
	
		//float largura = Screen.width/2;
		if (Input.GetKey(DIREITA) && ww == true){
			if(i==3){
				i = 0;
			} else {
				i++;
			}
			Vector3 posicao = new Vector3 (20, 0, 0);
			loja2 = Instantiate(lista[i], posicao, Quaternion.identity) as GameObject;
			loja2.transform.parent = Ll.transform;
			
			timer = 0;
			setTimer = true;
			trocarDireita = true;
			ww = false;
		}
		
		else if(Input.GetKey(ESQUERDA) && ww == true){
			if(i==0){
				i = 3;
			} else {
				i--;
			}
			Vector3 posicao = new Vector3 (-20, 0, 0);
			loja2 = Instantiate(lista[i], posicao, Quaternion.identity) as GameObject;
			loja2.transform.parent = Ll.transform;
			timer = 0;
			setTimer = true;
			trocarEsquerda = true;
			ww = false;
		}
		
		
		if(setTimer){
			timer += Time.deltaTime;
			
			if(trocarDireita){
				if(loja2.transform.position.x >= 0.5f) {
					loja1.transform.position = new Vector3 (loja1.transform.position.x - timer * 1.5f, loja1.transform.position.y, loja1.transform.position.z);
					loja2.transform.position = new Vector3 (loja2.transform.position.x - timer * 1.5f, loja1.transform.position.y, loja1.transform.position.z);
				} else {
					loja1 = loja2;
					setTimer = false;
					ww = true;
					trocarDireita = false;
				}
			}
			else if(trocarEsquerda){
				if(loja2.transform.position.x <= -0.5f) {
					loja1.transform.position = new Vector3 (loja1.transform.position.x + timer * 1.5f, loja1.transform.position.y, loja1.transform.position.z);
					loja2.transform.position = new Vector3 (loja2.transform.position.x + timer * 1.5f, loja1.transform.position.y, loja1.transform.position.z);
				} else {
					loja1 = loja2;
					setTimer = false;
					ww = true;
					trocarEsquerda = false;
				}
			}
			
		}
		

		
		
	}
	

}
