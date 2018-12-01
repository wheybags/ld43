using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    public int current = 3;
    public int maximum = 3;

    public Image[] images;
    public Sprite fullHeart;
    public Sprite emptyHeart;
	
	void Update () {
        for (int i = 0; i < images.Length; i++) {
            images[i].enabled = i < maximum;
            images[i].sprite = i < current ? fullHeart : emptyHeart;
        }
    }

    public void Add() {
        if (current < maximum) {
            current += 1;
        }
    }
}
