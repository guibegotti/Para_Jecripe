using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class ModalPanel: MonoBehaviour 
{


	private RWPanel rwpPanel;
	private StoreButtons sButtons;

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



	
	void Awake () 
	{
		rwpPanel = RWPanel.Instance ();
		sButtons = StoreButtons.Instance ();
	
	}
	
	//  Send to the Modal Panel to set up the Buttons and Functions to call
	public void BuyChoice (string name, int priceItem) 
	{
		rwpPanel.YesNoChoice(name, priceItem, () =>{TestYesFunction(priceItem);}, TestNoFunction);
	}
	
	//  These are wrapped into UnityActions
	void TestYesFunction (int price) 
	{
		//coin= coin-price;
		sButtons.itBought = true;
	}
	
	void TestNoFunction ()
	{

	}

}