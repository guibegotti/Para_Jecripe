using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public bool naoAnimado;
	GameObject player;
	public Vector3 offset;
	PlayerControl playerController;
	Timer camTimer;
	
	void Start ()
	{
		camTimer = GetComponent<Timer>();
		player = GameObject.Find ("root");
		//offset = transform.position - player.transform.position;
		offset = new Vector3 (0, 7.8f, -5f);
		naoAnimado = true;
		camTimer.SetTimer();
	}
	
	void Update ()
	{
		/*if (playerController.voltando && naoAnimado) {
			offset = new Vector3 (0, 3.2f, 3f);
		}*/
		
		if(camTimer.time <= 3f){
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
