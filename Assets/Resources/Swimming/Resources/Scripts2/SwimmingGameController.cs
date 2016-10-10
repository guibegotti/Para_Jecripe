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

	public GameObject OponentsParticleSystem;
    public bool isMasculine = true;
	public GameObject op1;
	public GameObject op1parent;
	public GameObject op2;
	public GameObject op2parent;
	public GameObject firstPlace;
	public GameObject secondPlace;
	public GameObject thirdPlace;
    public GameObject positionstext; 
	public GameObject settingsCanvas;

	public ParticleSystem pLeft;
	public ParticleSystem pRight;

	GameObject result;

	public bool b1 = false;

	
	public Text place1;
	public Text place2;
	public Text place3;
	
	public SwimmingSounds sounds;

	private StoreDataContainer sD;

	Vector3 rotationVector;





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
		sounds = GameObject.Find ("SwimmingSounds").GetComponent<SwimmingSounds>();
		result = GameObject.Find ("Result");
		canvas1.SetActive(true);
		
		pauseCanvas.SetActive(false);
		gameOverCanvas.SetActive (false);
		
		maxvel = new Vector3 (0.0f, 0.0f, 3);
		movement = new Vector3 (0, 0, 11f);
		armStrokeCount = 0;

        if (isMasculine)
        {
            rotationVector.x = -90;
            rotationVector.y = 180;
        }
        else
        {
            rotationVector.x = 75;
            rotationVector.y = 0;
        }
		rotationVector.z = 0;



		
		points = 0;
		lastSide = "left";
	}
	 
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow) && inWater) {
			ArmStroke ("left", "leftArmStrokeTrigger");
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow) && inWater) {
			ArmStroke ("right", "rightArmStrokeTrigger");
		} else if (Input.GetKeyDown(KeyCode.P)){
			PauseGame();
		}
		
	}
	
	void ArmStroke (string thisSide, string sideTrigger)
	{
        if (player.GetComponent<Rigidbody>().velocity.z < maxvel.z
            && at.time <= 2f
            && (lastSide != thisSide || armStrokeCount == 0)) {

            player.GetComponent<Animator>().SetTrigger(sideTrigger);
            MoveForward();
            at.SetTimer();
            sounds.ArmStrokeSound();
            lastSide = thisSide;
            addPoints(10);
            armStrokeCount++;
			WaterParticleSystem(thisSide);


            //player.GetComponent<Transform>().eulerAngles = (0, 180, 0);
			player.transform.rotation = Quaternion.Euler (rotationVector);
            //player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;


        } else {
			at.ResetTimer ();
		}
		
	}


	void WaterParticleSystem(string side){

		if (side == "left") {
			pLeft.Play ();
		} else {
			pRight.Play ();
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
		sD = StoreDataContainer.Load();
		sD.storeObjects[0].coin += addPoints;
		sD.Save();
		
	}




	
	public void StartGame(){
	

		b1 = true;
		Time.timeScale = 1;
		setOponentsAnimation();
		player.GetComponent<Animator>().SetTrigger("Jump");
		GameObject.Find("Player").GetComponent<Animator>().SetBool ("jumpp",true);
        if (isMasculine)
        {
            GameObject.Find("PlayerParent").GetComponent<Animator>().SetTrigger("Jump");
            sounds.WaitPlay(1f, sounds.dive);
        }
        else
        {
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 250f));
        }
        positionstext.SetActive(true);
		OponentsParticleSystem.SetActive (true);

		
	}
	
	public void GameOver (int place)
	{

		//canvas1.SetActive (false);
		Time.timeScale = 0;
		gameOverCanvas.SetActive (true);
		gameOverTextBox.SetActive(false);
		if (place == 1) {
			gameOverTitle.text = "VOCÊ VENCEU!!!";
			sounds.PlaySound(sounds.applause);
			addPoints (1000);
			
		} else {
			gameOverTitle.text = "FIM DE JOGO";
			if (place == 2) {
				addPoints (700);
			}
		}

		ChangeName ();
		place1.text = firstPlace.name;
		place2.text = secondPlace.name;
		place3.text = thirdPlace.name;
        positionstext.SetActive(false);
		result.GetComponentInChildren<Text> ().text = "Você ganhou " + points.ToString ("0") + " moedas!";


    }

	void ChangeName(){

		if (firstPlace.name == "Player") {
            if (isMasculine)
			    firstPlace.name = "Clodoaldo Silva";
            else
                firstPlace.name = "Edênia Garcia";
        } else if (secondPlace.name == "Player") {
            if (isMasculine)
                secondPlace.name = "Clodoaldo Silva";
            else
                secondPlace.name = "Edênia Garcia";
        } else if (thirdPlace.name == "Player") {
            if (isMasculine)
                thirdPlace.name = "Clodoaldo Silva";
            else
                thirdPlace.name = "Edênia Garcia";
        }


	}
	
	public void GameOver (bool noMoreOxygen)
	{
		result.SetActive (false);
		canvas1.SetActive(false);
		Time.timeScale = 0;
		gameOverCanvas.SetActive (true);
		winnerBoard.SetActive(false);
		gameOverTitle.text = "O OXIGÊNIO ACABOU!";
		gameOverText.text = "Use a tecla ESPAÇO para respirar!\nNade outra vez!";
        positionstext.SetActive(false);

        sD = StoreDataContainer.Load();
		sD.storeObjects[0].coin += points;
		sD.Save();
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
			settingsCanvas.SetActive (false);
		}
	}
	
	public void setOponentsAnimation ()
	{


		int r = Random.Range (0, 1);
		Debug.Log (r);

		setJumpTrigger (op1);
		setJumpTrigger (op2);

        if (isMasculine)
        {

            setJumpTrigger(op1parent);
            setJumpTrigger(op2parent);

            if (r == 1)
            {
                op1parent.GetComponent<Animator>().SetInteger("Rand", 1);
                op2parent.GetComponent<Animator>().SetInteger("Rand", 0);
            }
            else
            {
                op2parent.GetComponent<Animator>().SetInteger("Rand", 0);
                op1parent.GetComponent<Animator>().SetInteger("Rand", 1);
            }

        }
		
	}
	
	void setJumpTrigger(GameObject go){
		go.GetComponent<Animator>().SetTrigger("JumpOp1");
	}
	
	
	
	
	
}
