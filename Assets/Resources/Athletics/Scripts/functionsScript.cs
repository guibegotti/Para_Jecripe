using UnityEngine;
using System.Collections;

public class functionsScript : MonoBehaviour {

	
	public static void Animation (Rigidbody r, Animator a){
		if (playerBehaviour2.começa) {
			if (r.velocity != new Vector3 (0, 0, 0)) {
				a.SetBool ("inIdle", false);
				a.SetBool ("inRun", true);
				a.SetBool ("inStart", false);
			} else {
				a.SetBool ("inIdle", true);
				a.SetBool ("inRun", false);
				a.SetBool ("inStart", false);
			}
		} else {
			a.SetBool ("inIdle", false);
			a.SetBool ("inRun", false);
			a.SetBool ("inStart", true);
		}
	}

	public static void Animation (Rigidbody r, Animator a, bool b){
		if (b) {
			if (r.velocity != new Vector3 (0, 0, 0)) {
				a.SetBool ("inIdle", false);
				a.SetBool ("inRun", true);
				a.SetBool ("inStart", false);
			} else {
				a.SetBool ("inIdle", true);
				a.SetBool ("inRun", false);
				a.SetBool ("inStart", false);
			}
		} else {
			a.SetBool ("inIdle", false);
			a.SetBool ("inRun", false);
			a.SetBool ("inStart", true);
		}
	}

	public static void stopMove(Rigidbody r){

		if (r.velocity.x >= -2)
			r.velocity = Vector3.zero;


	}

	public static void Animation (Rigidbody r, Animator a, AudioSource audio){
		if (playerBehaviour2.começa) {
			if (r.velocity != new Vector3 (0, 0, 0)) {
				a.SetBool ("inIdle", false);
				a.SetBool ("inRun", true);
				a.SetBool ("inStart", false);
			//	audio.Play ();
			//	audio.volume = 1;
			} else {
			//	audio.volume = 0;
				a.SetBool ("inIdle", true);
				a.SetBool ("inRun", false);
				a.SetBool ("inStart", false);
			}
		} else {
			a.SetBool ("inIdle", false);
			a.SetBool ("inRun", false);
			a.SetBool ("inStart", true);
		}
	}

	public static void Rotation (Transform referencia, GameObject obj)
	{
		float dx = obj.transform.position.x - referencia.position.x;
		float dy = obj.transform.position.z - referencia.position.z;
		float angle = Mathf.Atan2 (dx, dy) * Mathf.Rad2Deg;
		Quaternion rot = Quaternion.Euler (new Vector3 (0, angle + 90, 0));
		obj.transform.rotation = rot;
	}	
	
	public static void endOfCourse(GameObject obj, Rigidbody rig, bool b){
		
		if (obj.transform.position.x < -46 && obj.transform.position.z > 50) {
			
			b = true;
			rig.drag = 1.5f;
			
		}
		
	}
	
	
}

public class opponent{
	
	public int id;
	public string name, country;
	public float velocityright, velocitytoward, coursetime, waitingTime;

	
	
	public void setWaitingTime(){

		this.waitingTime = Random.Range (1, 4);

	}

	public void featuresAdversary(int n){
		
		switch (n) {
			
		case 1:
			id = 1;
			name = "Amanda e \nAlan";
			country = "Brasil";
			break;
		case 2:
			id = 2;
			name = "Kate e \nJohnson";
			country = "USA";
			break;
		case 3:
			id = 3;
			name = "Mila e \nZangief";
			country = "Rússia";
			break;
		case 4:
			id = 4;
			name = "Maria e \nJoão";
			country = "Portugal";
			break;
		case 5:
			id = 5;
			name = "Jiang e \nLee";
			country = "China";
			break;
		case 6:
			id = 6;
			name = "Isabel e \nJuan";
			country = "Argentina";
			break;
		case 7:
			id = 7;
			name = "Chun-Li e \nRyu";
			country = "Japão";
			break;
		case 8:
			id = 8;
			name = "Kiara e \nEssien";
			country = "África do Sul";
			break;
			
			
			
		}
		
		
	}
	
	
	public void set(int n){
		
		switch (n) {
			
		case 1:				
			velocitytoward = 9;
			velocityright = 0.05f;				
			break;
			
		case 2:
			id = 2;
			velocitytoward = 10;
			velocityright = 0.08f;	
			break;
			
		case 3:
			velocitytoward = 11;
			velocityright = 0.13f;	
			break;
			
		default:
			break;
			
		}
		
	}
	
}