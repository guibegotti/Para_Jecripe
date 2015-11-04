using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class StoreData 
{
	[XmlAttribute("name")]
	public string objectName;
	
	
	[XmlElement("Bought")]
	public bool bought;
	
	
	[XmlElement("Equiped")]
	public bool equiped;

	//[XmlElement("iObj")]
	//public GameObject iObj;
}
