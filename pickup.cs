using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(BoxCollider))]
public class pickup : MonoBehaviour {
    public float increaseAmount = 25f;
    private bool inRange;
    private KeyCode[] sequence = new KeyCode[]{ KeyCode.Alpha5,
         KeyCode.Alpha1,
         KeyCode.Alpha1,
         KeyCode.Alpha0,
         KeyCode.Alpha9};


    private int sequenceIndex;
    public DialogBoxController dialogBoxController;
    public Movement movement; 
	public AudioClip taken;
	AudioSource audio;

    void OnTriggerEnter(Collider other) {
    	inRange = true;
    	if(!(this.gameObject.tag == "key") && other.tag == "Player")	{
            
            playAudio();
			Destroy(this.gameObject, taken.length);
        }
        if(other.gameObject.tag == "Player" && this.tag == "key")	{
        	dialogBoxController.EnableDialogBox();
        }
    }

    void OnTriggerExit(Collider other)	{
    	inRange = false;
		if(other.gameObject.tag == "Player")	{
            
                dialogBoxController.DisableDialogBox();
            
        	
        }
    }

	void playAudio()	{
		audio.PlayOneShot(taken, 0.2f);
	}

    public void playerInRange() {
        if (inRange) {
            Movement.inRange = true;
            if(!Movement.hasKey)	{
	            if (Input.GetKeyDown(sequence[sequenceIndex])) {
	                if (++sequenceIndex == sequence.Length) {
	                    sequenceIndex = 0;
						Movement.hasKey = true;
						KeySoundController.canPlay = true;
						dialogBoxController.DisableDialogBox();
	                    Destroy(this.gameObject, KeySoundController.audioLength);
	                    //dialogBoxController.EnableDialogBox();


	                }
	            }
	            else if (Input.anyKeyDown) {
	                sequenceIndex = 0;
	                Movement.hasKey = false;
	            }
        	}
        }
    }

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		inRange = false;
		dialogBoxController = FindObjectOfType<DialogBoxController>();
	}
	
	// Update is called once per frame
	void Update () {
        playerInRange();
    }
}
