using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    public int KeyID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// shine
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerInventory>().KeyIds.Add(KeyID);
            this.gameObject.SetActive(false);
        }
    }
}
