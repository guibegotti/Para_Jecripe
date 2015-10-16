

using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;


public class Question 
{

	[XmlAttribute("q")]
	public string q;


	[XmlElement("AnswerA")]
	public string A1;


	[XmlElement("AnswerB")]
	public string A2;


	[XmlElement("AnswerC")]
	public string A3;


	[XmlElement("AnswerD")]
	public string A4;

	[XmlElement("Correct")]
	public string C;
	
	
}
