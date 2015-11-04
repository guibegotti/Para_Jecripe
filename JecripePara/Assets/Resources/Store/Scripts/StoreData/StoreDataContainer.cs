
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

[XmlRoot ("Store")]
public class StoreDataContainer
{
	
	[XmlArray("StoreObjects")]
	[XmlArrayItem("StoreItem")]
	public List<StoreData> storeObjects = new List<StoreData>();
	
	public static StoreDataContainer Load(string path)
	{
		TextAsset _sXml = Resources.Load<TextAsset>(path);
		XmlSerializer _serializer = new XmlSerializer(typeof(StoreDataContainer));
		StringReader sReader = new StringReader (_sXml.text);
		StoreDataContainer storeObjects = _serializer.Deserialize(sReader) as StoreDataContainer;
		sReader.Close();
		
		return storeObjects;
	}
	
	public void Save() 
	{ 
		var serializer = new XmlSerializer(typeof(StoreDataContainer));
		FileStream stream = new FileStream(ModalPanel.STOREPATH, FileMode.Create);
		serializer.Serialize(stream, this);
		stream.Close();
	}
}
