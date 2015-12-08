using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class ModalPanel: MonoBehaviour 
{
	public const string STOREPATH = "StoreDatabase";

	private RWPanel rwpPanel;

	private StoreButtons sButtons;

	private StoreDataContainer sD;

	private static ModalPanel modPanel;



	
	public static ModalPanel Instance ()
	{
		if (!modPanel) 
		{
			modPanel = FindObjectOfType(typeof (ModalPanel)) as ModalPanel;
			if (!modPanel){
				
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
				
			}
		}
		return modPanel;
	}
	
	void Start () 
	{
		rwpPanel = RWPanel.Instance ();
		sButtons = StoreButtons.Instance ();

	
	}
	void Update ()
	{
		sD = StoreDataContainer.Load();
		rwpPanel.coinText.text = rwpPanel.coin.ToString();
	}
	
	//  Send to the Modal Panel to set up the Buttons and Functions to call
	public void BuyChoice (StoreData bItem) 
	{
		rwpPanel.YesNoChoice (bItem ,() =>{TestYesFunction(bItem);});
	}
	
	//  These are wrapped into UnityActions
	void TestYesFunction (StoreData k) 
	{
		k.bought=true;
		k.equiped = false;
		sD.storeObjects[sButtons.num] = k;
		sD.Save();

		rwpPanel.coin = rwpPanel.coin-k.price;
		rwpPanel.coinText.text = rwpPanel.coin.ToString();

		
	}

}