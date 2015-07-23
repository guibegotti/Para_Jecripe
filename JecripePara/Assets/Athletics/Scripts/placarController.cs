using UnityEngine;
using System.Collections;

public class placarController : MonoBehaviour {

	public GUIText resultado;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (playerBehaviour2.termina && enemyBehaviour.termina) {
			if(playerBehaviour2.tempocorrida < enemyBehaviour.tempocorrida && playerBehaviour2.tempocorrida != 0){

				resultado.text = "1. Jogador: " + playerBehaviour2.tempocorrida + "\n2. Oponente: "+ enemyBehaviour.tempocorrida;

			}
			else{

				resultado.text = "1. Oponente: " + enemyBehaviour.tempocorrida  + "\n2. Jogador: "+ playerBehaviour2.tempocorrida ;

			}

		}
	
	}
}
