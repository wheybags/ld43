using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
	void Update () {
        GetComponent<SpriteRenderer>().flipX = GetComponent<Rigidbody2D>().velocity.x > 0.0f;
	}
}
