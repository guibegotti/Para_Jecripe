using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class StoreButtons : MonoBehaviour 
{
	public string itemName; 
	public int priceObject;
	public bool itBought = false;
	public GameObject itemToBuy; 
	public GameObject fPlayer;
	public GameObject sPlayer;
	public GameObject tPlayer;

	private EBPanel ebPanel;
	private ModalPanel modPanel;


	private static StoreButtons storeButtons;
	
	public static StoreButtons Instance ()
	{
		if (!storeButtons) 
		{
			storeButtons = FindObjectOfType(typeof (StoreButtons)) as StoreButtons;
			if (!storeButtons){
				
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
				
			}
		}
		return storeButtons;
	}


	void Awake ()
	{
		ebPanel = EBPanel.Instance ();
		modPanel = ModalPanel.Instance ();

	}
	
	//  Send to the Modal Panel to set up the Buttons and Functions to call
	public void TestEB () 
	{
		sPlayer.SetActive (false);
		tPlayer.SetActive (false);
		fPlayer.SetActive (true);

		if (itemToBuy.activeSelf == true) 
		{
			itemToBuy.SetActive (false);
		} 
		else 
		{
			itemToBuy.SetActive (true);
		}

		ebPanel.EBChoice (itBought, BuyFunction, EquipFunction);

	}
	
	//  These are wrapped into UnityActions
	void BuyFunction () 
	{
		modPanel.BuyChoice (itemName, priceObject);
	}
	
	void EquipFunction () 
	{
		itemToBuy.SetActive (true);
		DontDestroyOnLoad (itemToBuy);
	}

}
