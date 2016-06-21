using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

	GameObject creditsBox;
	public Text creditsText;
	float newPos;
	string credits = "\nPARAJECRIPE\n\nCOORDENAÇÃO\nAndré Luiz Brandão\n\nDESENVOLVIMENTO\n"
	+ "Alan de Aguiar\nAna Flávia de Araujo\nCaue Massi Correa\nGuilherme Begotti Domingos\nRafael Carneiro Soares\n"
	+ "\nUNIVERSIDADE FEDERAL DO ABC\n\n"
	+ "AGRADECIMENTOS\n"
			+"Cassia Lorenzini\nCiro Winckler\nClodoaldo Silva\nDaniel Alves\nGuilherme Santana\nLeonardo Tomasello Araujo\n"
			+"Marcos Vasconcelos\nRodrigo Nunes\nRosemary de Almeida\nTalita Beck\nTerezinha Guilhermina\nThiago Souza\nVerônica Hipólito\n"
			+"PROEC UFABC\nCR Tennis\nSeleção Paralimpica de Natação"
	+ "\n\nJECRIPE\nO JECRIPE (Jogos Especiais Criados para Pessoas"
	+ "Especiais) é uma iniciativa que utiliza jogos eletrônicos para promover educação para e sobre pessoas com "
	+ "deficiência.\n\nAcesse os outros jogos!\nhttp://www.jecripe.com/\n\n\nPARAJECRIPE\nO ParaJecripe é voltado ao "
	+ "público em geral. Nosso objetivo é trazer informações sobre esportes praticados por pessoas com deficiência, "
	+ "e também, de uma forma divertida, promover o interesse sobre esse tema. \n\nÉ um software livre, cujos códigos podem ser acessados "
	+ "(e melhorados, se você quiser colaborar com a gente!)\n github.com/guibegotti/Para_Jecripe";
	
	
	
	
	void Start(){
        Time.timeScale = 1;
        creditsText.text = credits;
		creditsBox = GameObject.Find ("CreditsBox");
		newPos = creditsBox.transform.position.y;
	}
	
	void Update(){
		
		newPos += Time.deltaTime * 30;   
		creditsBox.transform.position = new Vector3(creditsBox.transform.position.x, newPos, creditsBox.transform.position.z);
		if(newPos >= 880){
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	
	
	
	
}
