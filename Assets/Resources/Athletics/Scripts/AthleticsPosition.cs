using UnityEngine;
using System.Collections;

public class AthleticsPosition : MonoBehaviour {


	public Transform g1; //first reference
	public Transform g2; //second reference

	public Transform player;


	public bool b1;
	public bool b2;
	public bool b3;
	public bool b4;


	public float difz0;
	public float difz;

	public float difx0;
	public float difx;


    public int pos1;
    public int pos2;
    public int pos3;
    public int pos4;

	public float a; //*
	public float len; //*

	public int count = 0;

	public float len0; //*



	void Start() {
		difz0 = player.position.z - g1.position.z;
		difx0 = g1.position.x - player.position.x;

	}

   
    void Update () {
		if (count == 0) {

			difz = player.position.z - g1.position.z;
			difx = Mathf.Abs (g1.position.x - player.position.x);

			a = Mathf.Atan2 (difx, difz);
			len = difz0 * a;

			if (difz <= 0) {
				count++;
			}


		} else if (count == 1) {

			difz = Mathf.Abs (player.position.z - g1.position.z);
			difx = g1.position.x - player.position.x;

			a = (Mathf.PI - Mathf.Atan2 (difx, difz));
			len = difz0 * a;

			if (difx <= 0) {
				len0 = len;
				difz0 = difz;
				count++;
			}

		} else if (count == 2) {

			len = len0 + player.position.x - g1.position.x;
			difz = g1.position.z - player.position.z;

			if (difz < difz0) {
				len0 = len;
				count++;
			}
		
		} else if (count == 3) {
		
			difz = g1.position.z - player.position.z;
			difx = player.position.x - g2.position.x;

			a = Mathf.Atan2 (difx, difz);
			len = len0 + difz0 * a;


			if (difz <= 0) { 
				count++;
			}

		}









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


    int p1(Transform g1)
    {

        

        return 0;
    }



}
