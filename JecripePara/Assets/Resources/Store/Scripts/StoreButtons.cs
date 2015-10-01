using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

//  This script will be updated in Part 2 of this 2 part series.
public class StoreButtons : MonoBehaviour {

	public bool i = false;

	public GameObject itemtoBuy;

	private EBPanel ebPanel;



	void Awake () {
		ebPanel = EBPanel.Instance ();
	}
	
	//  Send to the Modal Panel to set up the Buttons and Functions to call
	public void TestYNC () {
		ebPanel.EBChoice (i, BuyFunction, EquipFunction);

	}
	
	//  These are wrapped into UnityActions
	void BuyFunction () {
		ebPanel.ynPanel.SetActive(true);
	}
	
	void EquipFunction () {
		DontDestroyOnLoad(itemtoBuy);
	}
	void Bought()
	{

	}
}
