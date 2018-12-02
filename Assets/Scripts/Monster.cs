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

        Vector2 targetPosition = player.GetComponent<Collider2D>().bounds.center;


        Vector2 myPosition = transform.position;

        Debug.DrawLine(myPosition, targetPosition, Color.green);

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(myPosition);
        
        if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1) {
            GetComponent<Rigidbody2D>().velocity = (targetPosition - myPosition).normalized * 1.0f;
        } else {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Player") {
        //    collision.gameObject.GetComponent<Health>().current -= 1;
        //}
    }
}
