using UnityEngine;
using System.Collections;

public class EdeniaItems : MonoBehaviour {
	public GameObject item1, item2, item3, item4, item5;
	public StoreDataContainer sD;

	void Start () {
		sD = StoreDataContainer.Load();

		if(sD.storeObjects[21].equiped == true)
		{
			item1.SetActive(true);
		}
		else 
		{
			item1.SetActive(false);
		}


		if(sD.storeObjects[22].equiped == true)
		{
			item2.SetActive(true);
		}
		else 
		{
			item2.SetActive(false);
		}


		if(sD.storeObjects[23].equiped == true)
		{
			item3.SetActive(true);
		}
		else 
		{
			item3.SetActive(false);
		}


		if(sD.storeObjects[24].equiped == true)
		{
			item4.SetActive(true);
		}
		else 
		{
			item4.SetActive(false);
		}


		if(sD.storeObjects[25].equiped == true)
		{
			item5.SetActive(true);
		}
		else 
		{
			item5.SetActive(false);
		}

		if (item1.activeSelf==false && item2.activeSelf==false && item3.activeSelf==false)
		{
			item1.SetActive(true);
		}
	}

}
