using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class ObjectCreator : MonoBehaviour {

   public GameObject[] clouds;

   // Use this for initialization
   void Start()
   {
      InvokeRepeating("CreateObstacle", 1f, 3.5f);
   }

   void CreateObstacle()
   {
      var rand = new System.Random();
      Instantiate(clouds[rand.Next(0, clouds.Length - 1)]);
   }
}
