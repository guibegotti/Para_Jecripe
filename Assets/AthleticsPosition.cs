using UnityEngine;
using System.Collections;

public class AthleticsPosition : MonoBehaviour {


    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public Vector3 pos4;

    


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (AthleticsController.gameStarted)
        {
            SeePosition();
        }
	
	}

    void SeePosition()
    {
        
    }



}
