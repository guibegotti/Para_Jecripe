using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player;
	private PlayerController pC;
	public GameObject pHitArea;
	public GameObject playerTarget;

	public GameObject enemy;
	private EnemyController eC;
	public GameObject eHitArea;
	public GameObject enemyTarget;

	public GameObject ball;

	public GameObject Fade;
	private Renderer fadeRenderer;
	private Color fadeColor;
	private bool fadeIn, fadeOut;
	private float fadeTime = 0f;

	private int bounces;

	private bool inGame;
	private int serve; //1 = player, -1 = enemy;

	private int servingSide=1; //-1 left, 1 Right

	public Text scoreText; 

	private BallController bC;

	public bool playerTurn;

	private string[] score;
	private int playerScore;
	private int enemyScore;
	private int playerGameCount;
	private int enemyGameCount;
	private int playerSetCount;
	private int enemySetCount;


	void Start () {
		fadeIn = false;
		fadeOut = false;
		fadeRenderer = Fade.GetComponent<Renderer>();
		fadeColor = fadeRenderer.material.color;
		fadeColor.a = 0;
		fadeRenderer.material.color = fadeColor;

		pC = player.GetComponent<PlayerController> ();
		eC = enemy.GetComponent<EnemyController>();
		bC = ball.GetComponent<BallController> ();

		
		score = new string[]{"0", "15", "30", "40", "ADV", "0"};		
		
		playerScore = 0;
		enemyScore = 0;
		playerGameCount = 0;
		enemyGameCount = 0;
		playerSetCount = 0;
		enemySetCount = 0;
		serve = 1;
		scoreText.text = "Player  :  " + score[0] + "   " + playerGameCount+ "   " + playerSetCount + "\n" +
						 "Enemy :  " + score[0]   + "   " + enemyGameCount + "   " + enemySetCount; 
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (fadeOut == true){
			fadeTime += Time.deltaTime;
			if (fadeTime> 2 && fadeTime<2.5){
				fadeColor.a += 0.05f;
				fadeRenderer.material.color = fadeColor;
			}
			else if(fadeTime>=2.5f){
				fadeTime = 0;
				fadeOut = false;
				fadeIn = true;
				StartGame();
			}
		}
		if(fadeIn == true){
			fadeTime += Time.deltaTime;
			if (fadeTime>0.5 && fadeTime<1){
				fadeColor.a -= 0.07f;
				if(fadeColor.a <0){
					fadeColor.a =0;
				}
				fadeRenderer.material.color = fadeColor;
			}
			else if(fadeTime>=1){
				fadeTime = 0;
				fadeIn = false;
			}
		}
	}

	public void AddBounce(){
		bounces ++;
		if(bounces ==3){
			if(playerTurn == true){
				SetScore(-1);
			}
			else{
				SetScore(1);
			}
		}
	}
	public void ResetBounce(){
		bounces = 0;
	}
	private void SetScore(int t){		
		if(inGame == true){
			if(t == -1){
				enemyScore++;
			}
			else if(t== 1){
				playerScore++;
			}
			if (playerScore ==4 && enemyScore <3){
				playerGameCount ++;
				enemyScore = 0;
				playerScore = 0;
				serve *= -1;
			}
			else if (enemyScore ==4 && playerScore <3){
				enemyGameCount ++;
				enemyScore = 0;
				playerScore = 0;
				serve *= -1;
			}
			else if (enemyScore == 4 && playerScore == 4){
				playerScore = 3;
				enemyScore = 3;
			}
			else if (playerScore ==5){
				playerGameCount ++;
				enemyScore = 0;
				playerScore = 0;
				serve *= -1;
			}
			else if(enemyScore == 5){
				enemyGameCount ++;
				enemyScore = 0;
				playerScore = 0;
				serve *= -1;
			}
			if(playerGameCount == 2){
				playerSetCount ++;
				playerGameCount = 0;
				enemyGameCount = 0;
			}
			else if(enemyGameCount == 2){
				enemySetCount ++;
				playerGameCount = 0;
				enemyGameCount = 0;
			}
		}
		inGame = false;
		scoreText.text = "Player  :  " + score[playerScore] + "   " + playerGameCount+ "   " + playerSetCount + "\n" +
						 "Enemy :  "   + score[enemyScore]  + "   " + enemyGameCount + "   " + enemySetCount; 
		fadeOut = true;
	}

	private void StartGame(){
		inGame = true;

		Vector3 pStartPosition = new Vector3(2f*servingSide, 0.519f, -12.47f);
		player.transform.position = pStartPosition;
		player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		
		Vector3 eStartPosition = new Vector3(-servingSide*2f, 0.519f, 12.47f);
		enemy.transform.position = eStartPosition;
		enemy.transform.rotation = Quaternion.Euler(0f,0f,0f);

		bC.estaSacando = true;
		if(servingSide == 1){
			ball.transform.position = new Vector3 (serve*2.127f, 1.6f, -serve*12.01f);
		}
		else{
			ball.transform.position = new Vector3 (-serve*1.87f, 1.6f, -serve*12.01f);
		}

		if(serve==1){
			pC.estaSacando = true;
			pHitArea.SetActive (false);
			Vector3 serveTarget = new Vector3(-servingSide * 2.5f, 0f, 3.5f);
			playerTarget.transform.position = serveTarget;
			playerTurn = true;
		}
		else if (serve == -1){		
			eC.isServing = true;
			eHitArea.SetActive (false);
			Vector3 serveTarget = new Vector3(servingSide * 2.5f, 0f, -3.5f);
			enemyTarget.transform.position = serveTarget;
			playerTurn = false;
		}
		servingSide *= -1;
	}

	public void PlayerSideHit(){
		if(playerTurn == false){
			SetScore(-1);
		}
		else{
			AddBounce();
		}
	}
	public void EnemySideHit(){
		if(playerTurn==true){
			SetScore(1);
		}
		else{
			AddBounce();
		}
	}

	public void OutHit(){
		if (bounces >=1){
			AddBounce();
		}
		else{
			if(playerTurn == true){
				SetScore(1);
			}
			else{
				SetScore(-1);
			}
		}
	}
	public void WallHit(){
		if(bounces >=1){
			if(playerTurn == true){
				SetScore(-1);
			}
			else{
				SetScore(1);
			}
		}
	}

	public void BackToMenu ()
	{
		Application.LoadLevel ("PlayTennis");
	}
}
