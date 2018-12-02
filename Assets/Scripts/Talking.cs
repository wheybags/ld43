using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talking : MonoBehaviour {
    public Canvas canvas;

    private Text text;
    private Button button;

    private int dialog = 0;

    private Handicap playerHandicap;
    private Health playerHealth;

    private void Start() {
        canvas.enabled = false;
        text = canvas.transform.Find("Text").gameObject.GetComponent<Text>();
        button = canvas.transform.Find("Button").gameObject.GetComponent<Button>();

        button.onClick.AddListener(UpdateDialog);
    }

    private void UpdateDialog() {
        switch (dialog) {
            case 0:
                text.text = "Hello, my good man! Would you be interested in a business proposal? I can greatly enhance your abilities, but I need a small favour in return...";
                break;
            case 1:
                text.text = "Okay then! I'll grant you one extra heart. Now, for my reward...";
                playerHealth.maximum++;
                break;
            case 2:
                text.text = "HAHAHA! I took your fucking LEG";
                playerHandicap.legs--;
                break;
            default:
                canvas.enabled = false;
                break;
        }
        dialog++;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            playerHandicap = collision.collider.GetComponent<Handicap>();
            playerHealth = collision.collider.GetComponent<Health>();
            canvas.enabled = true;
            UpdateDialog();
        }
    }
}
