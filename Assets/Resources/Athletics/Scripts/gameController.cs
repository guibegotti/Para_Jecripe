using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameController : MonoBehaviour {

	public Text result;
	public int prizecoins;
	public string breakRecord = "";

	private StoreDataContainer sD;
	private enemyBehaviour adversaryScript;
	private enemyBehaviour2 adversary2Script;
	private enemyBehaviour3 adversary3Script;
	private float time1,time2,time3, time4, aux; 
	private string first, second, third, fourth, saux, medal;
	private bool end;

	GameObject gameOverCanvas;
	GameObject canvas;

	Text place1;
	Text place2;
	Text place3;
	Text place4;
	
	
	
	void Start () {	
		
		adversaryScript = GameObject.Find ("adversary").GetComponent<enemyBehaviour>();
		adversary2Script = GameObject.Find ("adversary2").GetComponent<enemyBehaviour2>();
		adversary3Script = GameObject.Find ("adversary3").GetComponent<enemyBehaviour3>();
		end = false;
		
		gameOverCanvas = GameObject.Find ("GameOver");
		canvas = GameObject.Find("Canvas");

		if (PlayerPrefs.GetFloat ("bestTime") == 0) {
			PlayerPrefs.SetFloat ("bestTime", 90f);
		}
		
		//Sounds = GameObject.Find ("Sounds").GetComponent<AthleticsSounds>();
		
		place1 = GameObject.Find ("FirstPlace").GetComponent<Text>();
		place2 = GameObject.Find ("SecondPlace").GetComponent<Text>();	
		place3 = GameObject.Find ("ThirdPlace").GetComponent<Text>();
		place4 = GameObject.Find ("FourthPlace").GetComponent<Text>();
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
	

					
		
		place1.text = first;
		place2.text = second;
		place3.text = third;
		place4.text = fourth;
		
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
		third = "Terezinha Guilhermina e \nRafael Lazarino";
		
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
			first = third ;
			third  = saux;
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
			second = third ;
			third = saux;
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
			saux = third;
			third = fourth;
			fourth = saux;
		}
	}
	
	void showPrize(){
		
		if (first == "Terezinha Guilhermina e \nRafael Lazarino") {
			prizecoins = 1000;
			medal = "Parabéns você ganhou medalha de ouro e "+prizecoins +" moedas!";
		}
		if (second == "Terezinha Guilhermina e \nRafael Lazarino") {
			prizecoins = 700;
			medal = "Parabéns você ganhou medalha de prata e "+prizecoins +" moedas!";
		}
		if (third == "Terezinha Guilhermina e \nRafael Lazarino") {
			prizecoins = 500;
			medal = "Parabéns você ganhou medalha de bronze e "+prizecoins +" moedas!";;
		}
		if (fourth == "Terezinha Guilhermina e \nRafael Lazarino") {
			medal = "Não foi dessa vez! Tente mais vezes e conquiste medalhas!";
			prizecoins = 0;
		}
		
		sD = StoreDataContainer.Load();
		sD.storeObjects[0].coin += prizecoins;
		sD.Save();
		
	}
	
	void Update(){
		sortedTimes ();
	

		if (playerBehaviour2.termina) {
			StoreHighscore (playerBehaviour2.playertime);
			gameOverCanvas.SetActive (true);
			if (adversaryScript.termina && adversary2Script.termina && adversary3Script.termina && !end) {
			
				scoreBuilder ();
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