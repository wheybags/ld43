using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindness : MonoBehaviour {
    public UnityEngine.UI.Image blindnessL;
    public UnityEngine.UI.Image blindnessR;

    private Vector3 blindnessLDelta;
    private Vector3 blindnessRDelta;

    private Handicap handicap;

    void Start() {
        handicap = GetComponent<Handicap>();

        blindnessLDelta = blindnessL.rectTransform.position - transform.position;
        blindnessRDelta = blindnessR.rectTransform.position - transform.position;
    }

    void Update() {
        blindnessL.rectTransform.position = transform.position + blindnessLDelta;
        blindnessR.rectTransform.position = transform.position + blindnessRDelta;

        blindnessL.enabled = !handicap.leftEye;
        blindnessR.enabled = !handicap.rightEye;
    }
}
