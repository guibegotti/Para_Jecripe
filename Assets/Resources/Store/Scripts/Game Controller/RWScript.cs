using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class RWScript : MonoBehaviour {


	public Button okButton;
	public Text buyQuestion;
	public Button yesButton;
	public Button noButton;
	public GameObject rwpanelObject;

	private static RWScript rwPanel;
	public static RWScript Instance ()
	{
		if (!rwPanel) 
		{
			rwPanel = FindObjectOfType(typeof (RWScript)) as RWScript;
			if (!rwPanel){
				
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
				
			}
		}
		return rwPanel;
	}

	public void YesNoChoice (Item i, UnityAction yesEvent)
	{
		rwpanelObject.SetActive(true);
		
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener(ClosePanel);
		
		noButton.onClick.AddListener (ClosePanel);	
		
		okButton.onClick.AddListener(ClosePanel);
		
		if(ItemButton.sD.storeObjects[i.x].price <= ItemButton.sD.storeObjects[0].coin )
		{
			buyQuestion.text = "Realmente deseja comprar o item '" + ItemButton.sD.storeObjects[i.x].name+"' por "+ItemButton.sD.storeObjects[i.x].price+" moedas?";
			yesButton.gameObject.SetActive(true);
			noButton.gameObject.SetActive(true);
			okButton.gameObject.SetActive(false);
		}
		else
		{
			buyQuestion.text = "Voce não tem moedas suficientes, jogue mais vezes.";
			okButton.gameObject.SetActive(true);
			yesButton.gameObject.SetActive(false);
			noButton.gameObject.SetActive(false);
			
		}
	}
	
	public void ClosePanel ()
	{
		rwpanelObject.SetActive(false);
	}
}
