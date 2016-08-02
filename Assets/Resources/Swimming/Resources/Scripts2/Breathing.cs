using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Breathing : MonoBehaviour
{
	
	public Slider healthBarSlider;
	public bool rechargeOxygen;
	CountDown countDown;
	SwimmingGameController SC;
	SwimmingSounds sounds;
	public GameObject breatheWarning;
	
	void Start ()
	{
		
		sounds = GameObject.Find ("SwimmingSounds").GetComponent<SwimmingSounds> ();
		SC = GameObject.Find ("SwimmingController").GetComponent<SwimmingGameController>();
		breatheWarning = GameObject.Find ("RememberToBreathe");
		breatheWarning.SetActive (false);

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
		if (healthBarSlider.value < 0.15f)
			breatheWarning.SetActive (true);

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
			sounds.PlaySound(SwimmingSounds.breathing);
			breatheWarning.SetActive (false);
		
		} 
	}

	
	
}
