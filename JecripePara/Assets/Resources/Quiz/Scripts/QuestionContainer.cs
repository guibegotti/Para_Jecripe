using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


[XmlRoot ("QuestionCollection")]
public class QuestionContainer
{
	
	[XmlArray("Questions")]
	[XmlArrayItem("Question")]
	public List<Question> questions = new List<Question>();
	
	
	public static QuestionContainer Load(string path)
	{
		TextAsset _xml = Resources.Load<TextAsset>(path);
		XmlSerializer serializer = new XmlSerializer(typeof(QuestionContainer));
		StringReader reader = new StringReader (_xml.text);
		QuestionContainer questions = serializer.Deserialize(reader) as QuestionContainer;
		reader.Close();
		
		return questions;
	}
	
}