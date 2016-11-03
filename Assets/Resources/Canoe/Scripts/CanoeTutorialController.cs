using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanoeTutorialController : MonoBehaviour {

    public GameObject b1, b2, b3;
    public GameObject canvas, pauseCanvas, settingCanvas;
    public Text b1Text, b2Text, b3Text;
    private bool started, finished;
    private float timer;
    public AudioSource paddleSound;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        started = false;
        finished = false;
        paddleSound = paddleSound.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !started)
        {
            started = true;
            b1.SetActive(false);
            b2.SetActive(true);
            timer = Time.time;
        }
        if(Time.time > timer + 3f){
            b2.SetActive(false);
            b3.SetActive(true);
        }
        if(Time.time > timer + 14.5f)
        {
            b3.SetActive(false);
            b2Text.text = "As bóias vermelhas indicam o a reta final. Falta pouco!";
            b2.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && finished)
        {
            Application.LoadLevel("CanoeGame");
        }
    }

    void OnTriggerEnter(Collider c)
    {
        finished = true;
        timer = Mathf.Infinity;
        b2.SetActive(false);
        b1Text.text = "Parabéns, você completou o tutorial!. Pressione ESPAÇO para jogar uma partida.";
        b1.SetActive(true);
    }

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
}
