using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class EBPanel : MonoBehaviour {

	public Button buyButton;
	public Button equipButton;
	public GameObject ynPanel;
	public GameObject ebpanelObject;
	public bool itBought;

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

	public void EBChoice (bool varitBought, UnityAction buyEvent, UnityAction equipEvent)
	{
		ebpanelObject.SetActive(true);

		buyButton.onClick.RemoveAllListeners();
		buyButton.onClick.AddListener (buyEvent);

	
		equipButton.onClick.RemoveAllListeners();
		equipButton.onClick.AddListener (equipEvent);

		this.itBought = varitBought;
		buyButton.gameObject.SetActive (true);

		if (this.itBought.Equals (true)) {
			equipButton.gameObject.SetActive (true);

		} else {
			buyButton.gameObject.SetActive (true);
		}

	}

}
