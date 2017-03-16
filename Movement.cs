using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour {

    Animator anime;
    public static float health = 100;
    public Slider healthBar;
    public float decreaseAmount = 2;
    public float damage = 1;
    bool underCover = false;
    bool isWalking = false;
    public static bool hasKey = false;
    public static bool inRange = false;
    public Text instruction;

    void Awake() {
        anime = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)	{
    	if(other.gameObject.CompareTag("key"))	{
            //hasKey = true;
            //instruction.gameObject.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("key")) {
            //hasKey = true;
            //instruction.gameObject.SetActive(false);

        }
    }

    void OnParticleCollision(GameObject other) {
        ReduceHealth();
        //Debug.Log("Hit");
    }

    // Use this for initialization
    void Start () {
    	health = 100;
    	damage = 1;
		decreaseAmount = 2;
    	hasKey = false;
		underCover = false;
    	isWalking = false;
       	InvokeRepeating("increaseDamage", 1, 1);
        //instruction.gameObject.SetActive(false);

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
            Invoke("loadLevel1", 3); 
        }
    }

    private void loadLevel1()	{
		SceneManager.LoadScene("Level 1");
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
        damage =+ (float)0.2;
    }


}
