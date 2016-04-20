using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameobjectNavegation : MonoBehaviour {

	
	int count = 0; //page counter
	public int max;
	
	public List<GameObject> list0;
	public List<GameObject> list1;
	public List<GameObject> list2;
	public List<GameObject> list3;
	public List<GameObject> list4;
	public List<GameObject> list5;
	public List<GameObject> list6;
	public List<GameObject> list7;
	
	public GameObject nextArrow;
	public GameObject previousArrow;
	
	
	void Start () {
	
		nextArrow = GameObject.Find ("NextPage button"); 
		previousArrow = GameObject.Find ("PreviousPage button");
	
	}
	
	
	void Update () {
	
		if (count == 0){
			
			previousArrow.SetActive(false);
			
			foreach(GameObject go in list0){
				go.SetActive(true);
			} 
			
			foreach(GameObject go in list1){
				go.SetActive(false);
			}
			
			
		} else if(count == 1){
			
			previousArrow.SetActive(true);
			
			foreach(GameObject go in list0){
				go.SetActive(false);
			} 
			
			foreach(GameObject go in list2){
				go.SetActive(false);
			}
			
			foreach(GameObject go in list1){ 
				go.SetActive(true);
			}
			
		} else if (count == 2){
			
			
			foreach(GameObject go in list1){
				go.SetActive(false);
			} 
			
			foreach(GameObject go in list3){
				go.SetActive(false);
			}
			
			foreach(GameObject go in list2){
				go.SetActive(true);
			}
			
			
		} else if (count == 3){
		
			
			foreach(GameObject go in list2){
				go.SetActive(false);
			}
			
			foreach(GameObject go in list4){
				go.SetActive(false);
			} 
			
			foreach(GameObject go in list3){
				go.SetActive(true);
			}
					
		} else if (count == 4){
			
			foreach(GameObject go in list3){
				
				go.SetActive(false);
			} 
			
			foreach(GameObject go in list5){
				
				go.SetActive(false);
			} 
			
			
			foreach(GameObject go in list4){
				
				go.SetActive(true);
			}
		
		} else if (count == 5){
			
			foreach(GameObject go in list4){
				
				go.SetActive(false);
			}
			
			foreach(GameObject go in list6){
				
				go.SetActive(false);
			}
			
			foreach(GameObject go in list5){
				
				go.SetActive(true);
			}
		
		} else if (count == 6){
			
			foreach(GameObject go in list5){
				
				go.SetActive(false);
			} 
			
			foreach(GameObject go in list7){
				
				go.SetActive(false);
			}
			
			foreach(GameObject go in list6){
				
				go.SetActive(true);
			}
			
			
		} else if (count == 7){
		
			foreach(GameObject go in list7){
				
				go.SetActive(true);
			}
			
			foreach(GameObject go in list6){
				
				go.SetActive(false);
			}
		}
		
		
	
	}
	
	
	public void nextTextPage(){
		
		count++;
		if(count == max){
			
			nextArrow.SetActive(false);
		}
	}
	
	
	public void previousTextPage(){
		
		count--;
		if(count != max){
		
			nextArrow.SetActive(true);
		}
	}
	
	
	
	
	
	
}
