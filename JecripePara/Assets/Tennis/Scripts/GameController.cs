using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public GameObject bolaPrefab;
	private Rigidbody r;

	private GameObject bola;

	private PlayerController pC;
	private BallController bC;

	void Start () {
		pC = player1.GetComponent<PlayerController> ();
		
		pC.estaSacando = true;

		Instantiate (player1, new Vector3 (2f, 0.519f, -12.5f), Quaternion.Euler (0f, 180f, 0f));
		Instantiate (player2, new Vector3 (-2f, 0.519f, 12.5f), Quaternion.Euler (0f, 180f, 0f));

	 	bola = GameObject.Instantiate(bolaPrefab, new Vector3(2.127f, 1.699f, -12.01f), Quaternion.Euler(0f, 0f, 0f)) as GameObject;	
		bC = bola.GetComponent<BallController> ();
		bC.estaSacando = true;

	}
	
	// Update is called once per frame
	void Update () {
	}
}
