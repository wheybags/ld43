using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    public AudioClip soundEffect;
    public int Damage;
    public bool wiggling;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wiggling && collision.gameObject.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster>().TakeDamage(Damage);
        }
    }
}
