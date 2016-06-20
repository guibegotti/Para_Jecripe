using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanoeGameController : MonoBehaviour {

    public GameObject canvas;
    public GameObject startCanvas;
    public GameObject gameOverCanvas;
    private string[] score;
    public Text pos1, pos2, pos3;
    private int scoreInd;
    private bool start;

	// Use this for initialization
	void Start () {
        start = false;
        canvas.SetActive(false);
        startCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
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
}
