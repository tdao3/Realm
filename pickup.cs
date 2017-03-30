using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(BoxCollider))]
public class pickup : MonoBehaviour {
    public int increaseAmount = 5;
    private bool inRange;
    private KeyCode[] sequence = new KeyCode[]{KeyCode.Z, KeyCode.X, KeyCode.C};
    private int sequenceIndex;
    public DialogBoxController dialogBoxController;

    void OnTriggerEnter(Collider other) {
    	inRange = true;
    	if(!(this.gameObject.tag == "key"))	{
        	Movement.health += increaseAmount;
			Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "player")	{
        	dialogBoxController.EnableDialogBox();
        }
    }

    void OnTriggerExit(Collider other)	{
    	inRange = false;
		if(other.gameObject.tag == "player")	{
        	dialogBoxController.DisableDialogBox();
        }
    }


    public void playerInRange() {
        if (inRange) {
            Movement.inRange = true;
            if (Input.GetKeyDown(sequence[sequenceIndex])) {
                if (++sequenceIndex == sequence.Length) {
                    sequenceIndex = 0;
                    Destroy(this.gameObject);
                    Movement.hasKey = true;
                }
            }
            else if (Input.anyKeyDown) {
                sequenceIndex = 0;
                Movement.hasKey = false;
            }
        }
    }

	// Use this for initialization
	void Start () {
		inRange = false;
		dialogBoxController = FindObjectOfType<DialogBoxController>();
	}
	
	// Update is called once per frame
	void Update () {
        playerInRange();
    }
}
