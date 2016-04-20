using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwimmingTutorial_Oxygen : MonoBehaviour {


	
	public Slider healthBarSlider;
	public bool rechargeOxygen;
	CountDown countDown;
	public bool oxGoDownOK;
	
	
	
	void Update () {
		
		if(oxGoDownOK){
			if(rechargeOxygen){
				Recharge0xygen();
			} else {
				DecreaseOxygen();
			}
		}
	}
	
	
	void DecreaseOxygen ()
	{
		healthBarSlider.value -= Time.deltaTime * 0.08f;
	}
	
	void Recharge0xygen ()
	{
		
		rechargeOxygen = true;
		if (healthBarSlider.value < 1) {
			healthBarSlider.value += Time.deltaTime * 0.8f;
		} else {
			rechargeOxygen = false;
			oxGoDownOK = false;
		}
		
	}
	
	void CheckOLevel ()
	{
		if (healthBarSlider.value <= 0.4f) {
			Recharge0xygen ();
		}
	}
}
