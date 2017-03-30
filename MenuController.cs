﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void changeScene(string scene)	{
		SceneManager.LoadScene(scene);
	}

	public void quitGame()	{
		Application.Quit();
	}

}
