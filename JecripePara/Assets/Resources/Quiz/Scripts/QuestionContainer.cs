/// <summary>
/// Question container.
/// </summary>

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
	
	/// <summary>
	/// Load the specified path.
	/// </summary>
	/// <param name="path">Path.</param>
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