using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemShopButton : MonoBehaviour {

	public Button button;
	public Text nameLabel;
	public Text priceLabel;
	public int price;
	public GameObject theObject;



	public GameObject buyButton;
	public GameObject equipButton;
	public GameObject rwPanel;
	public GameObject yesButton;
	public GameObject noButton;
	

	private int coin;

	
	private bool boughtItem = false;
	
	
	
	
	public void StoreButtonClick()
	{
		if (boughtItem == false) 
		{
			buyButton.SetActive (true);
			equipButton.SetActive(false);
		} 
		else 
		{
			buyButton.SetActive(false);
			equipButton.SetActive(false);
		}


		if (theObject.activeSelf == false) 
		{
			theObject.SetActive(true);
		}
		else
		{
			theObject.SetActive(false);
		}
		
	}
	
	
	public void BuyButtonOnClick()
	{
		
		if(boughtItem.Equals(false))
		{
			rwPanel.SetActive(true);
		}

	}
	public void EquipButtonOnClick()
	{
		DontDestroyOnLoad(theObject);
	}
	
	public void YesButton()
	{
		coin = coin - price;
		boughtItem = true;
		equipButton.SetActive(true);
		rwPanel.SetActive(false);


	}
	public void NoButton()
	{
		rwPanel.SetActive(false);
	}

}
