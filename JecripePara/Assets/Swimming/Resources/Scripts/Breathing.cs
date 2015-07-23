using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Breathing : MonoBehaviour {
	
	public Slider healthBarSlider;
	ArmStrokes b;
	PlayerControl p;
	public bool rechargeOxygen;
	CountDown countDown;
	Buttons buttons;
	SwimmingController SC;
	
	
	void Start(){
		b = GameObject.Find ("ArmStrokes").GetComponent<ArmStrokes>();
		countDown = GameObject.Find ("Countdown").GetComponent<CountDown>();
		buttons = GameObject.Find ("Buttons").GetComponent<Buttons>();
		p = GameObject.Find ("Player").GetComponent<PlayerControl>();
		SC = GameObject.Find ("SwimmingController").GetComponent<SwimmingController>();
	}
	
	
	void Update(){
		
		if(p.isInTheWater){
			if(Input.GetKeyDown(KeyCode.Space) && b.freeze == false){
				IsRechargeOK();
			}
			if(rechargeOxygen){
				Recharge0xygen();
			} else {
				DecreaseOxygen();
			}
		}

		
	}
	
	void DecreaseOxygen(){
		healthBarSlider.value -= Time.deltaTime * 0.08f;
		if(healthBarSlider.value == 0){
			buttons.GameOver("endOfOx");
		}
	}
	
	void Recharge0xygen(){
	
		rechargeOxygen = true;
		if(healthBarSlider.value < 1){
			healthBarSlider.value += Time.deltaTime * 0.8f;
		} else {
			rechargeOxygen = false;
		}
		
	}
	
	void IsRechargeOK(){
		if(healthBarSlider.value <= 0.4f){
			SC.addPoints(10);
			Recharge0xygen();
		} else {
			countDown.SetCountdown();
			b.Freeze();
			buttons.MoreOxWarning();
			SC.addPoints(-55);
		}
	}
	

	
	
}
