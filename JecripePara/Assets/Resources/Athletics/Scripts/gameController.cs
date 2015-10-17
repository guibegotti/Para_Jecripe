using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameController : MonoBehaviour {
	
	private enemyBehaviour adversaryScript, adversary2Script, adversary3Script;
	private float time1,time2,time3, time4, aux; 
	private string first, second, thirth, fourth, saux, medal;
	private bool end;
	GameObject gameOverCanvas;
	GameObject canvas;
	public Text result;
	public int prizecoins;
	public string breakRecord = "";
	
	
	
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

	void StoreHighscore(float newHighscore)
	{
		float oldHighscore = PlayerPrefs.GetFloat ("bestTime"); 
		if(newHighscore < oldHighscore)
		{
			PlayerPrefs.SetFloat("bestTime", newHighscore);
			breakRecord = " Você quebrou o Record!";
		}

	}
	
	public void Reload(){
		
		Application.LoadLevel(Application.loadedLevel);
		
	}
	
	public void BackToMenu(){
		Application.LoadLevel ("PlayAthletics");
	}
	
	void scoreBuilder(){
		
	
		
		gameOverCanvas.SetActive(true);
	
		
		showPrize ();
		
		result.text= medal+
					"\n1."+first+" "+ time1.ToString ("0.000")+"\n" +
					"2."+second+" "+time2.ToString ("0.000")+"\n" +
					"3."+thirth+" "+time3.ToString ("0.000")+"\n" +
					"4."+fourth+" "+time4.ToString ("0.000")+ "\n"+
					"Record: "+ PlayerPrefs.GetFloat ("bestTime")+ breakRecord;
		
		playerBehaviour2.bonusnumber += prizecoins;
		
		end = true;
		
	}

	void sortedTimes(){


		time1 = adversaryScript.adversary.coursetime;
		first = adversaryScript.adversary.name;
		time2 = adversary2Script.adversary.coursetime;
		second = adversary2Script.adversary.name;
		time4 = adversary3Script.adversary.coursetime;
		fourth = adversary3Script.adversary.name;
		time3 = playerBehaviour2.playertime;
		thirth = "Terezinha Guilhermina e Guilherme Santana";
		
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
			saux = thirth;
			thirth = fourth;
			fourth = saux;
		}
	}
	
	void showPrize(){
		
		if (first == "Terezinha Guilhermina e Guilherme Santana") {
			prizecoins = 1000;
			medal = "Parabéns você ganhou medalha de ouro e "+prizecoins +" moedas!";
		}
		if (second == "Terezinha Guilhermina e Guilherme Santana") {
			prizecoins = 700;
			medal = "Parabéns você ganhou medalha de prata e "+prizecoins +" moedas!";
		}
		if (thirth == "Terezinha Guilhermina e Guilherme Santana") {
			prizecoins = 500;
			medal = "Parabéns você ganhou medalha de bronze e "+prizecoins +" moedas!";;
		}
		if (fourth == "Terezinha Guilhermina e Guilherme Santana") {
			medal = "Não foi dessa vez! Tente mais vezes e conquiste medalhas!";
			prizecoins = 0;
		}
		
	
		
	}
	
	void Update(){
		sortedTimes ();
		if (playerBehaviour2.termina || adversaryScript.termina || adversary2Script.termina || adversary3Script.termina) {

			if (playerBehaviour2.termina) {
				StoreHighscore (playerBehaviour2.playertime);
				gameOverCanvas.SetActive (true);
				if (adversaryScript.termina && adversary2Script.termina && adversary3Script.termina && !end) {
					
					scoreBuilder ();
				}
			}
		}
		while (adversaryScript.adversary.id == adversary2Script.adversary.id || 
		       adversary3Script.adversary.id == adversary2Script.adversary.id ||
		       adversaryScript.adversary.id == adversary3Script.adversary.id) {
			
			adversary2Script.adversary.featuresAdversary (Random.Range (1,9));
			adversary3Script.adversary.featuresAdversary (Random.Range (1,9));
			
		}
		
		
	}
	
}