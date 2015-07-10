using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class placarController : MonoBehaviour
{

	public GUIText resultado;
	public Text resultText;

	void Start ()
	{
		
	}
	
	void Update ()
	{
		
		if (playerBehaviour2.termina && enemyBehaviour.termina) {
			if (playerBehaviour2.tempocorrida < enemyBehaviour.tempocorrida && playerBehaviour2.tempocorrida != 0) {

				resultText.text = "1. Jogador: " + playerBehaviour2.tempocorrida + "\n2. Oponente: " + enemyBehaviour.tempocorrida;

			} else {

				resultText.text = "1. Oponente: " + enemyBehaviour.tempocorrida + "\n2. Jogador: " + playerBehaviour2.tempocorrida;

			}

		}
	
	}
}
