using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EBPanel : MonoBehaviour 
{

	public Button buyButton;
	public Button equipButton;
	public GameObject ebpanelObject;

	private static EBPanel ebPanel;
		
	public static EBPanel Instance () 
	{
		if (!ebPanel) 
		{
			ebPanel = FindObjectOfType(typeof (EBPanel)) as EBPanel;
			if (!ebPanel)
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
		}
			
			return ebPanel;
	}

	public void EBChoice (bool wasBought, UnityAction buyEvent, UnityAction equipEvent)
	{
		ebpanelObject.SetActive(true);

		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener (buyEvent);
		buyButton.onClick.AddListener(ClosePanel);

	
		equipButton.onClick.RemoveAllListeners();
		equipButton.onClick.AddListener (equipEvent);
		equipButton.onClick.AddListener(ClosePanel);

		if (wasBought == false) 
		{
			buyButton.gameObject.SetActive (true);
			equipButton.gameObject.SetActive(false);
		}
		else 
		{
			equipButton.gameObject.SetActive(true);
			buyButton.gameObject.SetActive(false);
		}
	}
	public void ClosePanel ()
	{
		ebpanelObject.SetActive(false);
	}

}
