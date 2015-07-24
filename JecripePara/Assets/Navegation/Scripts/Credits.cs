using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits : MonoBehaviour {

	GameObject creditsBox;
	public Text creditsText;
	float newPos;
	string credits = "JECRIPE PARALÍMPICO\n\nCOORDENADOR\nAndré Luiz Brandão\n\nDESENVOLVEDORES\nAlan de Aguiar\nAna Flávia de Araujo\nCaue Massi Correa\nGuilherme Begotti Domingos\nRafael Carneiro Soares\nDaniel Alves\nRodrigo Nunes\n\nUNIVERSIDADE FEDERAL DO ABC\n2015\n\nJECRIPE\nO JECRIPE (Jogos Especiais Criados para Pessoas Especiais) é um projeto que utiliza jogos eletrônicos para promover educação para e sobre pessoas com deficiência.\n\nCom o patrocínio da Secretaria de Cultura do Estado do Rio de Janeiro, desenvolveu-se o game original - um jogo de estímulo a crianças em idade pré-escolar que possuem Síndrome de Down.\n\nÉ o primeiro game inclusivo do mundo para essa faixa etária, e atende um público que ainda tem poucas opções disponíveis de tecnologias assistivas em mini-games.\n\nA mão no logotipo do Jecripe Paralímpico, característica de pessoas que possuem Síndrome de Down, é uma alusão ao JECRIPE orignial.\n\nhttp://www.jecripe.com/\n\n\nJECRIPE PARALÍMPICO\nO Jecripe Paralímpico é voltado ao público em geral. O objetivo do aplicativo é trazer informações sobre esportes praticados por pessoas com deficiência, e promover o interesse a respeito do tema, de uma forma divertida. \n\nÉ um software livre, cujos códigos podem ser acessados (e melhorados, se você quiser colaborar com a gente!)\n\n github.com/guibegotti/Jecripe_Paralympic";
	
	void Start(){
		
		creditsText.text = credits;
		creditsBox = GameObject.Find ("CreditsBox");
		newPos = creditsBox.transform.position.y;
	}
	
	void Update(){
		
		newPos += Time.deltaTime * 27;    
		creditsBox.transform.position = new Vector3(creditsBox.transform.position.x, newPos, creditsBox.transform.position.z);
	}
	
	
}
