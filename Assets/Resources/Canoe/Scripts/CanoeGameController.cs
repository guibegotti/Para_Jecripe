using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanoeGameController : MonoBehaviour {

    public GameObject canvas;
    public GameObject startCanvas;
    public GameObject gameOverCanvas;
    public GameObject pauseCanvas;
    public Text timeText;
    private float time;
    private string[] score;
    public Text pos1, pos2, pos3;
    private int scoreInd;
    private bool start;

	// Use this for initialization
	void Start () {
        //Time.timeScale = 1;
        start = false;
        canvas.SetActive(false);
        startCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        score = new string[3];
        scoreInd = 0;
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
            timeText.text = ""+time.ToString("F2");
        }
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
            CanoePlayerController cpc = c.gameObject.GetComponent<CanoePlayerController>();
            cpc.start = false;
            score[scoreInd] = "ATLETA ANONIMO";
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

    void GameOver()
    {
        canvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        pos1.text = score[0];
        pos2.text = score[1];
        pos3.text = score[2];
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
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseCanvas.SetActive(false);
            canvas.SetActive(true);
        }

    }
}
