﻿using UnityEngine;
using System.Collections;

public class PistolMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize (); 
		
		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; // find angle in degrees. 
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ);
	}
}
