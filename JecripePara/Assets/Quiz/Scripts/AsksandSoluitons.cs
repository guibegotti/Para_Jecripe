using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class AsksandSoluitons: MonoBehaviour{
	
	
	string Asks, A1,A2,A3,A4,C;
	
	private int RandNumb;
	public bool i = false;
	public int[] alreadyAsked = new int[40];
	int j = 0; // the number of questions already asked;
	int a;
	int tryQuestion;
	
	
	QuizButtons quizButtons;
	
	public int RandomNumberfunction() {
		if (i==false) {
			RandNumb = Random.Range (0,40);
			a = 0;
			while(a <= j){
				if(RandNumb == alreadyAsked[a]){
					RandNumb = Random.Range (0,40);
					a = 0;
				} else{
					a++;
				}
			}
			j++;
			
			if(j == 40){
				quizButtons.GameOver();
			} else {
				alreadyAsked[j] = RandNumb;
				i = true;
			}
		}
		return RandNumb;
		
	}
	
	
	public XmlDocument oXML = new XmlDocument ();
	
	
	// Use this for initialization
	void Start () {
		
		quizButtons = GameObject.Find ("ButtonScript").GetComponent<QuizButtons>();
		
		//loading the xmldocument.
		//oXML.Load(new XmlTextReader (Application.dataPath,  "AsksAndSolutions.xml"));
		
	}
	public string QuizQuestion(){
		
		Asks = oXML.SelectSingleNode("AsksAndSolutions").ChildNodes[RandomNumberfunction()].ChildNodes[0].InnerText;
		return Asks;
	}
	public string QuizSolutionA(){
		
		A1 = oXML.SelectSingleNode("AsksAndSolutions").ChildNodes[RandomNumberfunction()].ChildNodes[1].InnerText;
		return A1;
	}
	public string QuizSolutionB(){
		A2 = oXML.SelectSingleNode("AsksAndSolutions").ChildNodes[RandomNumberfunction()].ChildNodes[2].InnerText;
		return A2;
	}
	public string QuizSolutionC(){
		A3 = oXML.SelectSingleNode("AsksAndSolutions").ChildNodes[RandomNumberfunction()].ChildNodes[3].InnerText;
		return A3;
	}
	public string QuizSolutionD(){
		A4 = oXML.SelectSingleNode("AsksAndSolutions").ChildNodes[RandomNumberfunction()].ChildNodes[4].InnerText;
		return A4;
	}
	public string QuizCorrectSol(){
		
		C = oXML.SelectSingleNode("AsksAndSolutions").ChildNodes[RandomNumberfunction()].ChildNodes[5].InnerText;
		return C;
	}
}
