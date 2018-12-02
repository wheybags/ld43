using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DamageHandler : MonoBehaviour
{
    public int Hearts;
    public string damagedByTag;

    public int hurtingTicks = 0;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
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

    private void CollideWith(GameObject obj)
    {
        if (obj.tag == damagedByTag)
        {
            if (obj.GetComponent<MeleeWeapon>())
            {
                MeleeWeapon weapon = obj.GetComponent<MeleeWeapon>();
                if (weapon.wiggling)
                    TakeDamage(weapon.Damage);
            }
            else
            {
                TakeDamage(1);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CollideWith(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CollideWith(collision.gameObject);
    }
}
