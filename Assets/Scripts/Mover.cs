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

        Vector2 position = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - position).normalized;

        Debug.DrawLine(position, position + direction * 2, Color.red, 0, false);
    }
}
