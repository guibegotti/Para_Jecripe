using UnityEngine;
using System.Collections;

public class Rebater : MonoBehaviour
{
	
	private AudioSource aud;
	public GameObject alvo;
	private float tempoAlvo;
	private GameObject forehand_lado;
	private GameObject forehand_frente;
	private GameObject backhand_lado;
	private GameObject backhand_frente;
	TennisController TC;
	private Animator a;
	public bool isPlayer;
	
	// Use this for initialization
	void Start ()
	{
		aud = GetComponent<AudioSource> ();
		a = GetComponentInParent<Animator> ();
		TC = GameObject.Find ("TennisController").GetComponent<TennisController> ();
	}
	
	void OnTriggerEnter (Collider c)
	{
		if (c.gameObject.tag == "Ball") {
			tempoAlvo = (alvo.transform.position.z - transform.position.z) / 13.5f;
			int i = 1;
			if (isPlayer == false) {
				i = -1;
			}
			c.attachedRigidbody.velocity = i * Velocidade (tempoAlvo);
			aud.Play ();
			TC.addPoints(20);
			if (transform.eulerAngles.y >= 135 && transform.eulerAngles.y < 190) {
				a.SetTrigger ("Backhand_frente");
			} else if (transform.eulerAngles.y >= 190 && transform.eulerAngles.y <= 225) {
				a.SetTrigger ("Forehand_frente");
			} else if (transform.eulerAngles.y < 135 && transform.eulerAngles.y > 0) {
				a.SetTrigger ("Backhand_lado");
			} else if (transform.eulerAngles.y > 225 && transform.eulerAngles.y <= 360) {
				a.SetTrigger ("Forehand_lado");
			}
		}
	}
	
	Vector3 Velocidade (float tempoAteAlvo)
	{
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
