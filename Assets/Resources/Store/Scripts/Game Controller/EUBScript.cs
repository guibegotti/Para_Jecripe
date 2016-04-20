using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class EUBScript : MonoBehaviour {

	
	public Button buyButton;
	public Button equipButton;
	public Button unequipButton;
	public GameObject ebpanelObject;
	

	
	private static EUBScript ebPanel;
	
	public static EUBScript Instance () 
	{
		if (!ebPanel) 
		{
			ebPanel = FindObjectOfType(typeof (EUBScript)) as EUBScript;
			if (!ebPanel)
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
		}
		
		return ebPanel;
	}
	
	void Update ()
	{

	}
	
	
	public void EBChoice (Item i, UnityAction buyEvent, UnityAction equipEvent, UnityAction unequipEvent)
	{
		
		ebpanelObject.SetActive(true);
		
		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener (buyEvent);
		buyButton.onClick.AddListener(ClosePanel);
		
		unequipButton.onClick.RemoveAllListeners();
		unequipButton.onClick.AddListener (unequipEvent);
		unequipButton.onClick.AddListener(ClosePanel);
		
		equipButton.onClick.RemoveAllListeners();
		equipButton.onClick.AddListener (equipEvent);
		equipButton.onClick.AddListener(ClosePanel);
		
		if ((i.buy == true) && (i.equip == true))
		{
			equipButton.gameObject.SetActive(false);
			unequipButton.gameObject.SetActive(true);
			buyButton.gameObject.SetActive(false);
		}
		else 
		{
			if(i.buy == false)
			{
				equipButton.gameObject.SetActive(false);
				unequipButton.gameObject.SetActive(false);
				buyButton.gameObject.SetActive(true);
				
			}
			else
			{
				equipButton.gameObject.SetActive(true);
				unequipButton.gameObject.SetActive(false);
				buyButton.gameObject.SetActive(false);
			}
		}
		
		
	}
	public void ClosePanel ()
	{
		ebpanelObject.SetActive(false);
	}

}
