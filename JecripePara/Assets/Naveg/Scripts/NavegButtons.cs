using UnityEngine;
using System.Collections;

public class NavegButtons : MonoBehaviour {

	
	public void LoadMenu(){
		Application.LoadLevel ("Menu");
	}
	
	public void LoadPlayScene(){
		Application.LoadLevel ("PlayScene");
	}
	
	public void LoadSports(){
		Application.LoadLevel ("SportsScene");
	}
	
	public void LoadTennis(){
		Application.LoadLevel ("PlayTennis");
	}
	
	public void LoadSwimming(){
		Application.LoadLevel("PlaySwimming");
	}
}
