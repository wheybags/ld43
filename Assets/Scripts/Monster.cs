using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public int Hearts;
    public int hurtingTicks = 0;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
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
}
