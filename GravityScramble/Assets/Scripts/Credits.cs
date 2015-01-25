using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      if (Input.anyKey && Time.timeSinceLevelLoad > 1.5f)
      {
         Application.LoadLevel(0);
      }
	}
}
