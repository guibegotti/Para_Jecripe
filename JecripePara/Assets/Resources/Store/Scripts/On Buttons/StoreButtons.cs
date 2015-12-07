using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class StoreButtons : MonoBehaviour 
{

	public Text itemName;
	public Text priceText;
	public int num;
	public GameObject itemToBuy; 
	public GameObject fPlayer;
	public GameObject sPlayer;
	public GameObject tPlayer;


	private StoreData itBought;
	private StoreDataContainer sD;
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
	void Update()
	{
		sD = StoreDataContainer.Load();
		itBought = sD.storeObjects[num];
		itemName.text = itBought.name;
		priceText.text = itBought.price.ToString();

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

		ebPanel.EBChoice ( itBought, () =>{BuyFunction(itBought);},() => {EquipFunction(itBought);});

	}
	
	//  These are wrapped into UnityActions
	void BuyFunction (StoreData bObj) 
	{
		modPanel.BuyChoice (bObj);
	}
	
	void EquipFunction (StoreData eqObj) 
	{
		eqObj.equiped=true;
		eqObj.bought = true;
		sD.storeObjects[num] = eqObj;
		sD.Save();
		itemToBuy.SetActive (true);
	}

}
