using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Breathing : MonoBehaviour {
	
	public Slider healthBarSlider;
	Bracadas b;
	PlayerControl p;
	public bool rechargeOxygen;
	CountDown countDown;
	public Text More02;
	Buttons buttons;
	
	
	void Start(){
		b = GameObject.Find ("Bracadas").GetComponent<Bracadas>();
		countDown = GameObject.Find ("Countdown").GetComponent<CountDown>();
		buttons = GameObject.Find ("Buttons").GetComponent<Buttons>();
		p = GameObject.Find ("Player").GetComponent<PlayerControl>();
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
			buttons.GameOver();
		}
	}
	
	void Recharge0xygen(){
		
		rechargeOxygen = true;
		More02.text = "";
		if(healthBarSlider.value < 1){
			healthBarSlider.value += Time.deltaTime * 0.8f;
		} else {
			rechargeOxygen = false;
		}
		
	}
	
	void IsRechargeOK(){
		if(healthBarSlider.value <= 0.4f){
			Recharge0xygen();
		} else {
			countDown.SetCountdown();
			b.Freeze();
			More02.text = "Consuma mais oxigênio entre as respirações!";
		}
	}
	

	
	
}
