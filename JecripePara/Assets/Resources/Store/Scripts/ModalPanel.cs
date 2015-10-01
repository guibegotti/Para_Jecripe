using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;


public class ModalPanel: MonoBehaviour {
	private RWPanel modalPanel;

	
	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myCancelAction;
	
	void Awake () {
		modalPanel = RWPanel.Instance ();

		myYesAction = new UnityAction (TestYesFunction);
		myNoAction = new UnityAction (TestNoFunction);
	
	}
	
	//  Send to the Modal Panel to set up the Buttons and Functions to call
	public void TestYN () {
		modalPanel.BuyChoice(myYesAction, myNoAction);
		}
	
	//  These are wrapped into UnityActions
	void TestYesFunction () {

	}
	
	void TestNoFunction () {

	}

}