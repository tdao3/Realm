using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 50, 0) * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		SceneManager.LoadScene("Level 1");
	}
}
