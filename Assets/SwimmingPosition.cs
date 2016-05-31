using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwimmingPosition : MonoBehaviour {

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;


    public Text positiontext;



	void Update () {

        SeePositions();
        
	}


    void SeePositions()
    {


        int pos = 1;

        if(pos1.position.z >= pos2.position.z && pos1.position.z >= pos3.position.z)
        {
            pos = 1;

        } else if (pos1.position.z <= pos2.position.z && pos1.position.z >= pos3.position.z || pos1.position.z >= pos2.position.z && pos1.position.z <= pos3.position.z)
        {
            pos = 2; 

        } else if (pos1.position.z <= pos2.position.z && pos1.position.z <= pos3.position.z)
        {

            pos = 3; 
        }

        positiontext.text = pos.ToString();

    }
}
