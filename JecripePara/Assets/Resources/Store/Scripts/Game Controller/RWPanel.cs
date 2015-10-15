using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class RWPanel : MonoBehaviour 
{

	public Text buyQuestion;
	public Button yesButton;
	public Button noButton;
	public GameObject rwpanelObject;

	private static RWPanel rwPanel;

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


	public void YesNoChoice (string nameItem, int price, UnityAction yesEvent, UnityAction noEvent)
	{
		rwpanelObject.SetActive(true);

		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener(ClosePanel);
		
		
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener (noEvent);
		noButton.onClick.AddListener (ClosePanel);

		buyQuestion.text = "Realmente deseja compra o item '" + nameItem+"' por "+price+" moedas?";

		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
	}
	public void ClosePanel ()
	{
		rwpanelObject.SetActive(false);
	}
}
