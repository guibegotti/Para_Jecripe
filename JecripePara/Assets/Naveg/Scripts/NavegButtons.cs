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
	
	public void LoadAthletics(){
		Application.LoadLevel ("PlayAthletics");
	}
	
	public void LoadTennisGame(){
		Application.LoadLevel("treino");
	}
	
	public void LoadAthleticsGame(){
		Application.LoadLevel ("game");
		
	}
	
	public void LoadSwimmingGame(){
		Application.LoadLevel("Natacao");
	}
	
	
}
