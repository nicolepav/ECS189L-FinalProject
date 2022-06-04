using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


namespace PlayerCommand
{
    public class MoveLeft : ScriptableObject, IPlayerCommand
    {
        private float speed = 2.0f;
        private float yDir;
        private float xDir;  
        private Vector2 deltaVelocity; 
         

        public void Execute(GameObject gameObject) 
        {
            Debug.Log("Left command executed");
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            Vector2 rigidVel = rigidBody.velocity;
            this.yDir = Physics2D.gravity[1];
            this.xDir = Physics2D.gravity[0];
            this.deltaVelocity = gameObject.GetComponent<PlayerController>().DeltaVelocity;
            float dy = 0;
            float dx = 0;

            if (rigidBody != null)
            {

                Debug.Log("X " + this.xDir + " Y " + this.yDir);
                if (this.xDir != 0) // gravity going right/left
                {
                    dy = -this.xDir * speed * deltaVelocity.y; 
                } 
                else if (this.yDir != 0)// gravity going up/down
                {
                    dx = this.yDir * speed * deltaVelocity.x;
                }
                else 
                {
                    Debug.Log("Err: MoveLeft");
                }
                // adjust player graphic direction
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                // rigidBody.velocity = new Vector2(dx, dy);
                Debug.Log("rigidBody.velocity: " + rigidBody.velocity);
                

                // rigidBody.velocity = new Vector3(dx, dy, 0.0f);
                rigidBody.transform.Translate(dx, dy, 0.0f);
                // if (this.yDir < 0) 
                // {
                //     rigidBody.velocity = new Vector2(-this.speed, rigidBody.velocity.y);
                // }
                // else if (this.yDir > 0)
                // {
                //     rigidBody.velocity = new Vector2(this.speed, rigidBody.velocity.y);
                // }
                // else if (this.xDir < 0)
                // {
                //     rigidBody.velocity = new Vector2(rigidBody.velocity.x, this.speed);
                // }
                // else if (this.xDir > 0)
                // {
                //     rigidBody.velocity = new Vector2(rigidBody.velocity.x, -this.speed);
                // }
                // else 
                // {
                //     Debug.Log("Err: MoveLeft");
                // }

                

            }
        }

    }
}

// int transformX = -xDir * moveVertical * deltaVelocity.y;
// int transformY =  xDir * moveHorizontal * deltaVelocity.x;
// gameObject.transform.Translate(transformX, transformY, 0.0f);
// rigidBody.velocity = new Vector2D(-this.speed, rigidBody.velocity.y);
// gameObject.GetComponent<SpriteRenderer>().flipX = true;
