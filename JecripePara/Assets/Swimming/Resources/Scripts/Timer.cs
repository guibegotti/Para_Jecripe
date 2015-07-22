using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

	public float time;
	public bool timer;
	
	public void SetTimer ()
	{
		time = 0;
		timer = true;
	}
	
	void Update ()
	{
		if (timer) {
			time += Time.deltaTime;
			//Debug.Log (time);
		}	
	}
	
}
