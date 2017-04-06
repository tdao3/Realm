using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	bool level1PortalStatus = false;
	public AudioClip transport;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 50, 0) * Time.deltaTime);
		if(Movement.hasKey)	{
			level1PortalStatus = true;
		}
	}

	void playAudio()	{
		audio.PlayOneShot(transport, 0.2f);
	}

	void loadLevel1()	{
		SceneManager.LoadScene("Level 1");
	}

	void loadStartingArea()	{
		SceneManager.LoadScene("Starting Area");
	}

	void OnTriggerEnter(Collider other) {
			if(SceneManager.GetActiveScene().name == "Starting Area")	{
				playAudio();
				Invoke("loadLevel1", 2f);	
			}
			if((level1PortalStatus) && (SceneManager.GetActiveScene().name == "Level 1"))	{
				playAudio();
				Invoke("loadStartingArea", 2f);
			}

	}
}
