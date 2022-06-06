using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


namespace PlayerCommand
{
    public class MoveUp : ScriptableObject, IPlayerCommand
    {
        private float speed = 4.0f;
        private float yDir;
        private float xDir; 
        private int limitJumps = 2; 
        private int curNumJumps = 0; 

        public void SetCurNumJumps(int value)
        {
            this.curNumJumps = value;
        }      

        public void Execute(GameObject gameObject) 
        {
            // Debug.Log("Up command executed");
            // Debug.Log("curNumJumps: " + this.curNumJumps);

            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            this.yDir = Physics2D.gravity[1];
            this.xDir = Physics2D.gravity[0];
            float dy = rigidBody.velocity[1];
            float dx = rigidBody.velocity[0];

            if (rigidBody != null && this.curNumJumps < this.limitJumps)
            {
                if (this.xDir > 0) // gravity going right
                {
                    dx =  -speed;
                } 
                else if (this.xDir < 0) // gravity going left
                {
                    dx =  speed;
                } 
                else if (this.yDir > 0) // gravity going up
                {
                    dy =  -speed;
                }
                else if (this.yDir < 0) // gravity going down
                {
                    dy =  speed;
                }
                else 
                {
                    Debug.Log("Err: MoveUp");
                }

                // Debug.Log("dx: " + dx + ", dy: " + dy);
                // increment jump counter
                this.curNumJumps++;
                rigidBody.velocity = new Vector2(dx, dy);

                // Jump sound effect.
                FindObjectOfType<SoundManager>().PlaySoundEffect("Jump");
            }
        }
    }
}

// int transformX = -xDir * moveVertical * deltaVelocity.y;
// int transformY =  xDir * moveHorizontal * deltaVelocity.x;
// gameObject.transform.Translate(transformX, transformY, 0.0f);
// rigidBody.velocity = new Vector2D(-this.speed, rigidBody.velocity.y);
// gameObject.GetComponent<SpriteRenderer>().flipX = false;

