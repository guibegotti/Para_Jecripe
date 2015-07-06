using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	float Timer;
	bool setTimer;
	public float yInicial;
	public float yLogo;
	float xLogo;

	void Start () {
		setTimer = true;
	
	}
	
	void Update () {
		if (setTimer) {
			Timer += Time.deltaTime;
			if (Timer >= 0.8) {
				yLogo = yInicial - Timer * 2;
				transform.position = new Vector3 (transform.position.x, yLogo, transform.position.z);
				if (yLogo <= 1.2f) {
					GetComponent<Jogar> ().jogar = true;
					xLogo = transform.position.x;
					setTimer = false;
				}
			}
		} else if (GetComponent<Left> ().clicou) {
			xLogo -= 0.5f;
			transform.position = new Vector3 (xLogo, transform.position.y, transform.position.z);
		}
	}
}
