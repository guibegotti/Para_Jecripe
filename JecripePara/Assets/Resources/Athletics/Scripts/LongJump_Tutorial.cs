﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LongJump_Tutorial : MonoBehaviour
{

	GameObject b1, b2, b3, b4, b5;
	GameObject pauseCanvas;
	GameObject canvas1;
	Timer t;
	int count = 0;
	string bText; //Text written in the Balloon in the Editor
	
	public GameObject rightFoot, leftFoot;
	
	void Start ()
	{
		
		pauseCanvas = GameObject.Find ("PauseCanvas");
		pauseCanvas.SetActive (false);
		
		canvas1 = GameObject.Find ("Canvas");
		
		t = GetComponent<Timer> ();
		
		b1 = GameObject.Find ("b1");
		b1.GetComponentInChildren<Text> ().text = "";
		
		b2 = GameObject.Find ("b2");
		b2.SetActive (false);
		
		b3 = GameObject.Find ("b3");
		b3.SetActive (false);
		
		b4 = GameObject.Find ("b4");
		b4.SetActive(false);
		
		b5 = GameObject.Find ("b5");
		b5.SetActive(false);
		
		
		
	}
	
	public void PauseGame ()
	{
		
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			pauseCanvas.SetActive (true);
			canvas1.SetActive (false);
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			pauseCanvas.SetActive (false);
			canvas1.SetActive (true);
		}
	}
	
	void Update ()
	{
		
		if (count == 0) {
			
			if (Time.timeSinceLevelLoad >= 1 && Time.timeSinceLevelLoad < 3.3f) {
				
				b1.GetComponentInChildren<Text> ().text = "Seja bem-vindo ao jogo de salto em distância com a Verônica Hipólito!";
			
			} else if (Time.timeSinceLevelLoad >= 3.3f) {
				
				b1.GetComponentInChildren<Text> ().text = "Aperte ENTER para aprender a jogar";
				if (Input.GetKeyDown (KeyCode.Return)) {
					
					count++;
					t.SetTimer ();
					b1.SetActive (false);
				}
			}
			
		} else if (count == 1) {
		
			if (t.time >= 0.5f && t.time < 1.2f) {
				b2.SetActive (true);
				b2.GetComponentInChildren<Text> ().text = "";
				
			} else if (t.time >= 1.2f) {
			
				if (t.time < 3.5) { 
			
					b2.GetComponentInChildren<Text> ().text = "Observe de que lado está a pegada.";
					rightFoot.SetActive (true);
					GameObject.Find ("veronica3").GetComponent<veronica_Behaviour> ().StartGame ();
					
				} else if (t.time >= 3.5f & t.time < 4) {
				
					b2.GetComponentInChildren<Text> ().text = "Você precisa apertar a seta daquele mesmo lado para correr.";
				
				} else if (t.time > 4f) {
					
					b3.SetActive (true);
				
				
				}
				if (Input.GetKeyDown (KeyCode.RightArrow)) {
					b2.SetActive (false);
					rightFoot.SetActive(false);
					t.SetTimer ();
					count++;
				
				}
			
			
			}
		} else if (count == 2) {
			
			if (t.time >= 1.2f && t.time < 5) {
				
				b3.SetActive (false);
				
			} else if (t.time >= 8 && t.time < 10){
				
				b4.SetActive(true);
				
			} else if (t.time >= 10 && t.time < 13){
				
				b5.SetActive(true);
				
			} else if (t.time >= 13 && t.time < 13.5f){
			
				b4.SetActive(false);
				
			} else if (t.time >= 13.5f){
				
				b5.SetActive(false);
			}
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
