using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwimmingGameController : MonoBehaviour {

	GameObject player;
	Timer at;
	
	Vector3 maxvel;
	Vector3 movement;
	
	string lastSide;
	
	Text pointText;
	int points;
	
	public bool inWater;
	
	FallingCoin fc;
	GameObject gameOverCanvas;
	Text gameOverTitle;
	Text gameOverText;
	
	
	
	public GameObject firstPlace;
	public GameObject secondPlace;
	public GameObject thirdPlace;
	
	
	
	void Start()
	{
		Time.timeScale = 1;
		player = GameObject.Find ("Player");
		at = GameObject.Find ("ArmstrokeTimer").GetComponent<Timer>();
		pointText = GameObject.Find ("PointsText").GetComponent<Text>();
		gameOverCanvas = GameObject.Find ("GameOver");
		gameOverTitle = GameObject.Find ("GameOverTitle").GetComponent<Text>();
		gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
		fc = GameObject.Find ("FallingCoin").GetComponent<FallingCoin>();
		
		gameOverCanvas.SetActive(false);
		
		maxvel = new Vector3 (0.0f, 0.0f, 3);
		movement = new Vector3 (0, 0, 11f);
		
		points = 0;
		lastSide = "right";
		//addPoints(0);
	}	
	
	 
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			ArmStroke("left", "leftArmStrokeTrigger");
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			ArmStroke("right", "rightArmStrokeTrigger");
		}
		
		if(Time.timeSinceLevelLoad >= 3.5f){
			inWater = true;
		}
	}
	
	void ArmStroke(string thisSide, string sideTrigger)
	{
		if(player.GetComponent<Rigidbody>().velocity.z < maxvel.z 
				&& at.time <= 2f
				&& lastSide != thisSide){
				
			player.GetComponent<Animator>().SetTrigger(sideTrigger);
			MoveForward();
			at.SetTimer();
			lastSide = thisSide;
			addPoints(10);
			
		} else {
			at.ResetTimer();
		}
		
	}
	
	void MoveForward()
	{
		player.GetComponent<Rigidbody>().AddForce(movement * 13);
		Debug.Log (player.GetComponent<Rigidbody>().velocity);
	}
	
	
	void addPoints(int addPoints)
	{
		points += addPoints;
		pointText.text = points.ToString();
		fc.coinFallAnimation();
		
	}
	
	public void GameOver(int place)
	{
		Time.timeScale = 0;
		gameOverCanvas.SetActive(true);
		if(place == 1){
			gameOverTitle.text = "VOCÊ VENCEU!!!";
			
		} else {
			gameOverTitle.text = "FIM DE JOGO";
		}
		
		gameOverText.text = "CLASSIFICAÇÃO:\n1 - " + firstPlace.name 
			+ "\n2 - " + secondPlace.name 
			+ "\n3 - " + thirdPlace.name;
		
	}
	
	public void GameOver(bool noMoreOxygen)
	{
		Time.timeScale = 0;
		gameOverCanvas.SetActive(true);
		gameOverTitle.text = "O OXIGÊNIO ACABOU!";
		gameOverText.text = "Use a tecla ESPAÇO para respirar! Tente outra vez!";	
	}
	
	
	
	
	
}
