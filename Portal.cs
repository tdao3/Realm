using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	bool level1PortalStatus = false;
	public GameObject[] lightSources;

	// Use this for initialization
	void Start () {
		for(int i=0; i<lightSources.Length; i++)	{
			lightSources[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 50, 0) * Time.deltaTime);
		if(Movement.hasKey)	{
			level1PortalStatus = true;
			for(int i=0; i<lightSources.Length; i++)	{
				lightSources[i].SetActive(true);
			}
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
