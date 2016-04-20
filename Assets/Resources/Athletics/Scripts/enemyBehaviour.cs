using UnityEngine;
using System.Collections;

public class enemyBehaviour : MonoBehaviour {
	
	private Rigidbody rig;
	public float velocity = 9;
	public bool fim;
	public int id;
	public bool termina;
	public float timeChangeVelocity, timeToStart;
	private Animator animator;
	public Transform referencia, referencia2;
	public opponent adversary = new opponent();
	
	

	
	void Movimenta(){
		
		
		GetComponentInChildren<Animator>().SetBool("inRun",true);
		GetComponentInChildren<Animator>().SetBool("inStart",false);
		rig.velocity = -transform.forward * velocity;
		if (timeChangeVelocity > 0.5f) {
			velocity = Random.Range (0, 10) * 0.1f + 8.5f;
			timeChangeVelocity = 0;
		} else {
			timeChangeVelocity += Time.deltaTime;
		}
		
	}
	
	
	void MovimentaCurva(){
		
		rig.velocity = -transform.forward * adversary.velocitytoward  + transform.right * adversary.velocityright;
		
	}
	
	
	
	void Start () {
		
		
		referencia = GameObject.Find ("Referencia").GetComponent<Transform> ();
		referencia2 = GameObject.Find ("Referencia2").GetComponent<Transform> ();
		termina = false;
		fim = false;
		rig = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		adversary.set (id);
		adversary.featuresAdversary (Random.Range (1,9));
		adversary.setWaitingTime ();
		timeToStart = 0;

		
	}
	
	void ControlaPosiçoes(){
		
		if (transform.position.x < referencia2.position.x) {
			functionsScript.Rotation  (referencia2, this.gameObject );
			MovimentaCurva ();			
		} else {
			
			if(transform.position.x < referencia.position.x){
				
				Movimenta ();
				if (transform.position.z <= 50f) {
					transform.rotation = Quaternion.Euler (new Vector3 (0, 270, 0));
					rig.velocity = new Vector3(rig.velocity.x,0,0);
					fim = true;
					
					
				} else {
					
					transform.rotation = Quaternion.Euler (new Vector3 (0, 90, 0));
					rig.velocity = new Vector3(rig.velocity.x,0,0);
					
				}
			}
			else{
				functionsScript.Rotation (referencia,this.gameObject );
				MovimentaCurva ();
				
			}
		}
	}
	
	void Update () {

	
		functionsScript.Animation (rig, animator);	
		if (fim) {
			if (this.transform.position.x < -46 && this.transform.position.z > 50) {
				
				termina = true;
				functionsScript.stopMove (rig);
				rig.drag = 1;
				GetComponentInChildren<Animator>().SetBool("inRun",false);

				
			}
			
		}
		
		if (playerBehaviour2.começa && !termina) {	
			
			adversary.coursetime += Time.deltaTime;
			if(timeToStart < 1){
				timeToStart += Time.deltaTime;
			}
			if((adversary.waitingTime/10) <= timeToStart){
				ControlaPosiçoes ();
			}
			
		}
		
	}
}