<<<<<<< HEAD
﻿using System.Collections.Generic;
=======
﻿using System.Collections;
>>>>>>> origin/master
using UnityEngine;

namespace Assets.Scripts
{
   public class CharacterControl : MonoBehaviour {

      // Use this for initialization
      void Start ()
      {
         facingRight = true;
         CurrGravDirection = GravDirection.Down;
         rigidbody2D.AddRelativeForce(new Vector2(0, -gravityForce));
      }

      public GameObject greenShovel;
      public GameObject redShovel;
      public GameObject blueShovel;

      private bool hasRedShovel = false;
      private bool hasGreenShovel = false;
      private bool hasBlueShovel = false;
      private bool hasRedAxe = false;
      private bool hasGreenAxe = false;
      private bool hasBlueAxe = false;


      public Sprite[] sprites;
      public SpriteRenderer spriteChanger;
      public float gravityForce;
      public float jumpTime;
      private float jumpTimer = 0;
      public float jumpForce;
      private bool facingRight;
      private bool facingUp;
      private bool gravityVertical = true;
      private bool gravChanged = false;
      private int numJumps;
      public float speed;
      public int maxJumps;
      public AudioClip[] audioClip;
<<<<<<< HEAD

		public Animator player_anim;
		public Animator limbs_anim;


=======
	  private bool isDead = false;
>>>>>>> origin/master

      private enum GravDirection
      {
         Left,
         Right,
         Down,
         Up
      }

      private GravDirection CurrGravDirection;

      void FlipHorizontal()
      {
         // Switch the way the player is labelled as facing
         facingRight = !facingRight;

         // Multiply the player's x local scale by -1
         Vector3 theScale = transform.localScale;
         theScale.x *= -1;
         transform.localScale = theScale;
      }

      void FlipVertical()
      {
         // Switch the way the player is labelled as facing
         facingUp = !facingUp;

         // Multiply the player's x local scale by -1
         Vector3 theScale = transform.localScale;
<<<<<<< HEAD
         theScale.x *= -1;
=======
         theScale.y *= -1;
>>>>>>> origin/master
         transform.localScale = theScale;
      }

      private void ResetScale()
      {
         Vector3 theScale = transform.localScale;
         theScale.y = 1;
         theScale.x = 1;
         transform.localScale = theScale;
      }

      private void SetSpriteLeft()
      {
<<<<<<< HEAD
         //spriteChanger.sprite = sprites[1];
			player_anim.SetTrigger("gravLeft");
=======
         spriteChanger.sprite = sprites[1];
>>>>>>> origin/master
         ResetScale();
         FlipHorizontal();
         facingUp = true;
      }

      private void SetSpriteDown()
      {
         facingRight = true;
<<<<<<< HEAD
         //spriteChanger.sprite = sprites[0];
			player_anim.SetTrigger("gravDown");
=======
         spriteChanger.sprite = sprites[0];
>>>>>>> origin/master
         ResetScale();
      }

      private void SetSpriteRight()
      {
<<<<<<< HEAD
         //spriteChanger.sprite = sprites[1];

         ResetScale();
         FlipVertical();
         facingUp = false;
			player_anim.SetTrigger("gravRight");
		}

      private void SetSpriteUp()
      {
         //spriteChanger.sprite = sprites[0];
			player_anim.SetTrigger("gravUp");
         ResetScale();
         facingRight = true;
//         FlipVertical();
=======
         spriteChanger.sprite = sprites[1];
         ResetScale();
         FlipVertical();
         facingUp = false;
      }

      private void SetSpriteUp()
      {
         spriteChanger.sprite = sprites[0];
         ResetScale();
         facingRight = true;
         FlipVertical();
>>>>>>> origin/master
         FlipHorizontal();
      }

      bool IsGrounded()
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
<<<<<<< HEAD

         switch (CurrGravDirection)
         {
            case GravDirection.Down:
               rigidbody2D.AddForce(new Vector2(0, -gravityForce));
               break;

            case GravDirection.Left:
               rigidbody2D.AddForce(new Vector2(-gravityForce, 0));
               break;

            case GravDirection.Right:
			   //rigidbody2D.AddRelativeForce(new Vector2(0, -gravityForce));

               rigidbody2D.AddForce(new Vector2(gravityForce, 0));
               break;

            case GravDirection.Up:
               rigidbody2D.AddForce(new Vector2(0, gravityForce));
               break;
         }

         if (Input.GetKey(KeyCode.A) && gravityVertical)
         {
            if (facingRight)
            {
               FlipHorizontal();
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
				limbs_anim.SetBool("walking", true);
         }else
         if (Input.GetKey(KeyCode.D) && gravityVertical)
=======
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

         if (Input.GetKey(KeyCode.A) && gravityVertical && !isDead)
         {
            if (facingRight)
            {
               FlipHorizontal();               
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
         }
         if (Input.GetKey(KeyCode.D) && gravityVertical && !isDead)
>>>>>>> origin/master
         {
            if (!facingRight)
            {
               FlipHorizontal();
            }
            transform.position += Vector3.right * speed * Time.deltaTime;
<<<<<<< HEAD
				limbs_anim.SetBool("walking", true);
				
         }else
         if (Input.GetKey(KeyCode.W) && !gravityVertical)
=======
         }
         if (Input.GetKey(KeyCode.W) && !gravityVertical && !isDead)
>>>>>>> origin/master
         {
            if (!facingUp)
            {
               FlipVertical();
            }
            transform.position += Vector3.up * speed * Time.deltaTime;
<<<<<<< HEAD
				limbs_anim.SetBool("walking", true);
         }else
         if (Input.GetKey(KeyCode.S) && !gravityVertical)
=======
         }
         if (Input.GetKey(KeyCode.S) && !gravityVertical && !isDead)
>>>>>>> origin/master
         {
            if (facingUp)
            {
               FlipVertical();
            }
            transform.position += Vector3.down * speed * Time.deltaTime;
<<<<<<< HEAD
				limbs_anim.SetBool("walking", true);
         }else
				limbs_anim.SetBool("walking", false);


         //Jump Control
         if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && numJumps < maxJumps)
         {
				playSound(1);
            numJumps++;
            jumpTimer = Time.time + jumpTime;
				//anim.SetTrigger("jumping");
=======
         }

         //Jump Control
         if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && numJumps < maxJumps && !isDead)
         {
			playSound(1);
            numJumps++;
            jumpTimer = Time.time + jumpTime;
>>>>>>> origin/master
    
         }

         //Change Grav Direction
<<<<<<< HEAD
         if (Input.GetKey(KeyCode.UpArrow) && CurrGravDirection != GravDirection.Up && !gravChanged)
         {
				playSound(0);
=======
         if (Input.GetKey(KeyCode.UpArrow) && CurrGravDirection != GravDirection.Up && !gravChanged && !isDead)
         {
			playSound(0);
>>>>>>> origin/master
            SetSpriteUp();

            gravChanged = true;
            CurrGravDirection = GravDirection.Up;
            rigidbody2D.velocity = Vector2.zero;
            gravityVertical = true;
<<<<<<< HEAD

         }
         if (Input.GetKey(KeyCode.DownArrow) && CurrGravDirection != GravDirection.Down && !gravChanged)
         {
				playSound(0);
=======
         }
         if (Input.GetKey(KeyCode.DownArrow) && CurrGravDirection != GravDirection.Down && !gravChanged && !isDead)
         {
			playSound(0);
>>>>>>> origin/master
            SetSpriteDown();

            gravChanged = true;
            rigidbody2D.velocity = Vector2.zero;
            CurrGravDirection = GravDirection.Down;
            gravityVertical = true;
<<<<<<< HEAD

         }
         if (Input.GetKey(KeyCode.LeftArrow) && CurrGravDirection != GravDirection.Left && !gravChanged)
=======
         }
         if (Input.GetKey(KeyCode.LeftArrow) && CurrGravDirection != GravDirection.Left && !gravChanged && !isDead)
>>>>>>> origin/master
         {
				playSound(0);
            SetSpriteLeft();

            gravChanged = true;
            rigidbody2D.velocity = Vector2.zero;
            CurrGravDirection = GravDirection.Left;
            gravityVertical = false;
         }
<<<<<<< HEAD
         if (Input.GetKey(KeyCode.RightArrow) && CurrGravDirection != GravDirection.Right && !gravChanged)
         {
				playSound(0);
            SetSpriteRight();
				facingUp = false;

=======
         if (Input.GetKey(KeyCode.RightArrow) && CurrGravDirection != GravDirection.Right && !gravChanged && !isDead)
         {
				playSound(0);
            SetSpriteRight();
>>>>>>> origin/master

            gravChanged = true;
            rigidbody2D.velocity = Vector2.zero;
            CurrGravDirection = GravDirection.Right;
            gravityVertical = false;
<<<<<<< HEAD

=======
>>>>>>> origin/master
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

         if (IsGrounded() && jumpTimer < Time.time)
         {
            if (gravChanged)
            {
               gravChanged = false;            
            }
            numJumps = 0;
<<<<<<< HEAD
//				anim.SetTrigger("landed");
=======
>>>>>>> origin/master
         }
      }

      void OnCollisionEnter2D(Collision2D collider)
      {
         if (collider.gameObject.tag == "spikes")
         {
<<<<<<< HEAD
				playSound(2);
            Die();
			
				
         }
         if (collider.gameObject.tag == "levelup")
         {
				playSound(3);
            LevelUp();
			
				
=======
			playSound(2);
		    StartCoroutine (Die ());
         }
         if (collider.gameObject.tag == "levelup")
         {
			playSound(3);
			StartCoroutine (LevelUp ());
>>>>>>> origin/master
         }

         //Keys
         if (collider.gameObject.tag == "redshovel")
         {
            redShovel.SetActive(true);
            hasRedShovel = true;
            Destroy(collider.gameObject);
            playSound(4);
         }
         if (collider.gameObject.tag == "greenshovel")
         {
            greenShovel.SetActive(true);
            hasGreenShovel = true;
            Destroy(collider.gameObject);
            playSound(4);
         }
         if (collider.gameObject.tag == "blueshovel")
         {
            hasBlueShovel = true;
            blueShovel.SetActive(true);
            Destroy(collider.gameObject);
            playSound(4);
         }
         if (collider.gameObject.tag == "redaxe")
         {
            hasRedAxe = true;
            Destroy(collider.gameObject);
         }
         if (collider.gameObject.tag == "greenaxe")
         {
            hasGreenAxe = true;
            Destroy(collider.gameObject);
         }
         if (collider.gameObject.tag == "blueaxe")
         {
            hasBlueAxe = true;
            Destroy(collider.gameObject);
         }

         //Doors
         if (collider.gameObject.tag == "reddirt")
         {
            if (hasRedShovel)
            {
               hasRedShovel = false;
               redShovel.SetActive(false);

               Destroy(collider.gameObject);
            }
         }
         if (collider.gameObject.tag == "greendirt")
         {
            if (hasGreenShovel)
            {
               greenShovel.SetActive(false);

               hasGreenShovel = false;
               Destroy(collider.gameObject);
            }
         }
         if (collider.gameObject.tag == "bluedirt")
         {
            if (hasBlueShovel)
            {
               blueShovel.SetActive(false);

               hasBlueShovel= false;
               Destroy(collider.gameObject);
            }
         }
         if (collider.gameObject.tag == "redtree")
         {
            if (hasRedAxe)
            {
               hasRedAxe = false;
               Destroy(collider.gameObject);
            }
         }
         if (collider.gameObject.tag == "greentree")
         {
            if (hasGreenAxe)
            {
               hasGreenAxe = false;
               Destroy(collider.gameObject);
            }
         }
         if (collider.gameObject.tag == "bluetree")
         {
            if (hasBlueAxe)
            {
               hasBlueAxe = false;
               Destroy(collider.gameObject);
            }
         }
      }

<<<<<<< HEAD
      public void Die()
      {
         Application.LoadLevel(Application.loadedLevel);
      }

      public void LevelUp()
      {
         Application.LoadLevel(Application.loadedLevel + 1);
=======
	  public IEnumerator Die()
      {
		isDead = true;
		yield return new WaitForSeconds (2.0f);
        Application.LoadLevel(Application.loadedLevel);
		isDead = false;
      }

      public IEnumerator LevelUp()
      {
		 isDead = true;
		 yield return new WaitForSeconds (2.0f);
         Application.LoadLevel(Application.loadedLevel + 1);
		 isDead = false;
>>>>>>> origin/master
      }

      void playSound(int clip) 
      {
         audio.clip = audioClip[clip];
         audio.Play();
      }
   }
}
