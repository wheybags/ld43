using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartPosition : MonoBehaviour
{

	public Transform FirstRoom;
	
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(FirstRoom.position.x, FirstRoom.position.y, -10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
