﻿using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      if (Input.anyKey && Time.timeSinceLevelLoad > 3)
      {
         Application.LoadLevel(0);
      }
	}
}
