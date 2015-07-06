using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

	public float tempo;
	public bool timer;
	
	public void SetTimer ()
	{
		tempo = 0;
		timer = true;
	}
	
	void Update ()
	{
		if (timer) {
			tempo += Time.deltaTime;
			//Debug.Log (tempo);
		}	
	}
	
}
