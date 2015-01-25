using UnityEngine;
using System.Collections;

public class beMoving : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   gameObject.rigidbody2D.AddForce(new Vector2(-150, -20));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
