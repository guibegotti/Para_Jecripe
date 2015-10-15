using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class RWPanel : MonoBehaviour {

	public Button yesButton;
	public Button noButton;
	public GameObject rwpanelObject;

	public static RWPanel rwPanel;

	public static RWPanel Instance ()
	{
		if (!rwPanel) 
		{
			rwPanel = FindObjectOfType(typeof (RWPanel)) as RWPanel;
			if (!rwPanel){

				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in your scene.");
		
			}
		}
		return rwPanel;
	}


	public void BuyChoice (UnityAction yesEvent, UnityAction noEvent)
	{
		rwpanelObject.SetActive(true);

		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener(ClosePanel);
		
		
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);


		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
	}
	public void ClosePanel ()
	{
		rwpanelObject.SetActive(false);
	}
}
