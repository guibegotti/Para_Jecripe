using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextNavegation : MonoBehaviour {

	int count = 0;
	public int max;
	
	public string text0;
	public string text1;
	public string text2;
	public string text3;
	
	public Text text;
	public GameObject nextArrow;
	public GameObject previousArrow;
	
		
	void Update(){
	
		if (count == 0){
			
			previousArrow.SetActive(false);
			text.text = text0;
			
		} else if(count == 1){
			
			previousArrow.SetActive(true);
			text.text = text1;
			
		} else if (count == 2){
		
			text.text = text2;
			
		} else if (count == 3){
			
			text.text = text3;
		}
		
		if (count == max){
			
			nextArrow.SetActive(false);
		} else {
			
			nextArrow.SetActive(true);
		}
		
		
	}

	
	
	public void nextTextPage(){
	
		count++;
	
		
	}
	
	public void previousTextPage(){
		
		count--;
	}
	
	
	
	
}
