using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour
{
   public GameObject SoundGameObject;
   public GameObject[] scenes;
   private bool faded1 = false;
   private bool faded2 = false;
   private bool faded3 = false;
   private bool faded4 = false;
   private bool movingScene1 = false;
   private bool movingScene2 = false;
   private bool movingScene15 = false;
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
         SoundGameObject.audio.volume = .5f;
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
         SoundGameObject.audio.volume = 1f;

         faded4 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
      }



      if (Time.timeSinceLevelLoad > 3.0f && !movingScene1)
      {
         movingScene1 = true;
         scenes[1].rigidbody2D.AddForce(new Vector2(1450, 0));
      }


      //Meteor Scene
      if (Time.timeSinceLevelLoad > 6.0f && !movingScene15)
      {
         movingScene15 = true;
         //scenes[4].gameObject.SetActive(false);
         scenes[4].rigidbody2D.AddForce(new Vector2(0, -800));
      }


      if (Time.timeSinceLevelLoad > 8.8f && !movingScene2)
      {
         movingScene1 = true;
         scenes[2].rigidbody2D.AddForce(new Vector2(0, 300));
      }





      if (Time.timeSinceLevelLoad > 11.5f && faded1)
      {
         SoundGameObject.audio.volume = .75f;
         faded1 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .25f);
      }
      if (Time.timeSinceLevelLoad > 11.7f && faded2)
      {
         SoundGameObject.audio.volume = .5f;
         faded2 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
      }
      if (Time.timeSinceLevelLoad > 11.9f && faded3)
      {
         SoundGameObject.audio.volume = .35f;
         faded3 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .75f);
      }
      if (Time.timeSinceLevelLoad > 12.1f && faded4)
      {
         SoundGameObject.audio.volume = .15f;
         faded4 = true;
         scenes[0].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
      }

	   if (Time.timeSinceLevelLoad > 13f)
	   {
         SoundGameObject.audio.volume = .05f;
	      
	   }

	   if (Time.timeSinceLevelLoad > 15.4f)
	   {
	      Application.LoadLevel(Application.loadedLevel + 1);
	   }
	}
}
