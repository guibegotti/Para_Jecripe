using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class veronica_Behaviour : MonoBehaviour {
   
    private bool start, canContinue;
    private bool canRun;
    private bool canJump;
    private bool isJumping;
    private bool betweenJumps;
    private bool pressLeft;
    private bool jumpFailed;
    private Animator animator;
    private Rigidbody rb;
    public float acceleration, maxSpeed;
    private float timer;
    public GameObject rightFoot, leftFoot;
    private float jumpDistance;
    public Transform invalid_jump, jump_reference;
    private int jumpNumber;
    private int points;
    public Text pointsText;
    public GameObject jumpMessage;
    public GameObject betweenJumpsWindow;
    public Text betweenJumpsText;
    public GameObject jumpFailedMessage;
    public GameObject resultCanvas;

    private StoreDataContainer sD;

    // Use this for initialization
    void Start ()
    {
        pointsText.text = "0";
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        jumpMessage.SetActive(false);
        resultCanvas.SetActive(false);
        betweenJumpsWindow.SetActive(false);
        jumpFailedMessage.SetActive(false);
        jumpNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRun == true)
        {
            Run();
        }
        if (jump_reference.position.x >= transform.position.x && transform.position.x >= invalid_jump.position.x && jumpFailed == true)
        {
            jumpMessage.SetActive(true);
            canJump = true;
        }
        if (canJump == true)
        {
            Jump();
        }
        if (isJumping == true) {
            CalculateJumpDistance();
        }
        if (transform.position.x < invalid_jump.position.x && jumpFailed == true)
        {
            JumpFailed();
        }
        if (betweenJumps == true)
        {
            BetweenJumps();
        }
    }

    private void Run()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) && pressLeft == true)
        {
            leftFoot.SetActive(false);
            rightFoot.SetActive(true);
            pressLeft = false;
            if (-rb.velocity.x <= maxSpeed)
            {
                rb.velocity += acceleration * -transform.forward;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && pressLeft == false)
        {
            rightFoot.SetActive(false);
            leftFoot.SetActive(true);
            pressLeft = true;
            if(-rb.velocity.x <= maxSpeed)
            {
                rb.velocity += acceleration * -transform.forward;
            }
        }
        else if (rb.velocity.x > 0 && ((Input.GetKeyDown(KeyCode.LeftArrow) && pressLeft == false) || (Input.GetKeyDown(KeyCode.RightArrow) && pressLeft == true)))
        {
            rb.velocity -= (acceleration / 3) * -transform.forward;
        }
        if (rb.velocity.x > 0)
        {
            rb.velocity -= (acceleration ) * -transform.forward;
        }
        animator.SetFloat("speed", -rb.velocity.x);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpMessage.SetActive(false);
            rightFoot.SetActive(false);
            leftFoot.SetActive(false);
            rb.AddForce(Vector3.up * 250f);
            animator.SetBool("jump", true);
            isJumping = true;
            canRun = false;
            canJump = false;
            jumpFailed = false;
            timer = Time.time;
        }
    }

    private void CalculateJumpDistance()
    {
        if (transform.position.y < 3.72)
        {
            jumpDistance = (((transform.position.x + 45f) / -19f) * 1.4f) + 3.5f;
            isJumping = false;
            betweenJumps = true;
        }
    }

    private void JumpFailed()
    {
        jumpMessage.SetActive(false);
        canRun = false;
        canJump = false;
        jumpFailed = true;
        if (rb.velocity.x > 0)
        {
            rb.velocity -= (acceleration) * -transform.forward;
        }
        if (-rb.velocity.x < 15)
        {
            betweenJumps = true;
        }
        animator.SetFloat("speed", -rb.velocity.x);
    }

    private void BetweenJumps()
    {
        if (Time.time > timer + 2f)
        {
            if(jumpFailed == false)
            {
                betweenJumpsWindow.SetActive(true);
            }
            else
            {
                jumpFailedMessage.SetActive(true);
            }
        }
        if (canContinue == true)
        {
            betweenJumps = false;
            if (jumpFailed == false)
            {
                AddPoints(200);
            }
            animator.SetTrigger("idle");
            betweenJumpsWindow.SetActive(false);
            jumpFailedMessage.SetActive(false);
            if (jumpNumber < 3)
            {
                NewJump();
            }
            else
            {
                resultCanvas.SetActive(true);
            }
        }
    }

    private void AddPoints(int n)
    {
        points += n;
        pointsText.text = "" + points;
        sD = StoreDataContainer.Load();
        sD.storeObjects[0].coin += n;
        sD.Save();
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
       
    public void ContinueButton()
    {
        canContinue = true;
    }

    public void NewJump()
    {
        jumpNumber++;
        rb.velocity = new Vector3(0f,0f,0f);
        pressLeft = true;
        rightFoot.SetActive(false);
        leftFoot.SetActive(true);
        canContinue = false;
        betweenJumps = false;
        canRun = true;
        canJump = false;
        isJumping = false;
        jumpFailed = true;
        animator.SetBool("jump", false);
        animator.SetFloat("speed", 0.0f);
        transform.position = new Vector3(60.95f, 3.7256f, 152.71f);
    }
    
}