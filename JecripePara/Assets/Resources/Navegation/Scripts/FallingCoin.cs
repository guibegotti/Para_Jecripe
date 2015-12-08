using UnityEngine;
using System.Collections;

public class FallingCoin : MonoBehaviour
{

	
	public GameObject coinPrefab;
	
	public void coinFallAnimation ()
	{
		GameObject coin = Instantiate (coinPrefab, coinPrefab.transform.position, Quaternion.identity) as GameObject;
		coin.transform.parent = GameObject.Find ("Coins").transform;
		
	}
			
			
	
		
}
