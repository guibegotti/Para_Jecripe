using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanoePlayerController : MonoBehaviour {
    
    public Slider slider;
    public Slider distanceLeft;
    private float sliderSpeed;
    private bool sliderToRight;
    private Rigidbody rb;
    private Animator animator;
    public float acceleration;
    public float maxSpeed;
    public bool start;
    public GameObject paddleSound;
    public bool isGame = true;
    private CanoeGameController cgc;
    public static bool isPaused;

	// Use this for initialization
	void Start () {
        paddleSound.SetActive(false);
        if(isGame)
            distanceLeft.value = 0;
        start = false;
        sliderToRight = true;
        sliderSpeed = 0.02f;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (start == true)
        {
            if(!isPaused)
                MoveSlider();
            Move();
            if(isGame)
                distanceLeft.value = -transform.position.z / 191.2f;
        }
        else
        {            
            if (Input.GetKeyDown(KeyCode.Space) && rb.velocity == Vector3.zero) start = true;
        }
        Stop();
    }

    void MoveSlider()
    {
        if (sliderToRight == true) slider.value += sliderSpeed;
        else slider.value -= sliderSpeed;
        if (slider.value == 1) sliderToRight = false;
        else if (slider.value == 0) sliderToRight = true;
    }

    void Move()
    {
        if (start == true && Input.GetKeyDown(KeyCode.Space))
        {
            if ((slider.value >= 0.4f && slider.value <= 0.6f) && (rb.velocity.magnitude < maxSpeed))
            {
                if(isGame)
                    CanoeGameController.AddCoins(100);
                rb.velocity += acceleration * -transform.forward;
                paddleSound.SetActive(true);
                animator.SetTrigger("Paddle");
            }
            else if (((slider.value >= 0.2f && slider.value < 0.4f) || (slider.value > 0.6f && slider.value <= 0.8f)) && (rb.velocity.magnitude < maxSpeed))
            {
                if(isGame)
                    CanoeGameController.AddCoins(50);
                rb.velocity += acceleration / 2 * -transform.forward;
                paddleSound.SetActive(true);
                animator.SetTrigger("Paddle");
            }
            else if (-rb.velocity.z > 0)
            {
                rb.velocity -= acceleration * -transform.forward;
                paddleSound.SetActive(true);
                animator.SetTrigger("Paddle");
            }
        }
    }

    void Stop() {

        if (-rb.velocity.z > 0.01f) rb.velocity -= acceleration / 100 * -transform.forward;
        else
        {
            if (rb.velocity.z == 0f)
            {
                paddleSound.SetActive(false);
                animator.SetTrigger("Idle");
            }
            rb.velocity = Vector3.zero;
        }
    }
}
