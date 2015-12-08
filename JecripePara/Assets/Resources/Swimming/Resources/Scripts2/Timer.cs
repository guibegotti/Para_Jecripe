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
	
	public void ResetTimer(){
		time = 0;
		timer = false;
	}
	
	void Update ()
	{
		if (timer) {
			time += Time.deltaTime;
		}	
	}
	
}
