using UnityEngine;
using System.Collections;

public class GroundHit : MonoBehaviour {


	private GameController gController;
	// Use this for initialization
	void Start () {
		gController = GameObject.Find("GameController").GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider c){
		if(c.gameObject.tag == "PlayerSide"){
			gController.PlayerSideHit();
		}
		else if(c.gameObject.tag == "EnemySide"){
			gController.EnemySideHit();
		}
		else if(c.gameObject.tag == "Out"){
			gController.OutHit();
		}
		else if(c.gameObject.tag == "Wall"){
			gController.WallHit();
		}
	}
}
