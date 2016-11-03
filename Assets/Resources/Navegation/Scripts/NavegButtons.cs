using UnityEngine;
using System.Collections;

public class NavegButtons : MonoBehaviour {

	public string scene;
	
	public void LoadScene(){
		Application.LoadLevel (scene);	
	}
	
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

    public void LoadCanoe()
    {
        Application.LoadLevel("PlayCanoe");
    }
    public void LoadCanoeCuriosities()
    {
        Application.LoadLevel("Canoe_curiosities");
    }
    public void LoadTennisGame(){
		Application.LoadLevel("treino");
	}
	
	public void LoadAthleticsGame(){
		Application.LoadLevel ("AthleticsGame");
		
	}

	public void LoadAthleticsTutorial(){
		Application.LoadLevel ("AthleticsTutorial");
		
	}
	
	public void LoadSwimmingGame(){
		Application.LoadLevel("Swimming");
	}
	
	public void LoadQuitGame(){
		Application.Quit();
	}
	
	public void LoadQuiz(){
		Application.LoadLevel("QuizGame");
	}
	
	public void LoadTennisCuriosities(){
	
		Application.LoadLevel("TennisCuriosities");
	}
	
	public void LoadAthleticsCuriosities(){
	
		Application.LoadLevel("AthleticsCuriosities");
	}
	
	public void LoadSwimmingCuriosities(){
		
		Application.LoadLevel("SwimmingCuriosities");
	}
	
	public void LoadCredits(){
		
		Application.LoadLevel("Credits");
	}
	
	public void LoadAthleticsAthlete(){
		Application.LoadLevel("AthleticsAthlete");
	}
	
	public void LoadSwimmingAthlete(){
		Application.LoadLevel("SwimmingAthlete");
	}
	
	public void LoadTennisAthlete(){
		Application.LoadLevel("TennisAthlete");
	}
	
	public void LoadTennisMainGame(){
		Application.LoadLevel("main");
	}
	
	public void LoadTennisGameSelection(){
		Application.LoadLevel("TennisGameSelection");
	}
	
	
	
}
