using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAfterFall : MonoBehaviour {

	private Vector3 MovePos;

	void Update () {
		
		MovePos.y = 0;
	}

	void OnTriggerEnter (Collider other) {

		if (other.CompareTag("Player")) {
			SceneManager.LoadScene ("Main 1"); //change to load GAME OVER STAY 
											   //SMALL Menu

		}	
	}
}
