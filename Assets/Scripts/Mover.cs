using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed = 4.0f;

    public GameObject weapon = null;
    public GameObject defaultWeapon;

    private new Rigidbody2D rigidbody;
    private Handicap handicap;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        handicap = GetComponent<Handicap>();

        SetWeapon(defaultWeapon);
    }

    private void SetWeapon(GameObject newWeapon)
    {
        weapon = Instantiate(newWeapon);
        weapon.transform.parent = transform;
        weapon.transform.position = new Vector2(0, weapon.GetComponent<BoxCollider2D>().bounds.max.y);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float actualSpeed = handicap.legs ? speed : speed / 12.0f;

        rigidbody.velocity = new Vector2(
            Mathf.Lerp(0, Input.GetAxis("Horizontal") * actualSpeed, 0.8f),
            Mathf.Lerp(0, Input.GetAxis("Vertical")   * actualSpeed, 0.8f)
        );

        Vector2 position = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - position).normalized;

        Debug.DrawLine(position, position + direction * 2, Color.red, 0, false);
    }
}
