using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class pickup : MonoBehaviour {
    public int increaseAmount = 5;
    void OnTriggerEnter(Collider other) {

        Movement.health += increaseAmount;
        Destroy(this.gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
