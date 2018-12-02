using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class TalkingItem
{
    public string text;
    public int increaseMaximumHealth;
    public int removeLegs;
    public int removeEyes;
}

public class Talking : MonoBehaviour {
    public List<TalkingItem> Items;

    private Text text;
    private Button button;

    private int dialog;

    private Canvas canvas;
    private Handicap playerHandicap;
    private Health playerHealth;

    private void Start()
    {
        canvas = GameObject.Find("DialogCanvas").GetComponent<Canvas>();
        canvas.enabled = false;
        text = canvas.transform.Find("Text").gameObject.GetComponent<Text>();
        button = canvas.transform.Find("Button").gameObject.GetComponent<Button>();
    }

    private void UpdateDialog(bool advance) {
        if (dialog >= 0 && dialog < Items.Count)
        {
            var item = Items[dialog];
            text.text = item.text;
            playerHealth.maximum += item.increaseMaximumHealth;
            playerHandicap.legs -= item.removeLegs;
            playerHandicap.eyes -= item.removeEyes;
        }
        else
        {
            canvas.enabled = false;
        }
        if (advance)
            dialog++;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.CompareTag("Player")) {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => UpdateDialog(true));
            playerHandicap = collision.collider.GetComponent<Handicap>();
            playerHealth = collision.collider.GetComponent<Health>();
            canvas.enabled = true;
            UpdateDialog(false);
        }
    }
}
