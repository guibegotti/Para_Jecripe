using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class RWPanel : MonoBehaviour 
{
	public Button okButton;
	public Text coinText;

	public  int coin;

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


	public void YesNoChoice (string nameItem, int price, UnityAction yesEvent)
	{
		rwpanelObject.SetActive(true);

		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener (yesEvent);
		yesButton.onClick.AddListener(ClosePanel);

		noButton.onClick.AddListener (ClosePanel);	
		
		okButton.onClick.AddListener(ClosePanel);
		
		if(price<=coin)
		{
			buyQuestion.text = "Realmente deseja compra o item '" + nameItem+"' por "+price+" moedas?";
			yesButton.gameObject.SetActive(true);
			noButton.gameObject.SetActive(true);
			okButton.gameObject.SetActive(false);
		}
		else
		{
			buyQuestion.text = "Voce nao tem moedas suficientes, jogue mais vezes.";
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
