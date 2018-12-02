using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int maximum = 3;

    public Image[] images;
    public Sprite fullHeart;
    public Sprite emptyHeart;
	
	void Update () {
        for (int i = 0; i < images.Length; i++) {
            images[i].enabled = i < maximum;
            images[i].sprite = i < GetComponent<DamageHandler>().Hearts ? fullHeart : emptyHeart;
        }
    }

    public void Add() {
        if (GetComponent<DamageHandler>().Hearts < maximum) {
            GetComponent<DamageHandler>().Hearts += 1;
        }
    }
}
