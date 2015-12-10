using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item {

	public int x;
	public bool buy, equip;
	public string type;
	public Text itemName;
	public Text priceText;
	public GameObject itemToBuy; 
	public GameObject fPlayer;
	public GameObject sPlayer;
	public GameObject tPlayer;
}

public class ItemButton : MonoBehaviour {
	
	public Item[] itemB =  new Item[16];

	public static StoreDataContainer sD;

	private GameObject terezinha;
	private GameObject clodoaldo;
	private GameObject marcos;
	private BuyButton buyButton;
	private EUBScript eubScript;

	private static ItemButton itemButtons;

	public static ItemButton Instance ()
	{
		if (!itemButtons) 
		{
			itemButtons = FindObjectOfType(typeof (ItemButton)) as ItemButton;
			if (!itemButtons){
				
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
				
			}
		}
		return itemButtons;
	}

	void Start()
	{

		buyButton = BuyButton.Instance();
		eubScript = EUBScript.Instance();

		sD = StoreDataContainer.Load();


		for( int count=1; count<=15; count++)
		{
			itemB[count].itemName.text = sD.storeObjects[count].name;
			itemB[count].priceText.text = sD.storeObjects[count].price.ToString();
			itemB[count].buy = sD.storeObjects[count].bought;
			itemB[count].equip = sD.storeObjects[count].equiped;
		}

	}
	
	void BuyFunction (Item i) 
	{
		buyButton.BuyChoice (i);
	}
	
	void EquipFunction (Item i) 
	{
		for( int y=0; y<=15; y++)
		{
			if(itemB[y].type == i.type && sD.storeObjects[y].equiped == true && itemB[i.x].fPlayer==itemB[y].fPlayer)
			{
				sD.storeObjects[y].equiped = false;
				itemB[y].equip = false;
			}
		}
		itemB[i.x].equip = true;
		sD.storeObjects[i.x].equiped = true;
		sD.storeObjects[i.x].bought = true;
		sD.Save();
		sD = StoreDataContainer.Load();
		i.itemToBuy.SetActive (true);
	}
	void UnequipFunction (Item i)
	{
		itemB[i.x].equip = false;
		sD.storeObjects[i.x].equiped = false;
		sD.storeObjects[i.x].bought = true;
		sD.Save();
		sD = StoreDataContainer.Load();
		i.itemToBuy.SetActive (false);
	}
	
	public void TestEB1 () 
	{

		itemB[1].fPlayer.SetActive(true);
		itemB[1].sPlayer.SetActive(false);
		itemB[1].tPlayer.SetActive(false);

		for( int y=0; y<=15; y++)
		{
			if(y!=1 && itemB[y].fPlayer==itemB[1].fPlayer && itemB[y].type == itemB[1].type)
			{
				itemB[y].itemToBuy.SetActive(false);

			}
		}

		if (itemB[1].itemToBuy.activeSelf == true) 
		{
			itemB[1].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[1].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[1],() =>{BuyFunction(itemB[1]);},() => {EquipFunction(itemB[1]);}, () =>{UnequipFunction(itemB[1]);});
		
	}

	public void TestEB2 () 
	{

		
		itemB[2].fPlayer.SetActive(true);
		itemB[2].sPlayer.SetActive(false);
		itemB[2].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if(y!=2 && itemB[y].fPlayer==itemB[2].fPlayer && itemB[y].type == itemB[2].type)
			{
				itemB[y].itemToBuy.SetActive(false);
				
			}
		}
		
		if (itemB[2].itemToBuy.activeSelf == true) 
		{
			itemB[2].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[2].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[2],() =>{BuyFunction(itemB[2]);},() => {EquipFunction(itemB[2]);}, () =>{UnequipFunction(itemB[2]);});
		
	}	

	public void TestEB3 () 
	{
		
		itemB[3].fPlayer.SetActive(true);
		itemB[3].sPlayer.SetActive(false);
		itemB[3].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if(y!=3 && itemB[y].fPlayer==itemB[3].fPlayer && itemB[y].type == itemB[3].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		if (itemB[3].itemToBuy.activeSelf == true) 
		{
			itemB[3].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[3].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[3],() =>{BuyFunction(itemB[3]);},() => {EquipFunction(itemB[3]);}, () =>{UnequipFunction(itemB[3]);});
		
	}	
	public void TestEB4 () 
	{
		
		itemB[4].fPlayer.SetActive(true);
		itemB[4].sPlayer.SetActive(false);
		itemB[4].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=4 && itemB[y].fPlayer==itemB[4].fPlayer && itemB[y].type == itemB[4].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[4].itemToBuy.activeSelf == true) 
		{
			itemB[4].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[4].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[4],() =>{BuyFunction(itemB[4]);},() => {EquipFunction(itemB[4]);}, () =>{UnequipFunction(itemB[4]);});
		
	}	
	public void TestEB5 () 
	{
		
		itemB[5].fPlayer.SetActive(true);
		itemB[5].sPlayer.SetActive(false);
		itemB[5].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=5 && itemB[y].fPlayer==itemB[5].fPlayer && itemB[y].type == itemB[5].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[5].itemToBuy.activeSelf == true) 
		{
			itemB[5].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[5].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[5],() =>{BuyFunction(itemB[5]);},() => {EquipFunction(itemB[5]);}, () =>{UnequipFunction(itemB[5]);});
		
	}	
	public void TestEB6 () 
	{
		
		itemB[6].fPlayer.SetActive(true);
		itemB[6].sPlayer.SetActive(false);
		itemB[6].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=6 && itemB[y].fPlayer==itemB[6].fPlayer && itemB[y].type == itemB[6].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[6].itemToBuy.activeSelf == true) 
		{
			itemB[6].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[6].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[6],() =>{BuyFunction(itemB[6]);},() => {EquipFunction(itemB[6]);}, () =>{UnequipFunction(itemB[6]);});
		
	}	
	public void TestEB7 () 
	{
		
		itemB[7].fPlayer.SetActive(true);
		itemB[7].sPlayer.SetActive(false);
		itemB[7].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=7 && itemB[y].fPlayer==itemB[7].fPlayer && itemB[y].type == itemB[7].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[7].itemToBuy.activeSelf == true) 
		{
			itemB[7].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[7].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[7],() =>{BuyFunction(itemB[7]);},() => {EquipFunction(itemB[7]);}, () =>{UnequipFunction(itemB[7]);});
		
	}	
	public void TestEB8 () 
	{
		
		itemB[8].fPlayer.SetActive(true);
		itemB[8].sPlayer.SetActive(false);
		itemB[8].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if(y!=8 && itemB[y].fPlayer==itemB[8].fPlayer && itemB[y].type == itemB[8].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[8].itemToBuy.activeSelf == true) 
		{
			itemB[8].itemToBuy.SetActive (false);
			itemB[7].itemToBuy.SetActive(true);
		} 
		else 
		{
			itemB[8].itemToBuy.SetActive (true);
			itemB[7].itemToBuy.SetActive(false);
		}
		
		eubScript.EBChoice ( itemB[8],() =>{BuyFunction(itemB[8]);},() => {EquipFunction(itemB[8]);}, () =>{UnequipFunction(itemB[8]);});
		
	}	
	public void TestEB9 () 
	{
		
		itemB[9].fPlayer.SetActive(true);
		itemB[9].sPlayer.SetActive(false);
		itemB[9].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if(y!=9 && itemB[y].fPlayer==itemB[9].fPlayer && itemB[y].type == itemB[9].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[9].itemToBuy.activeSelf == true) 
		{
			itemB[9].itemToBuy.SetActive (false);
			itemB[7].itemToBuy.SetActive(true);
		} 
		else 
		{
			itemB[9].itemToBuy.SetActive (true);
			itemB[7].itemToBuy.SetActive(false);
		}
		
		eubScript.EBChoice ( itemB[9],() =>{BuyFunction(itemB[9]);},() => {EquipFunction(itemB[9]);}, () =>{UnequipFunction(itemB[9]);});
		
	}	
	public void TestEB10 () 
	{
		
		itemB[10].fPlayer.SetActive(true);
		itemB[10].sPlayer.SetActive(false);
		itemB[10].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if(y!=10 && itemB[y].fPlayer==itemB[10].fPlayer && itemB[y].type == itemB[10].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[10].itemToBuy.activeSelf == true) 
		{
			itemB[10].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[10].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[10],() =>{BuyFunction(itemB[10]);},() => {EquipFunction(itemB[10]);}, () =>{UnequipFunction(itemB[10]);});
		
	}
	public void TestEB11 () 
	{
		
		itemB[11].fPlayer.SetActive(true);
		itemB[11].sPlayer.SetActive(false);
		itemB[11].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=11 && itemB[y].fPlayer==itemB[11].fPlayer && itemB[y].type == itemB[11].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[11].itemToBuy.activeSelf == true) 
		{
			itemB[11].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[11].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[11],() =>{BuyFunction(itemB[11]);},() => {EquipFunction(itemB[11]);}, () =>{UnequipFunction(itemB[11]);});
		
	}
	public void TestEB12 () 
	{
		
		itemB[12].fPlayer.SetActive(true);
		itemB[12].sPlayer.SetActive(false);
		itemB[12].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=12 && itemB[y].fPlayer==itemB[12].fPlayer && itemB[y].type == itemB[12].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[12].itemToBuy.activeSelf == true) 
		{
			itemB[12].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[12].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[12],() =>{BuyFunction(itemB[12]);},() => {EquipFunction(itemB[12]);}, () =>{UnequipFunction(itemB[12]);});
		
	}
	public void TestEB13 () 
	{
		
		itemB[13].fPlayer.SetActive(true);
		itemB[13].sPlayer.SetActive(false);
		itemB[13].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=13 && itemB[y].fPlayer==itemB[13].fPlayer && itemB[y].type == itemB[13].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[13].itemToBuy.activeSelf == true) 
		{
			itemB[13].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[13].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[13],() =>{BuyFunction(itemB[13]);},() => {EquipFunction(itemB[13]);}, () =>{UnequipFunction(itemB[13]);});
		
	}
	public void TestEB14 () 
	{
		
		itemB[14].fPlayer.SetActive(true);
		itemB[14].sPlayer.SetActive(false);
		itemB[14].tPlayer.SetActive(false);

		for( int y=0; y<=15; y++)
		{
			if(y!=14 && itemB[y].fPlayer==itemB[14].fPlayer && itemB[y].type == itemB[14].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		
		if (itemB[14].itemToBuy.activeSelf == true) 
		{
			itemB[14].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[14].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[14],() =>{BuyFunction(itemB[14]);},() => {EquipFunction(itemB[14]);}, () =>{UnequipFunction(itemB[14]);});
		
	}
	public void TestEB15 () 
	{
		
		itemB[15].fPlayer.SetActive(true);
		itemB[15].sPlayer.SetActive(false);
		itemB[15].tPlayer.SetActive(false);
		
		for( int y=0; y<=15; y++)
		{
			if( y!=15 && itemB[y].fPlayer==itemB[15].fPlayer && itemB[y].type == itemB[15].type)
			{
				itemB[y].itemToBuy.SetActive(false);
			}
		}
		
		if (itemB[15].itemToBuy.activeSelf == true) 
		{
			itemB[15].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB[15].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice ( itemB[15],() =>{BuyFunction(itemB[15]);},() => {EquipFunction(itemB[15]);}, () =>{UnequipFunction(itemB[15]);});
		
	}



}
