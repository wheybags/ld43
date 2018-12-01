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
        if (hurtingTicks > 0 && hurtingTicks % 5 == 0)
            spriteRenderer.enabled = false;
        else
            spriteRenderer.enabled = true;

        if (hurtingTicks > 0)
            hurtingTicks--;
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
    }
}
