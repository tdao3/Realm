using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	bool level1PortalStatus = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 50, 0) * Time.deltaTime);
		if(Movement.hasKey)	{
			level1PortalStatus = true;
		}
	}

	void OnCollisionEnter(Collision collision) {
			if(SceneManager.GetActiveScene().name == "Starting Area")	{
				SceneManager.LoadScene("Level 1");	
			}
			if((level1PortalStatus) && (SceneManager.GetActiveScene().name == "Level 1"))	{
				SceneManager.LoadScene("Starting Area");
			}

	}
}
