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
	public float radius;

	public float total;
	public float toRun;


	/*
	 * 475.4091
	 * 521.266
	 * 571.1882
	 * 622.1121
	 * 
	 * */



	void Start() {

		g1 = GameObject.Find ("Referencia2").transform;
		g2 = GameObject.Find ("Referencia").transform;

		difz0 = player.position.z - g1.position.z;
		difx0 = g1.position.x - player.position.x;

		radius = Mathf.Sqrt (Mathf.Pow ((player.position.x - g1.position.x), 2)
			+ Mathf.Pow ((player.position.z - g1.position.z),2));

		a = Mathf.Atan2 (difx0, difz0);
		subtract = radius * a;
		// subtract = 0;
	}


	void Update () {


		toRun = total - len;

		if (count == 0) {

			difz = player.position.z - g1.position.z;
			difx = Mathf.Abs (g1.position.x - player.position.x);

			a = Mathf.Atan2 (difx, difz);
			len = radius * a - subtract;

			if (difz <= 0) {
				count++;
			}


		} else if (count == 1) {

			difz = Mathf.Abs (player.position.z - g1.position.z);
			difx = g1.position.x - player.position.x;

			a = (Mathf.PI - Mathf.Atan2 (difx, difz));
			len = radius * a - subtract;

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
			len = len0 + radius * a;


			if (difz <= 0) { 
				count++;
			}

		} else if (count == 4) {

			difz = player.position.z - g2.position.z;
			difx = player.position.x - g2.position.x;

			a = (Mathf.PI - Mathf.Atan2 (difx, difz));
			len = len0 + radius * a;

			if (difx <= 0) {
				len0 = len;
				difz0 = difz;
				count++;
			}

		} else if (count == 5) {

			difx = g2.position.x - player.position.x;
			difz = player.position.z - g1.position.z;

			len = len0 + difx;

			if (difx < 0) {
				len0 = len;
				count++;
			}

		} else if (count == 6) {

			Debug.Log (player.name + " " + len);
			count++;
		}


	}






}