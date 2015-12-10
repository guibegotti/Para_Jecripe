using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwimmingGameController : MonoBehaviour
{

	GameObject player;
	Timer at;
	Vector3 maxvel;
	Vector3 movement;
	
	string lastSide;
	
	Text pointText;
	int points;
	public bool inWater;
	
	int armStrokeCount;
	
	FallingCoin fc;
	
	GameObject canvas1;
	GameObject pauseCanvas;
	
	
	GameObject gameOverCanvas;
	Text gameOverTitle;
	Text gameOverText;
	
	GameObject gameOverTextBox;
	GameObject winnerBoard;
	
	public GameObject op1;
	public GameObject op1parent;
	public GameObject op2;
	public GameObject op2parent;
	public GameObject firstPlace;
	public GameObject secondPlace;
	public GameObject thirdPlace;
	
	public Text place1;
	public Text place2;
	public Text place3;
	
	void Start ()
	{
		
		player = GameObject.Find ("Player");
		at = GameObject.Find ("ArmstrokeTimer").GetComponent<Timer> ();
		pointText = GameObject.Find ("PointsText").GetComponent<Text> ();
		gameOverCanvas = GameObject.Find ("GameOver");
		gameOverTitle = GameObject.Find ("GameOverTitle").GetComponent<Text> ();
		gameOverText = GameObject.Find ("TextBoxText").GetComponent<Text> ();
		gameOverTextBox = GameObject.Find ("TextBox");
		winnerBoard = GameObject.Find ("WinnerBoard"); 
		fc = GameObject.Find ("FallingCoin").GetComponent<FallingCoin> ();
		canvas1 = GameObject.Find ("Canvas1");
		pauseCanvas = GameObject.Find ("PauseCanvas");
		canvas1.SetActive(true);
		
		pauseCanvas.SetActive(false);
		gameOverCanvas.SetActive (false);
		
		maxvel = new Vector3 (0.0f, 0.0f, 3);
		movement = new Vector3 (0, 0, 11f);
		armStrokeCount = 0;
		
		
		points = 0;
		lastSide = "left";
	}
	 
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			ArmStroke ("left", "leftArmStrokeTrigger");
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			ArmStroke ("right", "rightArmStrokeTrigger");
		} else if (Input.GetKeyDown(KeyCode.P)){
			PauseGame();
		}
		
	}
	
	void ArmStroke (string thisSide, string sideTrigger)
	{
		if (player.GetComponent<Rigidbody> ().velocity.z < maxvel.z 
			&& at.time <= 2f
		    && (lastSide != thisSide || armStrokeCount == 0)) {
				
			player.GetComponent<Animator> ().SetTrigger (sideTrigger);
			MoveForward ();
			at.SetTimer ();
			lastSide = thisSide;
			addPoints (10);
			armStrokeCount++;
			
		} else {
			at.ResetTimer ();
		}
		
	}
	
	void MoveForward ()
	{
		player.GetComponent<Rigidbody> ().AddForce (movement * 13);
		Debug.Log (player.GetComponent<Rigidbody> ().velocity);
	}
	
	void addPoints (int addPoints)
	{
		points += addPoints;
		pointText.text = points.ToString ();
		fc.coinFallAnimation ();
		
	}
	
	public void StartGame(){
	
		Time.timeScale = 1;
		setOponentsAnimation();
		player.GetComponent<Animator>().SetTrigger("Jump");
		GameObject.Find("PlayerParent").GetComponent<Animator>().SetTrigger("Jump");
		inWater = true;
		
		
	}
	
	public void GameOver (int place)
	{
		Time.timeScale = 0;
		gameOverCanvas.SetActive (true);
		gameOverTextBox.SetActive(false);
		if (place == 1) {
			gameOverTitle.text = "VOCÊ VENCEU!!!";
			
		} else {
			gameOverTitle.text = "FIM DE JOGO";
		}
		
		place1.text = firstPlace.name;
		place2.text = secondPlace.name;
		place3.text = thirdPlace.name;
		
	}
	
	public void GameOver (bool noMoreOxygen)
	{
		canvas1.SetActive(false);
		Time.timeScale = 0;
		gameOverCanvas.SetActive (true);
		winnerBoard.SetActive(false);
		gameOverTitle.text = "O OXIGÊNIO ACABOU!";
		gameOverText.text = "Use a tecla ESPAÇO para respirar!\nNade outra vez!";	
	}
	
	public void PauseGame(){
		
		if(Time.timeScale == 1){
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			canvas1.SetActive(false);
		} else if(Time.timeScale == 0){
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			canvas1.SetActive(true);
		}
	}
	
	public void setOponentsAnimation ()
	{
		setJumpTrigger (op1);
		setJumpTrigger (op1parent);
		setJumpTrigger (op2);
		setJumpTrigger (op2parent);
		
	}
	
	void setJumpTrigger(GameObject go){
		go.GetComponent<Animator>().SetTrigger("JumpOp1");
	}
	
	
	
	
	
}
