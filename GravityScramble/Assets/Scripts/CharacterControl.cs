using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
   public class CharacterControl : MonoBehaviour {

      // Use this for initialization
      void Start () {
         CurrGravDirection = GravDirection.Down;
         rigidbody2D.AddRelativeForce(new Vector2(0, -gravityForce));
      }

      public float gravityForce;
      public float jumpTime;
      private float jumpTimer = 0;
      public float jumpForce;
      private bool gravityVertical = true;
      private bool gravChanged = false;
      private int numJumps;
      public float speed;
      public int maxJumps;

      private enum GravDirection
      {
         Left,
         Right,
         Down,
         Up
      }

      private GravDirection CurrGravDirection;

      bool isGrounded()
      {
         switch (CurrGravDirection)
         {
            case GravDirection.Down:
               return Physics2D.Raycast(transform.position, Vector3.down, .8f, 1 << LayerMask.NameToLayer("ground"));

            case GravDirection.Left:
               return Physics2D.Raycast(transform.position, Vector3.left, 1.2f, 1 << LayerMask.NameToLayer("ground"));

            case GravDirection.Right:
               return Physics2D.Raycast(transform.position, Vector3.right, .8f, 1 << LayerMask.NameToLayer("ground"));

            case GravDirection.Up:
               return Physics2D.Raycast(transform.position, Vector3.up, .8f, 1 << LayerMask.NameToLayer("ground"));
         }

         return true;
      }

      void Update()
      {
         switch (CurrGravDirection)
         {
            case GravDirection.Down:
               rigidbody2D.AddRelativeForce(new Vector2(0, -gravityForce));
               break;

            case GravDirection.Left:
               rigidbody2D.AddRelativeForce(new Vector2(-gravityForce, 0));
               break;

            case GravDirection.Right:
               rigidbody2D.AddRelativeForce(new Vector2(gravityForce, 0));
               break;

            case GravDirection.Up:
               rigidbody2D.AddRelativeForce(new Vector2(0, gravityForce));
               break;
         }

         if (Input.GetKey(KeyCode.A) && gravityVertical)
         {
            transform.position += Vector3.left * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.D) && gravityVertical)
         {
            transform.position += Vector3.right * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.W) && !gravityVertical)
         {
            transform.position += Vector3.up * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.S) && !gravityVertical)
         {
            transform.position += Vector3.down * speed * Time.deltaTime;
         }

         //Jump Control
         if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && numJumps < maxJumps)
         {
            numJumps++;
            jumpTimer = Time.time + jumpTime;
            //switch (CurrGravDirection)
            //{
            //   case GravDirection.Down:
            //      transform.position += Vector3.up * jumpForce * Time.deltaTime;
            //      break;

            //   case GravDirection.Left:
            //      transform.position += Vector3.right * jumpForce * Time.deltaTime;
            //      break;

            //   case GravDirection.Right:
            //      transform.position += Vector3.left * jumpForce * Time.deltaTime;
            //      break;

            //   case GravDirection.Up:
            //      transform.position += Vector3.down * jumpForce * Time.deltaTime;
            //      break;
            //}
         }

         //Change Grav Direction
         if (Input.GetKey(KeyCode.UpArrow) && CurrGravDirection != GravDirection.Up && !gravChanged)
         {
            gravChanged = true;
            CurrGravDirection = GravDirection.Up;
            rigidbody2D.velocity = Vector2.zero;
            gravityVertical = true;
         }
         if (Input.GetKey(KeyCode.DownArrow) && CurrGravDirection != GravDirection.Down && !gravChanged)
         {
            gravChanged = true;
            rigidbody2D.velocity = Vector2.zero;
            CurrGravDirection = GravDirection.Down;
            gravityVertical = true;
         }
         if (Input.GetKey(KeyCode.LeftArrow) && CurrGravDirection != GravDirection.Left && !gravChanged)
         {
            gravChanged = true;
            rigidbody2D.velocity = Vector2.zero;
            CurrGravDirection = GravDirection.Left;
            gravityVertical = false;
         }
         if (Input.GetKey(KeyCode.RightArrow) && CurrGravDirection != GravDirection.Right && !gravChanged)
         {
            gravChanged = true;
            rigidbody2D.velocity = Vector2.zero;
            CurrGravDirection = GravDirection.Right;
            gravityVertical = false;
         }
      
         //Apply force if isJumping
         if (numJumps > 0 && jumpTimer > Time.time && !gravChanged)
         {
            switch (CurrGravDirection)
            {
               case GravDirection.Down:
                  transform.position += Vector3.up * jumpForce * Time.deltaTime;
                  break;

               case GravDirection.Left:
                  transform.position += Vector3.right * jumpForce * Time.deltaTime;
                  break;

               case GravDirection.Right:
                  transform.position += Vector3.left * jumpForce * Time.deltaTime;
                  break;

               case GravDirection.Up:
                  transform.position += Vector3.down * jumpForce * Time.deltaTime;
                  break;
            }
         }

         if (isGrounded() && jumpTimer < Time.time)
         {
            if (gravChanged)
            {
               gravChanged = false;            
            }
            numJumps = 0;
         }
      }

      void OnCollisionEnter2D(Collision2D Collider)
      {
         if (Collider.gameObject.tag == "spikes")
         {
            Die();
         }
      }

      public void Die()
      {
         Application.LoadLevel(Application.loadedLevel);
      }
   }
}
