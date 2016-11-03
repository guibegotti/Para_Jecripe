using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanoeGameController : MonoBehaviour {

    public GameObject canvas;
    public GameObject startCanvas;
    public GameObject gameOverCanvas;
    public GameObject pauseCanvas;
    public GameObject settingCanvas;
    public Text timeText;
    private float time;
    private string[] score;
    public Text pos1, pos2, pos3;
    private int scoreInd;
    private bool start;
    public GameObject player, adv1, adv2;
    public Text position;

    private static int coins;
    public Text coinsText;
    private StoreDataContainer sD;

    public AudioSource paddleSound;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        coins = 0;
        start = false;
        canvas.SetActive(false);
        startCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        score = new string[3];
        scoreInd = 0;
        paddleSound = paddleSound.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(start == false && Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
            startCanvas.SetActive(false);
            canvas.SetActive(true);
        }
        else if(start == true)
        {
            time += Time.deltaTime;
            string timeStr = ((int)time / 60).ToString("00") + ":" + ((int)time % 60).ToString("00") + ":" + (int)((time-(int)time)*100);
            timeText.text = timeStr;
            CalculatePosition();
            coinsText.text = "" + coins;
        }
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            CanoePlayerController cpc = c.gameObject.GetComponent<CanoePlayerController>();
            cpc.start = false;
            score[scoreInd] = "Jogador";
            if (scoreInd == 0)
                coins += 1000;
            else if (scoreInd == 1)
                coins += 700;
            else
                coins += 500;
            GameOver();
        }
        else
        {
            CanoeAdversaryController cac = c.gameObject.GetComponent<CanoeAdversaryController>();
            cac.start = false;
            score[scoreInd] = cac.getName();
        }
        scoreInd++;
    }

    void CalculatePosition()
    {
        if (player.transform.position.z <= adv1.transform.position.z && player.transform.position.z <= adv2.transform.position.z)
            position.text = "1";
        else if (player.transform.position.z > adv1.transform.position.z && player.transform.position.z > adv2.transform.position.z)
            position.text = "3";
        else
            position.text = "2";
    }

    void GameOver()
    {
        canvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        if (score[1] == null)
        {
            score[1] = "Tim Harland";
            score[2] = "Pablo Reyes";
        }
        else if (score[2] == null)
        {
            if (score[1].Equals("Tim Harland") || score[0].Equals("Tim Harland"))
                score[2] = "Pablo Reyes";
            else
                score[2] = "Tim Harland";
        }
        pos1.text = score[0];
        pos2.text = score[1];
        pos3.text = score[2];

        sD = StoreDataContainer.Load();
        sD.storeObjects[0].coin += coins;
        sD.Save();
    }

    /// <summary>
	/// Pauses the game.
	/// </summary>
	public void PauseGame()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            canvas.SetActive(false);
            paddleSound.Pause();
            CanoePlayerController.isPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
            canvas.SetActive(true);
            paddleSound.UnPause();
            CanoePlayerController.isPaused = false;
            settingCanvas.SetActive(false);
        }

    }
    
    public static void AddCoins(int c)
    {
        coins += c;
    }

}
