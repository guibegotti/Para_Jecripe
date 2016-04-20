using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class ClodoaldoItems : MonoBehaviour {

	public GameObject item1, item2, item3, item4, item5;
	public StoreDataContainer sD;

	void Start () {
		sD = StoreDataContainer.Load();

		if(sD.storeObjects[1].equiped == true)
		{
			item1.SetActive(true);
		}
		else 
		{
			item1.SetActive(false);
		}


		if(sD.storeObjects[2].equiped == true)
		{
			item2.SetActive(true);
		}
		else 
		{
			item2.SetActive(false);
		}


		if(sD.storeObjects[3].equiped == true)
		{
			item3.SetActive(true);
		}
		else 
		{
			item3.SetActive(false);
		}


		if(sD.storeObjects[10].equiped == true)
		{
			item4.SetActive(true);
		}
		else 
		{
			item4.SetActive(false);
		}


		if(sD.storeObjects[13].equiped == true)
		{
			item5.SetActive(true);
		}
		else 
		{
			item5.SetActive(false);
		}
	}

}
