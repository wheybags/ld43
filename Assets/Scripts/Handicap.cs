using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handicap : MonoBehaviour {
    public UnityEngine.UI.Image blindnessL;
    public UnityEngine.UI.Image blindnessR;

    public bool leftEye = true;
    public bool rightEye = true;
    public bool legs = true;

    private Vector3 blindnessLDelta;
    private Vector3 blindnessRDelta;

    void Start() {
        blindnessLDelta = blindnessL.rectTransform.position - transform.position;
        blindnessRDelta = blindnessR.rectTransform.position - transform.position;
    }

    void Update () {
        blindnessL.rectTransform.position = transform.position + blindnessLDelta;
        blindnessR.rectTransform.position = transform.position + blindnessRDelta;

        blindnessL.enabled = !leftEye;
        blindnessR.enabled = !rightEye;
    }
}
