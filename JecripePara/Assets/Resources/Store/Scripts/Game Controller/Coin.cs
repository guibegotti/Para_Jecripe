using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Coin : MonoBehaviour {


	public Text coinT;
	public static int gold;


	private ItemButton itemButton;

	private static Coin coin ;

	public static Coin Instance ()
	{
		if (!coin) 
		{
			coin = FindObjectOfType(typeof (Coin)) as Coin;
			if (!coin){
				
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
				
			}
		}
		return coin;
	}

	// Update is called once per frame
	void fixedUpdate () 
	{
	
		itemButton = ItemButton.Instance();
		ItemButton.sD = StoreDataContainer.Load();
		gold = ItemButton.sD.storeObjects[0].coin;
		coinT.text = gold.ToString();

	}

	public void ChangeCoin (int c)
	{
		ItemButton.sD = StoreDataContainer.Load();
		ItemButton.sD.storeObjects[0].coin = ItemButton.sD.storeObjects[0].coin + (c);

		gold = gold+ c;
		coinT.text = gold.ToString();

	}
}
