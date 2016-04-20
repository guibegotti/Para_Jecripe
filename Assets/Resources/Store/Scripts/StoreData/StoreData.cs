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

	[XmlElement("Coin")]
	public int coin {get;set;}

}
