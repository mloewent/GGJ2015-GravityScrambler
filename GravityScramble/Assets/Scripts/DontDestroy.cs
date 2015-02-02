using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

   void Awake()
   {
		if(Application.loadedLevelName != "credits" && Application.loadedLevelName != "StartScreen")
			DontDestroyOnLoad(gameObject);


   }

	// Update is called once per frame
	void Update () {
	
	}
}
