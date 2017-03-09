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
    public static float health = 100;
    public Slider healthBar;
    public float decreaseAmount = 1;
    public float damage = 1;
    bool underCover = false;
    bool isWalking = false;

    void Awake() {
        anime = GetComponent<Animator>();
    }

    void OnParticleCollision(GameObject other) {
    	print("hit");
        ReduceHealth();
    }

    // Use this for initialization
    void Start () {
       InvokeRepeating("increaseDamage", 1, 1);
	}
	
	void Update () {

        Turning();
        Walking();
        Move();
        Jump();
    }

    private void ReduceHealth() {
        health = health - (decreaseAmount * damage);
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

    private void increaseDamage() {
        damage =+ (float)0.1;
    }


}
