using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    public List<int> KeyIds = new List<int>();
    public GameObject KeySprite;
    
    
	void Update () {
        KeySprite.SetActive(KeyIds.Count >= 1);
    }
}
