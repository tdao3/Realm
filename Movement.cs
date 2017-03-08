using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour {

    Animator anime;
    public static int health = 100;
    public Slider healthBar;

    bool underCover = false;
    bool isWalking = false;

    void Awake() {
        anime = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
        InvokeRepeating("ReduceHealth", 1, 1);
	}
	
	void Update () {

        Turning();
        Walking();
        Move();
        Jump();
    }

    private void ReduceHealth() {
        health = health - 20;
        healthBar.value = health;
        if (health <= 0) {
            anime.SetTrigger("Death");
        }
    }

    private void Turning() {
        anime.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)){
            anime.SetTrigger("Jump");
        }
    }

    private void Walking() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isWalking =! isWalking;
            anime.SetBool("Walk", isWalking);
        }
    }
    private void Move() {
        anime.SetFloat("Forward", Input.GetAxis("Vertical"));
    }



}
