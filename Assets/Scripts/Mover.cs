using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed = 4.0f;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(
            Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical")   * speed, 0.8f)
        );
    }
}
