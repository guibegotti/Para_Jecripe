using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
	public string name;
	public string price;
	public GameObject sampleObject;
	public bool itwasBought;
	public Button.ButtonClickedEvent thingToDo;
}

public class ScrollList : MonoBehaviour 
{
	public GameObject equipButton;
	public GameObject buyButton;
	public GameObject sampleButton;
	public List<Item> itemList;
	public Transform contentPanel;

	// Use this for initialization
	void Start () {
		PopulateList();
	}
	
	void PopulateList()
	{
		foreach (var Item in itemList)
		{
			GameObject newButton = Instantiate (sampleButton) as GameObject;
			ItemShopButton button = newButton.GetComponent<ItemShopButton>();
			Item.sampleObject.SetActive(false);
			button.nameLabel.text = Item.name;
			button.priceLabel.text = Item.price;
			button.button.onClick = Item.thingToDo;
			newButton.transform.SetParent(contentPanel);

		}
	}
}
