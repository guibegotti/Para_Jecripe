using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Breathing : MonoBehaviour
{
	
	public Slider healthBarSlider;
	public bool rechargeOxygen;
	CountDown countDown;
	SwimmingGameController SC;
	SwimmingSounds Sounds;
	
	void Start ()
	{
		//b = GameObject.Find ("ArmStrokes").GetComponent<ArmStrokes> ();
		Sounds = GameObject.Find ("Sounds").GetComponent<SwimmingSounds> ();
		SC = GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController>();
		
	}
	
	void Update ()
	{
		if (SC.inWater) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				CheckOLevel ();
			}
			if (rechargeOxygen) {
				Recharge0xygen ();
			} else {
				DecreaseOxygen ();
			}
		}

		
	}
	
	void DecreaseOxygen ()
	{
		healthBarSlider.value -= Time.deltaTime * 0.08f;
		if (healthBarSlider.value == 0) {
			SC.GameOver(true);
		}
	}
	
	void Recharge0xygen ()
	{
	
		rechargeOxygen = true;
		if (healthBarSlider.value < 1) {
			healthBarSlider.value += Time.deltaTime * 0.8f;
		} else {
			rechargeOxygen = false;
		}
		
	}
	
	void CheckOLevel ()
	{
		if (healthBarSlider.value <= 0.4f) {
			Recharge0xygen ();
		} else {
			
		}
	}

	
	
}
