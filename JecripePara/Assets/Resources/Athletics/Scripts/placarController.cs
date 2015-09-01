using UnityEngine;
using System.Collections;

public class placarController : MonoBehaviour {

	public GUIText resultado;
	public AthleticsController AC;
	
	string winner;
	string loser;
	
	float winnerTime;
	float loserTime;
	
	void Start(){
		
		AC = GameObject.Find ("AthleticsController").GetComponent<AthleticsController>();
	}
	
	
	// Update is called once per frame
	void Update () {

		if (playerBehaviour2.termina && enemyBehaviour.termina) {
			if(playerBehaviour2.tempocorrida < enemyBehaviour.tempocorrida && playerBehaviour2.tempocorrida != 0){

				winner = "T Guilhermina";
				winnerTime = playerBehaviour2.tempocorrida;
				
				loser = "Oponente";
				loserTime = enemyBehaviour.tempocorrida;
				
				//resultado.text = "1. Jogador: " + playerBehaviour2.tempocorrida + "\n2. Oponente: "+ enemyBehaviour.tempocorrida;

			}
			else{
			
				loser = "T Guilhermina";
				loserTime = playerBehaviour2.tempocorrida;
				
				winner = "Oponente";
				winnerTime = enemyBehaviour.tempocorrida;
				

				//resultado.text = "1. Oponente: " + enemyBehaviour.tempocorrida  + "\n2. Jogador: "+ playerBehaviour2.tempocorrida ;

			}
			AC.GameOver(loser,winner,loserTime,winnerTime);

		}
	
	}
}
