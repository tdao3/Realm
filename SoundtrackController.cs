﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundtrackController : MonoBehaviour {

	public static SoundtrackController instance = null;

    void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name == "Starting Area")	{
			Destroy(this.gameObject);
		}
	}
}