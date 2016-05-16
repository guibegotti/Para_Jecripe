using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class BuyButton : MonoBehaviour {


	public  Text coinText;
	private ItemButton iButton;
	private RWScript rwScript;
	private int gold;

	private static BuyButton buyButtons;
	
	public static BuyButton Instance ()
	{
		if (!buyButtons) 
		{
			buyButtons = FindObjectOfType(typeof (BuyButton)) as BuyButton;
			if (!buyButtons){
				
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
				
			}
		}
		return buyButtons;
	}


	void Start()
	{
		gold = ItemButton.sD.storeObjects[0].coin;
		rwScript = RWScript.Instance();
		iButton = ItemButton.Instance();
		coinText.text  = gold.ToString();


	}
	//  Send to the Modal Panel to set up the Buttons and Functions to call
	public void BuyChoice (Item i) 
	{
		rwScript.YesNoChoice (i ,() =>{TestYesFunction(i);});
	}

	void TestYesFunction (Item i) 
	{

		ItemButton.sD.storeObjects[i.x].bought = true;
		iButton.itemB[i.x].buy = true;

		//moeda.ChangeCoin( -ItemButton.sD.storeObjects[i.x].price);

		ItemButton.sD.storeObjects[0].coin = ItemButton.sD.storeObjects[0].coin - ItemButton.sD.storeObjects[i.x].price;
		ItemButton.sD.Save();
		gold = ItemButton.sD.storeObjects[0].coin;
		coinText.text  = gold.ToString();


		
	}
}
