using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetroidvaniaProject
{
    public class HorizontalMovement : Abilities
    {
        [SerializeField] private float timeTillMaxSpeed;
        [SerializeField] private float maxSpeed;
        
        private float currentSpeed;
        private float acceleration;
        private float horizontalInput;
        private float runTime;

        protected override void Initialization()
        {
            base.Initialization();
        }

        protected virtual void FixedUpdate()
        {
            Move();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            MovementPressed();
        }


        protected virtual bool MovementPressed()
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                horizontalInput = Input.GetAxis("Horizontal");
                return true;
            }
            
            return false;
        }

        protected virtual void Move()
        {
            if (MovementPressed())
            {
                acceleration = maxSpeed / timeTillMaxSpeed;
                runTime += Time.deltaTime;
                currentSpeed = horizontalInput * acceleration * runTime;
                CheckDirection();
            }
            else
            {
                acceleration = 0;
                currentSpeed = 0;
                runTime = 0;
            }

            rb2d.velocity = new Vector2(currentSpeed, rb2d.velocity.y);
        }
        
        protected virtual void CheckDirection()
        {
            if (currentSpeed > maxSpeed)
                currentSpeed = maxSpeed;
            if (currentSpeed < -maxSpeed)
                currentSpeed = -maxSpeed;
        }
        
    }
}