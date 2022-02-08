using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetroidvaniaProject
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] protected float jumpForce;
        [SerializeField] protected float distanceToCollider;
        [SerializeField] protected LayerMask collisionLayer;

        private bool isJumping;


        protected virtual void FixedUpdate()
        {
            Jumping();
        }

        protected virtual void Jumping()
        {
            if(isJumping)
            {
               // rb2d.Addforce(Vector2.up * jumpForce);
            }
        }

        // Update is called once per frame
        protected virtual void Update()
        {
           // JumpPressed();
        }

        protected virtual bool JumpPresses()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
                return true;
            }
                

            return false;
        }

    }
}



