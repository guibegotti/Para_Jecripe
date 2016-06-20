using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanoePlayerController : MonoBehaviour {
    
    public Slider slider;
    private float sliderSpeed;
    private bool sliderToRight;
    private Rigidbody rb;
    private Animator animator;
    public float acceleration;
    public float maxSpeed;
    public bool start;


	// Use this for initialization
	void Start () {
        start = false;
        sliderToRight = true;
        sliderSpeed = 0.02f;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (start == true)
        {
            MoveSlider();
            Move();
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
                rb.velocity += acceleration * -transform.forward;
                animator.SetTrigger("Paddle");
            }
            else if (((slider.value >= 0.2f && slider.value < 0.4f) || (slider.value > 0.6f && slider.value <= 0.8f)) && (rb.velocity.magnitude < maxSpeed))
            {
                rb.velocity += acceleration / 2 * -transform.forward;
                animator.SetTrigger("Paddle");
            }
            else if (-rb.velocity.z > 0)
            {
                rb.velocity -= acceleration * -transform.forward;
                animator.SetTrigger("Paddle");
            }
        }
    }

    void Stop() {

        if (-rb.velocity.z > 0) rb.velocity -= acceleration / 100 * -transform.forward;
        else
        {
            animator.SetTrigger("Idle");
            rb.velocity = Vector3.zero;
        }
    }
}
