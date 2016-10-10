using UnityEngine;
using System.Collections;

public class AdversaryController : MonoBehaviour {

    private Rigidbody rb;
    private bool isStarted;
    private Animator animator;
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad >= 2 && Input.GetKeyDown(KeyCode.Space))
        {
            isStarted = true;
            animator.SetTrigger("JumpOp1");
        }

        if (isStarted && transform.position.y < 708f)
            rb.velocity = new Vector3(0f, 0f, Random.Range(2f, 5f));

        else
            rb.velocity = Vector3.zero;
    }
}
