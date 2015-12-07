using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


public class StoreData 
{
	[XmlAttribute("name")]
	public string name {get; set;}

    [XmlElement("price")]
	public int price {get; set;}

	[XmlElement("Bought")]
	public bool bought {get; set;}

	[XmlElement("Equiped")]
	public bool equiped  {get; set;}

	
	public void Save (string path)
	{

		using(var stream = new FileStream(path, FileMode.Create))
		{
			var serializer = new XmlSerializer(typeof(StoreData));
			serializer.Serialize(stream, this);
			stream.Close();
		}
		
		
	}
}
