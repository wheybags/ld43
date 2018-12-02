using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedBox : MonoBehaviour {
    public int KeyID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// shine
	}
	
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Locked Box collision with player");
            if (collision.gameObject.GetComponent<PlayerInventory>().KeyIds.Contains(KeyID)) {
                this.gameObject.SetActive(false);
            }
        }
    }
}
