using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	public Vector3 offset;
	public GameObject player;
	public bool followPlayer;
	
	void Start ()
	{
		
		offset = new Vector3 (0, 7.8f, -5f);
	}
	
	
	
	void LateUpdate ()
	{
		if(followPlayer){
			transform.position = player.transform.position + offset;
		}
		
	}
	
}
