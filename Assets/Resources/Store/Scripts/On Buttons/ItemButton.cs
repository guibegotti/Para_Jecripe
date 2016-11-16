using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Item
{

	public int x;
	public bool buy, equip;
	public string type;
	public Text itemName;
	public Text priceText;
	public GameObject itemToBuy;
	//Number of characters to receive items;
	//the fPlayer will appear on scene and the others will hide;
	public GameObject fPlayer;
	public GameObject sPlayer;
	public GameObject tPlayer;
	public GameObject aPlayer;
	public GameObject bPlayer;
	public GameObject cPlayer;
	public GameObject dPlayer;
}

public class ItemButton : MonoBehaviour
{
	
	public Item[] itemB = new Item[35];

	public GameObject oculos;

	public static StoreDataContainer sD;

	private BuyButton buyButton;
	private EUBScript eubScript;

	private static ItemButton itemButtons;

	public static ItemButton Instance ()
	{
		if (!itemButtons) {
			itemButtons = FindObjectOfType (typeof(ItemButton)) as ItemButton;
			if (!itemButtons) {
				
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
				
			}
		}
		return itemButtons;
	}

	void Start ()
	{

		buyButton = BuyButton.Instance ();
		eubScript = EUBScript.Instance ();

		sD = StoreDataContainer.Load ();


		for (int count = 1; count <= 35; count++) {
			itemB [count].itemName.text = sD.storeObjects [count].name;
			itemB [count].priceText.text = sD.storeObjects [count].price.ToString ();
			itemB [count].buy = sD.storeObjects [count].bought;
			itemB [count].equip = sD.storeObjects [count].equiped;
		}

	}

	void BuyFunction (Item i)
	{
		buyButton.BuyChoice (i);
	}

	void EquipFunction (Item i)
	{
		for (int y = 0; y <= 35; y++) {
			if (itemB [y].type == i.type && sD.storeObjects [y].equiped == true && itemB [i.x].fPlayer == itemB [y].fPlayer) {
				sD.storeObjects [y].equiped = false;
				sD.Save ();
				itemB [y].equip = false;
			}
		}
		itemB [i.x].equip = true;
		sD.storeObjects [i.x].equiped = true;
		sD.storeObjects [i.x].bought = true;
		sD.Save ();
		sD = StoreDataContainer.Load ();
		i.itemToBuy.SetActive (true);
	}

	void UnequipFunction (Item i)
	{
		itemB [i.x].equip = false;
		sD.storeObjects [i.x].equiped = false;
		sD.storeObjects [i.x].bought = true;
		sD.Save ();
		sD = StoreDataContainer.Load ();
		i.itemToBuy.SetActive (false);
	}

	public void TestEB1 ()
	{

		itemB [1].fPlayer.SetActive (true);
		itemB [1].sPlayer.SetActive (false);
		itemB [1].tPlayer.SetActive (false);
		itemB [1].aPlayer.SetActive (false);
		itemB [1].bPlayer.SetActive (false);
		itemB [1].cPlayer.SetActive (false);
		itemB [1].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 1 && itemB [y].fPlayer == itemB [1].fPlayer && itemB [y].type == itemB [1].type) {
				itemB [y].itemToBuy.SetActive (false);

			}
		}

		if (itemB [1].itemToBuy.activeSelf == true) {
			itemB [1].itemToBuy.SetActive (false);
		} else {
			itemB [1].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [1], () => {
			BuyFunction (itemB [1]);
		}, () => {
			EquipFunction (itemB [1]);
		}, () => {
			UnequipFunction (itemB [1]);
		});
		
	}

	public void TestEB2 ()
	{

		itemB [2].fPlayer.SetActive (true);
		itemB [2].sPlayer.SetActive (false);
		itemB [2].tPlayer.SetActive (false);
		itemB [2].aPlayer.SetActive (false);
		itemB [2].bPlayer.SetActive (false);
		itemB [2].cPlayer.SetActive (false);
		itemB [2].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}

			if (y != 2 && itemB [y].fPlayer == itemB [2].fPlayer && itemB [y].type == itemB [2].type) {
				itemB [y].itemToBuy.SetActive (false);
				
			}
		}
		
		if (itemB [2].itemToBuy.activeSelf == true) {
			itemB [2].itemToBuy.SetActive (false);
		} else {
			itemB [2].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [2], () => {
			BuyFunction (itemB [2]);
		}, () => {
			EquipFunction (itemB [2]);
		}, () => {
			UnequipFunction (itemB [2]);
		});
		
	}

	public void TestEB3 ()
	{
		itemB [3].fPlayer.SetActive (true);
		itemB [3].sPlayer.SetActive (false);
		itemB [3].tPlayer.SetActive (false);
		itemB [3].aPlayer.SetActive (false);
		itemB [3].bPlayer.SetActive (false);
		itemB [3].cPlayer.SetActive (false);
		itemB [3].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}

			if (y != 3 && itemB [y].fPlayer == itemB [3].fPlayer && itemB [y].type == itemB [3].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		if (itemB [3].itemToBuy.activeSelf == true) {
			itemB [3].itemToBuy.SetActive (false);
		} else {
			itemB [3].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [3], () => {
			BuyFunction (itemB [3]);
		}, () => {
			EquipFunction (itemB [3]);
		}, () => {
			UnequipFunction (itemB [3]);
		});
		
	}

	public void TestEB4 ()
	{
		itemB [4].fPlayer.SetActive (true);
		itemB [4].sPlayer.SetActive (false);
		itemB [4].tPlayer.SetActive (false);
		itemB [4].aPlayer.SetActive (false);
		itemB [4].bPlayer.SetActive (false);
		itemB [4].cPlayer.SetActive (false);
		itemB [4].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 4 && itemB [y].fPlayer == itemB [4].fPlayer && itemB [y].type == itemB [4].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [4].itemToBuy.activeSelf == true) {
			itemB [4].itemToBuy.SetActive (false);
		} else {
			itemB [4].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [4], () => {
			BuyFunction (itemB [4]);
		}, () => {
			EquipFunction (itemB [4]);
		}, () => {
			UnequipFunction (itemB [4]);
		});
		
	}

	public void TestEB5 ()
	{
		
		itemB [5].fPlayer.SetActive (true);
		itemB [5].sPlayer.SetActive (false);
		itemB [5].tPlayer.SetActive (false);
		itemB [5].aPlayer.SetActive (false);
		itemB [5].bPlayer.SetActive (false);
		itemB [5].cPlayer.SetActive (false);
		itemB [5].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 5 && itemB [y].fPlayer == itemB [5].fPlayer && itemB [y].type == itemB [5].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [5].itemToBuy.activeSelf == true) {
			itemB [5].itemToBuy.SetActive (false);
		} else {
			itemB [5].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [5], () => {
			BuyFunction (itemB [5]);
		}, () => {
			EquipFunction (itemB [5]);
		}, () => {
			UnequipFunction (itemB [5]);
		});
		
	}

	public void TestEB6 ()
	{
		
		itemB [6].fPlayer.SetActive (true);
		itemB [6].sPlayer.SetActive (false);
		itemB [6].tPlayer.SetActive (false);
		itemB [6].aPlayer.SetActive (false);
		itemB [6].bPlayer.SetActive (false);
		itemB [6].cPlayer.SetActive (false);
		itemB [6].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 6 && itemB [y].fPlayer == itemB [6].fPlayer && itemB [y].type == itemB [6].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [6].itemToBuy.activeSelf == true) {
			itemB [6].itemToBuy.SetActive (false);
		} else {
			itemB [6].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [6], () => {
			BuyFunction (itemB [6]);
		}, () => {
			EquipFunction (itemB [6]);
		}, () => {
			UnequipFunction (itemB [6]);
		});
		
	}

	public void TestEB7 ()
	{
		
		itemB [7].fPlayer.SetActive (true);
		itemB [7].sPlayer.SetActive (false);
		itemB [7].tPlayer.SetActive (false);
		itemB [7].aPlayer.SetActive (false);
		itemB [7].bPlayer.SetActive (false);
		itemB [7].cPlayer.SetActive (false);
		itemB [7].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 7 && itemB [y].fPlayer == itemB [7].fPlayer && itemB [y].type == itemB [7].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [7].itemToBuy.activeSelf == true) {
			itemB [7].itemToBuy.SetActive (false);
		} else {
			itemB [7].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [7], () => {
			BuyFunction (itemB [7]);
		}, () => {
			EquipFunction (itemB [7]);
		}, () => {
			UnequipFunction (itemB [7]);
		});
		
	}

	public void TestEB8 ()
	{
		
		itemB [8].fPlayer.SetActive (true);
		itemB [8].sPlayer.SetActive (false);
		itemB [8].tPlayer.SetActive (false);
		itemB [8].aPlayer.SetActive (false);
		itemB [8].bPlayer.SetActive (false);
		itemB [8].cPlayer.SetActive (false);
		itemB [8].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true ) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 8 && itemB [y].fPlayer == itemB [8].fPlayer && itemB [y].type == itemB [8].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [8].itemToBuy.activeSelf == true) {
			itemB [8].itemToBuy.SetActive (false);
			itemB [7].itemToBuy.SetActive (true);
		} else {
			itemB [8].itemToBuy.SetActive (true);
			itemB [7].itemToBuy.SetActive (false);
		}
		
		eubScript.EBChoice (itemB [8], () => {
			BuyFunction (itemB [8]);
		}, () => {
			EquipFunction (itemB [8]);
		}, () => {
			UnequipFunction (itemB [8]);
		});
		
	}

	public void TestEB9 ()
	{
		
		itemB [9].fPlayer.SetActive (true);
		itemB [9].sPlayer.SetActive (false);
		itemB [9].tPlayer.SetActive (false);
		itemB [9].aPlayer.SetActive (false);
		itemB [9].bPlayer.SetActive (false);
		itemB [9].cPlayer.SetActive (false);
		itemB [9].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 9 && itemB [y].fPlayer == itemB [9].fPlayer && itemB [y].type == itemB [9].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [9].itemToBuy.activeSelf == true) {
			itemB [9].itemToBuy.SetActive (false);
			itemB [7].itemToBuy.SetActive (true);
		} else {
			itemB [9].itemToBuy.SetActive (true);
			itemB [7].itemToBuy.SetActive (false);
		}
		
		eubScript.EBChoice (itemB [9], () => {
			BuyFunction (itemB [9]);
		}, () => {
			EquipFunction (itemB [9]);
		}, () => {
			UnequipFunction (itemB [9]);
		});
		
	}

	public void TestEB10 ()
	{
		
		itemB [10].fPlayer.SetActive (true);
		itemB [10].sPlayer.SetActive (false);
		itemB [10].tPlayer.SetActive (false);
		itemB [10].aPlayer.SetActive (false);
		itemB [10].bPlayer.SetActive (false);
		itemB [10].cPlayer.SetActive (false);
		itemB [10].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 10 && itemB [y].fPlayer == itemB [10].fPlayer && itemB [y].type == itemB [10].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [10].itemToBuy.activeSelf == true) {
			itemB [10].itemToBuy.SetActive (false);
		} else {
			itemB [10].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [10], () => {
			BuyFunction (itemB [10]);
		}, () => {
			EquipFunction (itemB [10]);
		}, () => {
			UnequipFunction (itemB [10]);
		});
		
	}

	public void TestEB11 ()
	{
		
		itemB [11].fPlayer.SetActive (true);
		itemB [11].sPlayer.SetActive (false);
		itemB [11].tPlayer.SetActive (false);
		itemB [11].aPlayer.SetActive (false);
		itemB [11].bPlayer.SetActive (false);
		itemB [11].cPlayer.SetActive (false);
		itemB [11].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 11 && itemB [y].fPlayer == itemB [11].fPlayer && itemB [y].type == itemB [11].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [11].itemToBuy.activeSelf == true) {
			itemB [11].itemToBuy.SetActive (false);
		} else {
			itemB [11].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [11], () => {
			BuyFunction (itemB [11]);
		}, () => {
			EquipFunction (itemB [11]);
		}, () => {
			UnequipFunction (itemB [11]);
		});
		
	}

	public void TestEB12 ()
	{
		
		itemB [12].fPlayer.SetActive (true);
		itemB [12].sPlayer.SetActive (false);
		itemB [12].tPlayer.SetActive (false);
		itemB [12].aPlayer.SetActive (false);
		itemB [12].bPlayer.SetActive (false);
		itemB [12].cPlayer.SetActive (false);
		itemB [12].dPlayer.SetActive (false);

		if (itemB[8].equip == false && itemB[9].equip == false)
		{
			itemB[7].itemToBuy.SetActive(true);
		}

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && y !=7 &&  itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 12 && itemB [y].fPlayer == itemB [12].fPlayer && itemB [y].type == itemB [12].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [12].itemToBuy.activeSelf == true) {
			itemB [12].itemToBuy.SetActive (false);
		} else {
			itemB [12].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [12], () => {
			BuyFunction (itemB [12]);
		}, () => {
			EquipFunction (itemB [12]);
		}, () => {
			UnequipFunction (itemB [12]);
		});
		
	}

	public void TestEB13 ()
	{
		
		itemB [13].fPlayer.SetActive (true);
		itemB [13].sPlayer.SetActive (false);
		itemB [13].tPlayer.SetActive (false);
		itemB [13].aPlayer.SetActive (false);
		itemB [13].bPlayer.SetActive (false);
		itemB [13].cPlayer.SetActive (false);
		itemB [13].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 13 && itemB [y].fPlayer == itemB [13].fPlayer && itemB [y].type == itemB [13].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [13].itemToBuy.activeSelf == true) {
			itemB [13].itemToBuy.SetActive (false);
		} else {
			itemB [13].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [13], () => {
			BuyFunction (itemB [13]);
		}, () => {
			EquipFunction (itemB [13]);
		}, () => {
			UnequipFunction (itemB [13]);
		});
		
	}

	public void TestEB14 ()
	{
		
		itemB [14].fPlayer.SetActive (true);
		itemB [14].sPlayer.SetActive (false);
		itemB [14].tPlayer.SetActive (false);
		itemB [14].aPlayer.SetActive (false);
		itemB [14].bPlayer.SetActive (false);
		itemB [14].cPlayer.SetActive (false);
		itemB [14].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 14 && itemB [y].fPlayer == itemB [14].fPlayer && itemB [y].type == itemB [14].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		
		if (itemB [14].itemToBuy.activeSelf == true) {
			itemB [14].itemToBuy.SetActive (false);
			oculos.SetActive (true);
		} else {
			itemB [14].itemToBuy.SetActive (true);
			oculos.SetActive (false);
		}
		
		eubScript.EBChoice (itemB [14], () => {
			BuyFunction (itemB [14]);
		}, () => {
			EquipFunction (itemB [14]);
		}, () => {
			UnequipFunction (itemB [14]);
		});
		
	}

	public void TestEB15 ()
	{
		
		itemB [15].fPlayer.SetActive (true);
		itemB [15].sPlayer.SetActive (false);
		itemB [15].tPlayer.SetActive (false);
		itemB [15].aPlayer.SetActive (false);
		itemB [15].bPlayer.SetActive (false);
		itemB [15].cPlayer.SetActive (false);
		itemB [15].dPlayer.SetActive (false);

		if (itemB[8].equip == false && itemB[9].equip == false)
		{
			itemB[7].itemToBuy.SetActive(true);
		}

		for (int y = 1; y <= 35; y++) {
			if (y != 1 &&  y !=7 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 15 && itemB [y].fPlayer == itemB [15].fPlayer && itemB [y].type == itemB [15].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}
		
		if (itemB [15].itemToBuy.activeSelf == true) {
			itemB [15].itemToBuy.SetActive (false);
		} else {
			itemB [15].itemToBuy.SetActive (true);
		}
		
		eubScript.EBChoice (itemB [15], () => {
			BuyFunction (itemB [15]);
		}, () => {
			EquipFunction (itemB [15]);
		}, () => {
			UnequipFunction (itemB [15]);
		});
		
	}

	public void TestEB16 ()
	{

		itemB [16].fPlayer.SetActive (true);
		itemB [16].sPlayer.SetActive (false);
		itemB [16].tPlayer.SetActive (false);
		itemB [16].aPlayer.SetActive (false);
		itemB [16].bPlayer.SetActive (false);
		itemB [16].cPlayer.SetActive (false);
		itemB [16].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 16 && itemB [y].fPlayer == itemB [16].fPlayer && itemB [y].type == itemB [16].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [16].itemToBuy.activeSelf == true) {
			itemB [16].itemToBuy.SetActive (false);
		} else {
			itemB [16].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [16], () => {
			BuyFunction (itemB [16]);
		}, () => {
			EquipFunction (itemB [16]);
		}, () => {
			UnequipFunction (itemB [16]);
		});

	}

	public void TestEB17 ()
	{
		itemB [17].fPlayer.SetActive (true);
		itemB [17].sPlayer.SetActive (false);
		itemB [17].tPlayer.SetActive (false);
		itemB [17].aPlayer.SetActive (false);
		itemB [17].bPlayer.SetActive (false);
		itemB [17].cPlayer.SetActive (false);
		itemB [17].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 17 && itemB [y].fPlayer == itemB [17].fPlayer && itemB [y].type == itemB [17].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [17].itemToBuy.activeSelf == true) {
			itemB [17].itemToBuy.SetActive (false);
		} else {
			itemB [17].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [17], () => {
			BuyFunction (itemB [17]);
		}, () => {
			EquipFunction (itemB [17]);
		}, () => {
			UnequipFunction (itemB [17]);
		});

	}

	public void TestEB18 ()
	{

		itemB [18].fPlayer.SetActive (true);
		itemB [18].sPlayer.SetActive (false);
		itemB [18].tPlayer.SetActive (false);
		itemB [18].aPlayer.SetActive (false);
		itemB [18].bPlayer.SetActive (false);
		itemB [18].cPlayer.SetActive (false);
		itemB [18].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 18 && itemB [y].fPlayer == itemB [18].fPlayer && itemB [y].type == itemB [18].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [18].itemToBuy.activeSelf == true) {
			itemB [18].itemToBuy.SetActive (false);
		} else {
			itemB [18].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [18], () => {
			BuyFunction (itemB [18]);
		}, () => {
			EquipFunction (itemB [18]);
		}, () => {
			UnequipFunction (itemB [18]);
		});

	}

	public void TestEB19 ()
	{

		itemB [19].fPlayer.SetActive (true);
		itemB [19].sPlayer.SetActive (false);
		itemB [19].tPlayer.SetActive (false);
		itemB [19].aPlayer.SetActive (false);
		itemB [19].bPlayer.SetActive (false);
		itemB [19].cPlayer.SetActive (false);
		itemB [19].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 19 && itemB [y].fPlayer == itemB [19].fPlayer && itemB [y].type == itemB [19].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [19].itemToBuy.activeSelf == true) {
			itemB [19].itemToBuy.SetActive (false);
		} else {
			itemB [19].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [19], () => {
			BuyFunction (itemB [19]);
		}, () => {
			EquipFunction (itemB [19]);
		}, () => {
			UnequipFunction (itemB [19]);
		});

	}

	public void TestEB20 ()
	{

		itemB [20].fPlayer.SetActive (true);
		itemB [20].sPlayer.SetActive (false);
		itemB [20].tPlayer.SetActive (false);
		itemB [20].aPlayer.SetActive (false);
		itemB [20].bPlayer.SetActive (false);
		itemB [20].cPlayer.SetActive (false);
		itemB [20].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 20 && itemB [y].fPlayer == itemB [20].fPlayer && itemB [y].type == itemB [20].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [20].itemToBuy.activeSelf == true) {
			itemB [20].itemToBuy.SetActive (false);
		} else {
			itemB [20].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [20], () => {
			BuyFunction (itemB [20]);
		}, () => {
			EquipFunction (itemB [20]);
		}, () => {
			UnequipFunction (itemB [20]);
		});

	}

	public void TestEB21 ()
	{

		itemB [21].fPlayer.SetActive (true);
		itemB [21].sPlayer.SetActive (false);
		itemB [21].tPlayer.SetActive (false);
		itemB [21].aPlayer.SetActive (false);
		itemB [21].bPlayer.SetActive (false);
		itemB [21].cPlayer.SetActive (false);
		itemB [21].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 21 && itemB [y].fPlayer == itemB [21].fPlayer && itemB [y].type == itemB [21].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [21].itemToBuy.activeSelf == true) {
			itemB [21].itemToBuy.SetActive (false);
		} else {
			itemB [21].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [21], () => {
			BuyFunction (itemB [21]);
		}, () => {
			EquipFunction (itemB [21]);
		}, () => {
			UnequipFunction (itemB [21]);
		});

	}
	public void TestEB22 ()
	{

		itemB [22].fPlayer.SetActive (true);
		itemB [22].sPlayer.SetActive (false);
		itemB [22].tPlayer.SetActive (false);
		itemB [22].aPlayer.SetActive (false);
		itemB [22].bPlayer.SetActive (false);
		itemB [22].cPlayer.SetActive (false);
		itemB [22].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 22 && itemB [y].fPlayer == itemB [22].fPlayer && itemB [y].type == itemB [22].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [22].itemToBuy.activeSelf == true) {
			itemB [22].itemToBuy.SetActive (false);
		} else {
			itemB [22].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [22], () => {
			BuyFunction (itemB [22]);
		}, () => {
			EquipFunction (itemB [22]);
		}, () => {
			UnequipFunction (itemB [22]);
		});

	}

	public void TestEB23 ()
	{

		itemB [23].fPlayer.SetActive (true);
		itemB [23].sPlayer.SetActive (false);
		itemB [23].tPlayer.SetActive (false);
		itemB [23].aPlayer.SetActive (false);
		itemB [23].bPlayer.SetActive (false);
		itemB [23].cPlayer.SetActive (false);
		itemB [23].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 23 && itemB [y].fPlayer == itemB [23].fPlayer && itemB [y].type == itemB [23].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [23].itemToBuy.activeSelf == true) {
			itemB [23].itemToBuy.SetActive (false);
		} else {
			itemB [23].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [23], () => {
			BuyFunction (itemB [23]);
		}, () => {
			EquipFunction (itemB [23]);
		}, () => {
			UnequipFunction (itemB [23]);
		});

	}

	public void TestEB24 ()
	{

		itemB [24].fPlayer.SetActive (true);
		itemB [24].sPlayer.SetActive (false);
		itemB [24].tPlayer.SetActive (false);
		itemB [24].aPlayer.SetActive (false);
		itemB [24].bPlayer.SetActive (false);
		itemB [24].cPlayer.SetActive (false);
		itemB [24].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 24 && itemB [y].fPlayer == itemB [24].fPlayer && itemB [y].type == itemB [24].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [24].itemToBuy.activeSelf == true) {
			itemB [24].itemToBuy.SetActive (false);
		} else {
			itemB [24].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [24], () => {
			BuyFunction (itemB [24]);
		}, () => {
			EquipFunction (itemB [24]);
		}, () => {
			UnequipFunction (itemB [24]);
		});

	}
	public void TestEB25 ()
	{

		itemB [25].fPlayer.SetActive (true);
		itemB [25].sPlayer.SetActive (false);
		itemB [25].tPlayer.SetActive (false);
		itemB [25].aPlayer.SetActive (false);
		itemB [25].bPlayer.SetActive (false);
		itemB [25].cPlayer.SetActive (false);
		itemB [25].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 25 && itemB [y].fPlayer == itemB [25].fPlayer && itemB [y].type == itemB [25].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [25].itemToBuy.activeSelf == true) {
			itemB [25].itemToBuy.SetActive (false);
		} else {
			itemB [25].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [25], () => {
			BuyFunction (itemB [25]);
		}, () => {
			EquipFunction (itemB [25]);
		}, () => {
			UnequipFunction (itemB [25]);
		});

	}
	public void TestEB26 ()
	{

		itemB [26].fPlayer.SetActive (true);
		itemB [26].sPlayer.SetActive (false);
		itemB [26].tPlayer.SetActive (false);
		itemB [26].aPlayer.SetActive (false);
		itemB [26].bPlayer.SetActive (false);
		itemB [26].cPlayer.SetActive (false);
		itemB [26].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) {
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) {
				itemB [y].itemToBuy.SetActive (false);
			}
			if (y != 26 && itemB [y].fPlayer == itemB [26].fPlayer && itemB [y].type == itemB [26].type) {
				itemB [y].itemToBuy.SetActive (false);
			}
		}

		if (itemB [26].itemToBuy.activeSelf == true) {
			itemB [26].itemToBuy.SetActive (false);
		} else {
			itemB [26].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice (itemB [26], () => {
			BuyFunction (itemB [26]);
		}, () => {
			EquipFunction (itemB [26]);
		}, () => {
			UnequipFunction (itemB [26]);
		});

	}

	public void TestEB27 ()
	{

		itemB [27].fPlayer.SetActive (true);
		itemB [27].sPlayer.SetActive (false);
		itemB [27].tPlayer.SetActive (false);
		itemB [27].aPlayer.SetActive (false);
		itemB [27].bPlayer.SetActive (false);
		itemB [27].cPlayer.SetActive (false);
		itemB [27].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 27 && itemB [y].fPlayer == itemB [27].fPlayer && itemB [y].type == itemB [27].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [27].itemToBuy.activeSelf == true)
		{
			itemB [27].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [27].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [27],
			() => { BuyFunction (itemB [27]);},
			() => { EquipFunction (itemB [27]);},
			() => { UnequipFunction (itemB [27]);});
	}
	public void TestEB28 ()
	{

		itemB [28].fPlayer.SetActive (true);
		itemB [28].sPlayer.SetActive (false);
		itemB [28].tPlayer.SetActive (false);
		itemB [28].aPlayer.SetActive (false);
		itemB [28].bPlayer.SetActive (false);
		itemB [28].cPlayer.SetActive (false);
		itemB [28].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 28 && itemB [y].fPlayer == itemB [28].fPlayer && itemB [y].type == itemB [28].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [28].itemToBuy.activeSelf == true)
		{
			itemB [28].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [28].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [28],
			() => { BuyFunction (itemB [28]);},
			() => { EquipFunction (itemB [28]);},
			() => { UnequipFunction (itemB [28]);});
	}
	public void TestEB29 ()
	{

		itemB [29].fPlayer.SetActive (true);
		itemB [29].sPlayer.SetActive (false);
		itemB [29].tPlayer.SetActive (false);
		itemB [29].aPlayer.SetActive (false);
		itemB [29].bPlayer.SetActive (false);
		itemB [29].cPlayer.SetActive (false);
		itemB [29].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 29 && itemB [y].fPlayer == itemB [29].fPlayer && itemB [y].type == itemB [29].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [29].itemToBuy.activeSelf == true)
		{
			itemB [29].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [29].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [29],
			() => { BuyFunction (itemB [29]);},
			() => { EquipFunction (itemB [29]);},
			() => { UnequipFunction (itemB [29]);});
	}
	public void TestEB30 ()
	{

		itemB [30].fPlayer.SetActive (true);
		itemB [30].sPlayer.SetActive (false);
		itemB [30].tPlayer.SetActive (false);
		itemB [30].aPlayer.SetActive (false);
		itemB [30].bPlayer.SetActive (false);
		itemB [30].cPlayer.SetActive (false);
		itemB [30].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 30 && itemB [y].fPlayer == itemB [30].fPlayer && itemB [y].type == itemB [30].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [30].itemToBuy.activeSelf == true)
		{
			itemB [30].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [30].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [30],
			() => { BuyFunction (itemB [30]);},
			() => { EquipFunction (itemB [30]);},
			() => { UnequipFunction (itemB [30]);});
	}
	public void TestEB31 ()
	{

		itemB [31].fPlayer.SetActive (true);
		itemB [31].sPlayer.SetActive (false);
		itemB [31].tPlayer.SetActive (false);
		itemB [31].aPlayer.SetActive (false);
		itemB [31].bPlayer.SetActive (false);
		itemB [31].cPlayer.SetActive (false);
		itemB [31].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 31 && itemB [y].fPlayer == itemB [31].fPlayer && itemB [y].type == itemB [31].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [31].itemToBuy.activeSelf == true)
		{
			itemB [31].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [31].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [31],
			() => { BuyFunction (itemB [31]);},
			() => { EquipFunction (itemB [31]);},
			() => { UnequipFunction (itemB [31]);});
	}
	public void TestEB32 ()
	{

		itemB [32].fPlayer.SetActive (true);
		itemB [32].sPlayer.SetActive (false);
		itemB [32].tPlayer.SetActive (false);
		itemB [32].aPlayer.SetActive (false);
		itemB [32].bPlayer.SetActive (false);
		itemB [32].cPlayer.SetActive (false);
		itemB [32].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 32 && itemB [y].fPlayer == itemB [32].fPlayer && itemB [y].type == itemB [32].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [32].itemToBuy.activeSelf == true)
		{
			itemB [32].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [32].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [32],
			() => { BuyFunction (itemB [32]);},
			() => { EquipFunction (itemB [32]);},
			() => { UnequipFunction (itemB [32]);});
	}
	public void TestEB33 ()
	{

		itemB [33].fPlayer.SetActive (true);
		itemB [33].sPlayer.SetActive (false);
		itemB [33].tPlayer.SetActive (false);
		itemB [33].aPlayer.SetActive (false);
		itemB [33].bPlayer.SetActive (false);
		itemB [33].cPlayer.SetActive (false);
		itemB [33].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 33 && itemB [y].fPlayer == itemB [33].fPlayer && itemB [y].type == itemB [33].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [33].itemToBuy.activeSelf == true)
		{
			itemB [33].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [33].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [33],
			() => { BuyFunction (itemB [33]);},
			() => { EquipFunction (itemB [33]);},
			() => { UnequipFunction (itemB [33]);});
	}

	public void TestEB34 ()
	{

		itemB [34].fPlayer.SetActive (true);
		itemB [34].sPlayer.SetActive (false);
		itemB [34].tPlayer.SetActive (false);
		itemB [34].aPlayer.SetActive (false);
		itemB [34].bPlayer.SetActive (false);
		itemB [34].cPlayer.SetActive (false);
		itemB [34].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 34 && itemB [y].fPlayer == itemB [34].fPlayer && itemB [y].type == itemB [34].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [34].itemToBuy.activeSelf == true)
		{
			itemB [34].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [34].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [34],
			() => { BuyFunction (itemB [34]);},
			() => { EquipFunction (itemB [34]);},
			() => { UnequipFunction (itemB [34]);});
	}

	public void TestEB35 ()
	{

		itemB [35].fPlayer.SetActive (true);
		itemB [35].sPlayer.SetActive (false);
		itemB [35].tPlayer.SetActive (false);
		itemB [35].aPlayer.SetActive (false);
		itemB [35].bPlayer.SetActive (false);
		itemB [35].cPlayer.SetActive (false);
		itemB [35].dPlayer.SetActive (false);

		for (int y = 1; y <= 35; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 35 && itemB [y].fPlayer == itemB [35].fPlayer && itemB [y].type == itemB [35].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [35].itemToBuy.activeSelf == true)
		{
			itemB [35].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [35].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [35],
			() => { BuyFunction (itemB [35]);},
			() => { EquipFunction (itemB [35]);},
			() => { UnequipFunction (itemB [35]);});
	}
/*	public void TestEB36 ()
	{

		itemB [36].fPlayer.SetActive (true);
		itemB [36].sPlayer.SetActive (false);
		itemB [36].tPlayer.SetActive (false);
		itemB [36].aPlayer.SetActive (false);
		itemB [36].bPlayer.SetActive (false);
		itemB [36].cPlayer.SetActive (false);
		itemB [36].dPlayer.SetActive (false);
		
		for (int y = 1; y <= 36; y++) 
		{
			if (y != 1 && itemB [y].equip != true && itemB [y].itemToBuy.activeSelf == true) 
			{	itemB [y].itemToBuy.SetActive (false); }
			if (y != 36 && itemB [y].fPlayer == itemB [36].fPlayer && itemB [y].type == itemB [36].type) 
			{	itemB [y].itemToBuy.SetActive (false); }
		}

		if (itemB [36].itemToBuy.activeSelf == true)
		{
			itemB [36].itemToBuy.SetActive (false);
		} 
		else 
		{
			itemB [36].itemToBuy.SetActive (true);
		}

		eubScript.EBChoice ( itemB [36],
			() => { BuyFunction (itemB [36]);},
			() => { EquipFunction (itemB [36]);},
			() => { UnequipFunction (itemB [36]);});
	}
*/
}
