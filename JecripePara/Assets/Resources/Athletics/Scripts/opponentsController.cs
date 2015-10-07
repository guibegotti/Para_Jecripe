using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class opponentsController : MonoBehaviour {
	
	private enemyBehaviour adversaryScript, adversary2Script, adversary3Script;
	private float time1,time2,time3, time4, aux; 
	private string first, second, thirth, fourth, saux ;
	private bool end;
	GameObject gameOverCanvas;
	GameObject canvas;
	public Text result;

	
	
	void Start () {	
		
		adversaryScript = GameObject.Find ("adversary").GetComponent<enemyBehaviour>();
		adversary2Script = GameObject.Find ("adversary2").GetComponent<enemyBehaviour>();
		adversary3Script = GameObject.Find ("adversary3").GetComponent<enemyBehaviour>();
		end = false;

		gameOverCanvas = GameObject.Find ("Game");
		canvas = GameObject.Find("Canvas");

		//Sounds = GameObject.Find ("Sounds").GetComponent<AthleticsSounds>();
		
		gameOverCanvas.SetActive(false);
		
		
	}

	public void Reload(){
		
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	public void BackToMenu(){
		Application.LoadLevel ("PlayAthletics");
	}
	
	void scoreBuilder(){
		
		time1 = adversaryScript.adversary.coursetime;
		first = adversaryScript.adversary.name;
		time2 = adversary2Script.adversary.coursetime;
		second = adversary2Script.adversary.name;
		time3 = adversary3Script.adversary.coursetime;
		thirth = adversary3Script.adversary.name;
		time4 = playerBehaviour2.playertime;
		fourth = "Terezinha Guilhermina e Guilherme Santana";
		
		if (time1 > time2) {
			aux = time1;
			time1 = time2;
			time2 = aux;
			saux = first;
			first = second;
			second = saux;
		}
		if (time1 > time3) {
			aux = time1;
			time1 = time3;
			time3 = aux;
			saux = first;
			first = thirth ;
			thirth  = saux;
		}
		if (time1 > time4) {
			aux = time1;
			time1 = time4;
			time4 = aux;
			saux = first;
			first = fourth ;
			fourth  = saux;
		}
		if (time2 > time3) {
			aux = time2;
			time2 = time3;
			time3 = aux;
			saux = second;
			second = thirth ;
			thirth = saux;
		}
		if (time2 > time4) {
			aux = time2;
			time2 = time4;
			time4 = aux;
			saux = second;
			second = fourth;
			fourth = saux;
		}
		if (time3 > time4) {
			aux = time3;
			time3 = time4;
			time4 = aux;
			saux = second;
			second = fourth;
			fourth = saux;
		}

		gameOverCanvas.SetActive(true);
		canvas.SetActive(false);

		result.text="1."+first+" "+ time1.ToString ("0.000")+"\n" +
					"2."+second+" "+time2.ToString ("0.000")+"\n" +
					"3."+thirth+" "+time3.ToString ("0.000")+"\n" +
					"4."+fourth+" "+time4.ToString ("0.000");
		
		end = true;
		
	}
	void Update(){


		if (adversaryScript.termina && adversary2Script.termina && adversary3Script.termina && playerBehaviour2.termina && !end) {
			
			scoreBuilder();
			
		}
				
		while (adversaryScript.adversary.id == adversary2Script.adversary.id || 
		       adversary3Script.adversary.id == adversary2Script.adversary.id ||
		       adversaryScript.adversary.id == adversary3Script.adversary.id) {
			
			adversary2Script.adversary.featuresAdversary (Random.Range (1,9));
			adversary3Script.adversary.featuresAdversary (Random.Range (1,9));
			
		}
		
		
	}
	
}
