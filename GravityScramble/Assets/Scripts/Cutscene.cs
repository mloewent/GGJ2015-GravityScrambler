using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour
{
   public GameObject[] scenes;
   private bool faded1 = false;
   private bool faded2 = false;
   private bool faded3 = false;
   private bool faded4 = false;
   private bool movingScene1 = false;
   private bool movingScene2 = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      if (Time.timeSinceLevelLoad > 0.1f && !faded1)
      {
         faded1 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .75f);
      }
      if (Time.timeSinceLevelLoad > 0.2f && !faded2)
      {
         faded2 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
      }
      if (Time.timeSinceLevelLoad > 0.4f && !faded3)
      {
         faded3 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
      }
      if (Time.timeSinceLevelLoad > 0.4f && !faded4)
      {
         faded4 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
      }




      if (Time.timeSinceLevelLoad > 4.83f && !movingScene1)
      {
         movingScene1 = true;
         scenes[1].rigidbody2D.AddForce(new Vector2(1050, 0));
      }




      if (Time.timeSinceLevelLoad > 9f && !movingScene2)
      {
         movingScene1 = true;
         scenes[2].rigidbody2D.AddForce(new Vector2(0, 300));
      }





      if (Time.timeSinceLevelLoad > 13f && faded1)
      {
         faded1 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
      }
      if (Time.timeSinceLevelLoad > 13.2f && faded2)
      {
         faded2 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
      }
      if (Time.timeSinceLevelLoad > 13.4f && faded3)
      {
         faded3 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .75f);
      }
      if (Time.timeSinceLevelLoad > 13.6f && faded4)
      {
         faded4 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
      }
	   if (Time.timeSinceLevelLoad > 15f)
	   {
	      Application.LoadLevel(Application.loadedLevel + 1);
	   }
	}
}
