using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public bool naoAnimado;
	GameObject player;
	private Vector3 offset;
	PlayerControl playerController;
	Timer camTimer;
	
	void Start ()
	{
		camTimer = GetComponent<Timer>();
		player = GameObject.Find ("Player");
		offset = transform.position - player.transform.position;
		naoAnimado = true;
		playerController = player.GetComponent<PlayerControl> ();
		camTimer.SetTimer();
	}
	
	void Update ()
	{
		if (playerController.voltando && naoAnimado) {
			offset = new Vector3 (0, 3.2f, 3f);
		}
		
		if(camTimer.time <= 2.20f){
			naoAnimado = false;
		} else {
			camTimer.timer = false;
			naoAnimado = true;
		}
	}
	
	void LateUpdate ()
	{	
		if (naoAnimado) {
			transform.position = player.transform.position + offset;
		}

	}
	
}
