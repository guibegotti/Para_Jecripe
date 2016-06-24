using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Athletics_RelativePositions : MonoBehaviour {


	float pos1,pos2,pos3,pos4;

	public GameObject Terezinha;
	public GameObject a1;
	public GameObject a2;
	public GameObject a3;

	public Text positionText;



	void Update () {


		if (AthleticsController.gameStarted)
		{
			SeePosition();
		}

	}

	void SeePosition()
	{


		pos1 = Terezinha.GetComponent<AthleticsPosition> ().toRun;
		pos2 = a1.GetComponent<AthleticsPosition> ().toRun;
		pos3 = a2.GetComponent<AthleticsPosition> ().toRun;
		pos4 = a3.GetComponent<AthleticsPosition> ().toRun;



		int pos = 1;

		if (pos1 <= pos2 && pos1 <= pos3 && pos1 <= pos4)
		{
			pos = 1; 
		}


		else if (pos1 <= pos2 && pos1 <= pos3 && pos1 > pos4
			|| pos1 <= pos2 && pos1 > pos3 && pos1 <= pos4
			|| pos1 > pos2 && pos1 <= pos3 && pos1 <= pos4)
		{
			pos = 2;
		}

		else if (pos1 <= pos2 && pos1 > pos3 && pos1 > pos4
			|| pos1 > pos2 && pos1 <= pos3 && pos1 > pos4
			|| pos1 > pos2 && pos1 > pos3 && pos1 <= pos4)
		{
			pos = 3;
		}

		else if  (pos1 > pos2 && pos1 > pos3 && pos1 > pos4)
		{
			pos = 4;
		}

		positionText.text = pos.ToString ();

	}
}