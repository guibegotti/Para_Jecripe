using UnityEngine;
using System.Collections;

public class Athletics_RelativePositions : MonoBehaviour {


	public int pos1;
	public int pos2;
	public int pos3;
	public int pos4;


	void Start () {
	
	}
	

	void Update () {


		if (AthleticsController.gameStarted)
		{
			SeePosition();
		}
	
	}

	void SeePosition()
	{

		int pos = 1;

		if (pos1 >= pos2 && pos1 >= pos3 && pos1 >= pos4)
		{
			pos = 1; 
		}


		else if (pos1 >= pos2 && pos1 >= pos3 && pos1 < pos4
			|| pos1 >= pos2 && pos1 < pos3 && pos1 >= pos4
			|| pos1 < pos2 && pos1 >= pos3 && pos1 >= pos4)
		{
			pos = 2;
		}

		else if (pos1 >= pos2 && pos1 < pos3 && pos1 < pos4
			|| pos1 < pos2 && pos1 >= pos3 && pos1 < pos4
			|| pos1 < pos2 && pos1 < pos3 && pos1 >= pos4)
		{
			pos = 3;
		}

		else if  (pos1 < pos2 && pos1 < pos3 && pos1 < pos4)
		{
			pos = 4;
		}

	}
}
