using UnityEngine;
using System.Collections;

public class Rebater : MonoBehaviour {
	
	private AudioSource aud;
	private Collider c;
	
	public GameObject alvo;
	
	private float tempoAlvo;
	
	private GameObject forehand_lado;
	private GameObject forehand_frente;
	private GameObject backhand_lado;
	private GameObject backhand_frente;
	
	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
		c = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (c.enabled == true) {
			float moverAlvoHorizontal = Input.GetAxis ("Horizontal");
			float moverAlvoVertical = Input.GetAxis ("Vertical");
			if(alvo.transform.position.x>=-4 && alvo.transform.position.x<=4){
				alvo.transform.Translate (moverAlvoHorizontal / 4, 0f, 0f, Space.World);
			}
			if(alvo.transform.position.z>=2.5 && alvo.transform.position.z<=11.8){
				alvo.transform.Translate (0f, 0f, moverAlvoVertical / 4, Space.World);
			}
		} 
		else {
			alvo.transform.position = new Vector3(0f, alvo.transform.position.y, 6.5f);
		}
	}
	
	
	void OnTriggerEnter (Collider c){
		if (c.gameObject.tag == "Bola") {
			tempoAlvo = (alvo.transform.position.z - transform.position.z)/14f;
			c.attachedRigidbody.velocity = Velocidade(tempoAlvo);
			aud.Play();
		}
	}
	
	
	Vector3 Velocidade(float tempoAteAlvo) {
		Vector3 distancia = alvo.transform.position - transform.position;
		Vector3 direcao = distancia;
		direcao.y = 0;
		
		float y = distancia.y;
		float xz = direcao.magnitude;
		
		float t = tempoAteAlvo;
		float v0y = y / t + 0.5f * Physics.gravity.magnitude * t;
		float v0xz = xz / t;
		
		Vector3 result = direcao.normalized;        
		result *= v0xz;                                
		result.y = v0y;                                
		
		return result;
	}
}
