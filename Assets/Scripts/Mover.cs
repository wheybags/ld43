using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed = 4.0f;

    void Update () {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var force = new Vector2(horizontal, vertical);

        GetComponent<Rigidbody2D>().AddForce(force * speed);
    }
}
