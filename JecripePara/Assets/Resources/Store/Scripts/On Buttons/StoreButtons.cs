using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class StoreButtons : MonoBehaviour 
{

	public Text itemName;
	public int priceObject;
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


	void Start ()
	{
		ebPanel = EBPanel.Instance ();
		modPanel = ModalPanel.Instance ();
		sD = StoreDataContainer.Load(ModalPanel.STOREPATH);
		itBought = sD.storeObjects[num];
		//itBought.iObj = itemToBuy;
	
		itemName.text = itBought.objectName;
	}
	void Update()
	{
		sD = StoreDataContainer.Load(ModalPanel.STOREPATH);
		itBought = sD.storeObjects[num];


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
		modPanel.BuyChoice (bObj.objectName, priceObject, bObj);
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
