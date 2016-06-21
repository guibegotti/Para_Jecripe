using UnityEngine;
using System.Collections;

public class AthleticsPosition : MonoBehaviour {


	public Transform g1; //first reference
	public Transform g2; //second reference

	public Transform player;



	public float difz0;
	public float difx0;


	public float difz;
	public float difx;



	public float a; //*
	public float len; //*

	public int count = 0;

	public float len0; //*
	public float subtract;


	void Start() {

		g1 = GameObject.Find ("Referencia2").transform;
		g2 = GameObject.Find ("Referencia").transform;

		difz0 = player.position.z - g1.position.z;
		difx0 = g1.position.x - player.position.x;

		a = Mathf.Atan2 (difx0, difz0);
		//subtract = difz0 * a;
		subtract = 0;
	}

   
    void Update () {
		if (count == 0) {

			difz = player.position.z - g1.position.z;
			difx = Mathf.Abs (g1.position.x - player.position.x);

			a = Mathf.Atan2 (difx, difz);
			len = difz0 * a - subtract;

			if (difz <= 0) {
				count++;
			}


		} else if (count == 1) {

			difz = Mathf.Abs (player.position.z - g1.position.z);
			difx = g1.position.x - player.position.x;

			a = (Mathf.PI - Mathf.Atan2 (difx, difz));
			len = difz0 * a - subtract;

			if (difx <= 0) {
				len0 = len;
				difz0 = difz;
				count++;
			}

		} else if (count == 2) {
			 
			difx = player.position.x - g1.position.x;
			difz = g1.position.z - player.position.z;

			len = len0 + difx;

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

		} else if (count == 4) {
		
			difz = player.position.z - g2.position.z;
			difx = player.position.x - g2.position.x;

			a = (Mathf.PI - Mathf.Atan2 (difx, difz));
			len = len0 + difz0 * a;

			if (difx <= 0) {
				len0 = len;
				difz0 = difz;
				count++;
			}

		} else if (count == 5) {
		
			difx = g2.position.x - player.position.x;
			difz = player.position.z - g1.position.z;

			len = len0 + difx;

			if (difz < difz0) {
				len0 = len;
				count++;
			}
		
		} else if (count == 6) {

			Debug.Log (player.name + " " + len);
			count++;
		}
			
	
	}

 




}
