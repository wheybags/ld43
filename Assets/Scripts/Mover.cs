using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public float speed = 4.0f;

    public GameObject weapon;
    public GameObject defaultWeapon;

    private new Rigidbody2D rigidbody;
    private Handicap handicap;
    private AudioSource audioSource;
    private Health health;

    private float timeOut;

    private float wiggleAngle;
    private float wiggleSign = -1;

    public AudioClip eatingSound;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;

        handicap = GetComponent<Handicap>();
        audioSource = GetComponent<AudioSource>();
        health = GetComponent<Health>();

        SetWeapon(defaultWeapon);
    }

    private void SetWeapon(GameObject newWeapon)
    {
        weapon = Instantiate(newWeapon);
        weapon.transform.parent = transform;
        weapon.transform.position = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        if (timeOut > 0.0f) {
            timeOut -= Time.deltaTime;
            if (timeOut < 0.0f) {
                timeOut = 0.0f;
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float actualSpeed = speed;

        if (handicap.legs == 1) {
            var vec = Quaternion.Euler(0.0f, 0.0f, Random.Range(-45, 45)) * new Vector2(horizontal, vertical);
            horizontal = vec.x;
            vertical = vec.y;
        }
        if (handicap.legs == 0) {
            actualSpeed = speed / 12.0f;
        }

        if (timeOut == 0.0f) {
            rigidbody.velocity = new Vector2(
                Mathf.Lerp(0, horizontal * actualSpeed, 0.8f),
                Mathf.Lerp(0, vertical * actualSpeed, 0.8f)
            );
        }
    }

    void Update()
    {
        weapon.GetComponent<MeleeWeapon>().wiggling = Input.GetAxisRaw("Fire1") != 0;

        if (weapon.GetComponent<MeleeWeapon>().wiggling && !audioSource.isPlaying) {
            audioSource.PlayOneShot(weapon.GetComponent<MeleeWeapon>().soundEffect);
        }

        Vector2 position = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * (180 / Mathf.PI) - 90;

        if (weapon.GetComponent<MeleeWeapon>().wiggling)
        {
            if (wiggleAngle > 20 || wiggleAngle < -20)
                wiggleSign = -wiggleSign;

            wiggleAngle += 7 * wiggleSign;

            angle += wiggleAngle;
        }
        else
        {
            wiggleAngle = 0;
        }

        weapon.transform.position = transform.position;
        weapon.transform.rotation = Quaternion.Euler(0, 0, angle);

        Debug.DrawLine(position, position + direction * 2, Color.red, 0, false);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Food")) {
            col.gameObject.SetActive(false);
            audioSource.PlayOneShot(eatingSound);
            health.Add();
            if (!handicap.teeth) {
                timeOut = 3.0f;
            }
        }
    }
}
