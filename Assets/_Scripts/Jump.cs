using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetroidvaniaProject
{
    public class Jump : Abilities
    {
        [SerializeField] protected int maxJump;
        [SerializeField] protected float jumpForce;
        [SerializeField] protected float distanceToCollider;
        [SerializeField] protected LayerMask collisionLayer;

        private bool isJumping;
        private int numberOfJumpsRemaining;


        protected virtual void FixedUpdate()
        {
            Jumping();
            GroundCheck();
        }
        
        protected virtual void Jumping()
        {
            if (!character.isGrounded)
            {
                isJumping = false;
                return;
            }

            if (isJumping)
            {
               rb2d.AddForce(Vector2.up * jumpForce);
               isJumping = false;
            }
        }
       
        // Update is called once per frame
        protected virtual void Update()
        {
           JumpPressed();
        }

        protected virtual bool JumpPressed()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                return true;
            }

            else
                return false;
        }

        protected virtual void GroundCheck()
        {
            if(CollisionCheck(Vector2.down, distanceToCollider, collisionLayer))
            {
                character.isGrounded = true;
            }

            else
                character.isGrounded = false;
        }
    }
}



