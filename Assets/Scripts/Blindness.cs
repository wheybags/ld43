using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour {
    public UnityEngine.UI.Image blindness;

    private Handicap handicap;
    public float blindnessOfffset = 12.0f;

    void Start() {
        handicap = GetComponent<Handicap>();
    }

    void Update() {
        if (handicap.eyes == 1) {
            blindness.enabled = true;
            bool facingLeft = GetComponent<Rigidbody2D>().velocity.x < 0.0f;
            blindness.rectTransform.position = transform.position + (facingLeft ? -1.0f : 1.0f) * new Vector3(blindnessOfffset, 0.0f, 0.0f);
        }
    }
}
