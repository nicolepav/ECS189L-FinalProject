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
        private Vector2 deltaVelocity = new Vector2(0.005f, 0.005f); 
         

        public void Execute(GameObject gameObject) 
        {
            Debug.Log("Left command executed");
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            this.yDir = Physics2D.gravity[1];
            this.xDir = Physics2D.gravity[0];
            float dy = 0;
            float dx = 0;

            if (rigidBody != null)
            {

                Debug.Log("X " + this.xDir + " Y " + this.yDir);
                if (this.xDir != 0) // gravity going right/left
                {
                    // dx = -this.xDir * speed * deltaVelocity.x;
                    dy = -this.xDir * speed * deltaVelocity.y;
                    // this.player.transform.Translate(-xDir * moveVertical * deltaVelocity.y, xDir * moveHorizontal * deltaVelocity.x, 0.0f);

                } 
                else if (this.yDir != 0)// gravity going up/down
                {
                    dx = this.yDir * speed * deltaVelocity.x;
                    // Debug.Log("dx: "+ dx);
                    // dy = -this.yDir * speed * deltaVelocity.y;
                    // this.player.transform.Translate(-yDir * moveHorizontal * deltaVelocity.x, -yDir * moveVertical * deltaVelocity.y, 0.0f);
                }else 
                {
                    Debug.Log("Err: MoveLeft");
                }
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

                // gameObject.GetComponent<SpriteRenderer>().flipX = true;

            }
        }

    }
}

// int transformX = -xDir * moveVertical * deltaVelocity.y;
// int transformY =  xDir * moveHorizontal * deltaVelocity.x;
// gameObject.transform.Translate(transformX, transformY, 0.0f);
// rigidBody.velocity = new Vector2D(-this.speed, rigidBody.velocity.y);
// gameObject.GetComponent<SpriteRenderer>().flipX = true;
