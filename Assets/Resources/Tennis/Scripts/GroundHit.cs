using UnityEngine;
using System.Collections;

public class GroundHit : MonoBehaviour {


	private GameController gController;
	private TennisTutorialController tController;
	public bool isTutorial = false;
	// Use this for initialization
	void Start () {
		if(isTutorial == false){
			gController = GameObject.Find("GameController").GetComponent<GameController>();
		}
		else {
			tController = GameObject.Find("TennisTutorialController").GetComponent<TennisTutorialController>();
			if(transform.parent.name.Contains("(Clone)")){
				Destroy (gameObject, 7);
			}
		}
	}

	void OnTriggerEnter(Collider c){
		if(isTutorial == false){
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
		else{
			if(c.gameObject.tag == "Right"){
				tController.HitRight();
			}
			else if(c.gameObject.tag == "Left"){
				tController.HitLeft();
			}
		}
	}
}
