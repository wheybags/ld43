using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    public List<int> KeyIds = new List<int>();
    public Image KeyImage;
    
    
	void Update () {
        KeyImage.enabled = KeyIds.Count >= 1;
    }
}
