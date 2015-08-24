using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

	GameObject creditsBox;
	public Text creditsText;
	float newPos;
	string credits = "PARAJECRIPE\n\nCOORDENAÇÃO\nAndré Luiz Brandão\n\nDESENVOLVIMENTO\nAlan de Aguiar\nAna Flávia de Araujo\nCaue Massi Correa\nGuilherme Begotti Domingos\nRafael Carneiro Soares\nDaniel Alves\n\nUNIVERSIDADE FEDERAL DO ABC\n2015\n\nJECRIPE\nO JECRIPE (Jogos Especiais Criados para Pessoas Especiais) é uma iniciativa que utiliza jogos eletrônicos para promover educação para e sobre pessoas com deficiência.\n\nAcesse os outros jogos!\nhttp://www.jecripe.com/\n\n\nPARAJECRIPE\nO ParaJecripe é voltado ao público em geral. O objetivo do aplicativo é trazer informações sobre esportes praticados por pessoas com deficiência, e promover o interesse a respeito do tema, de uma forma divertida. \n\nÉ um software livre, cujos códigos podem ser acessados (e melhorados, se você quiser colaborar com a gente!)\n\n github.com/guibegotti/Jecripe_Paralympic";
	
	void Start(){
		
		creditsText.text = credits;
		creditsBox = GameObject.Find ("CreditsBox");
		newPos = creditsBox.transform.position.y;
	}
	
	void Update(){
		
		newPos += Time.deltaTime * 30;    
		creditsBox.transform.position = new Vector3(creditsBox.transform.position.x, newPos, creditsBox.transform.position.z);
	}
	
	
}
