using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    void Start () {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    void FixedUpdate ()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        Vector2 targetPosition = player.GetComponent<BoxCollider2D>().bounds.center;


        Vector2 myPosition = transform.position;

        Debug.DrawLine(myPosition, targetPosition, Color.green);


        GetComponent<Rigidbody2D>().velocity = (targetPosition - myPosition).normalized * 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player") {
        //    collision.gameObject.GetComponent<Health>().current -= 1;
        //}
    }
}
