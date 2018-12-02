using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {
    public int Hearts;
    public int hurtingTicks = 0;

    private SpriteRenderer spriteRenderer;

    void Start () {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    
    void FixedUpdate ()
    {
        if (hurtingTicks > 0)
        {
            if (hurtingTicks < 40)
                spriteRenderer.color = Color.white;

            int interval = 15;
            if (hurtingTicks % 15 > interval / 2)
                spriteRenderer.enabled = false;
            else
                spriteRenderer.enabled = true;

            if (hurtingTicks > 0)
                hurtingTicks--;
        }
        else
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = Color.white;
        }

        Vector2 targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 myPosition = transform.position;
        GetComponent<Rigidbody2D>().velocity = (targetPosition - myPosition).normalized * 1.0f;
    }

    public void TakeDamage(int damage)
    {
        if (hurtingTicks != 0)
            return;

        Hearts -= damage;
        if (Hearts <= 0)
        {
            gameObject.SetActive(false);
        }

        hurtingTicks = 50;
        spriteRenderer.color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Health>().current -= 1;
        }
    }
}
