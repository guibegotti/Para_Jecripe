using UnityEngine;
using System.Collections;

public class Creditos : MonoBehaviour {

	public float left;
	public float top;
	public float height;


	string creditos = "\nJECRIPE PARALIMPICO\nhttp://jecripe.com.br\n\nCOORDENADOR\nAndre Luiz Brandao\n\nDESENVOLVEDORES\nAlan de Aguiar\nAna Flavia de Araujo\nCaue Massi Correa\nGuilherme Begotti Domingos\nRafael Carneiro Soares\nDaniel Alves\nRodrigo Nunes\n\nUNIVERSIDADE FEDERAL DO ABC\n2015";


	void OnGUI(){
		
		//left, top, width, height
		
		GUI.Box(new Rect(left, top, 280, height), creditos);
	}
	
	void Start(){
		left = Screen.width	/2 - 140;
		top = Screen.height /2 - 150;
		height = Screen.height/2 + 30;
	}
	

}
