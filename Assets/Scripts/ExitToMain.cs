﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMain : MonoBehaviour {


	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene ("Main 1");
		}		
	}

}
