using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFade : MonoBehaviour {
    public Renderer renderer;
    public float timer = 3f;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;

        if (timer >= 0) {
            Color color = renderer.material.color;
            color.a -= 0.1f * Time.deltaTime;
            renderer.material.color = color;

        }
        if (timer <= 0) {
            Destroy(gameObject);
        }
	}
}
