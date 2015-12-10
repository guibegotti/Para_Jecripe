using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    GameObject players;
    
    // Use this for initialization
	void Start ()
    {
        players = GameObject.Find("Players");
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            players.transform.Rotate(0, 20, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            players.transform.Rotate(0, -20, 0);
        }
	}

    public void RotateLeftButton()
    {
		players.transform.Rotate(0, 20, 0);
        
    }
	public void RotateRightButton()
	{
		players.transform.Rotate(0, -20, 0);
	}
}
