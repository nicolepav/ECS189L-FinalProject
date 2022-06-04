using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

namespace PlayerCommand 
{

    public class AdjustGravityRight : ScriptableObject, IPlayerCommand
    {
        private bool isAdjusting = false;
       
        public void Execute(GameObject gameObject) {
            if (!isAdjusting)
            {

                int localGravityIndex = (gameObject.GetComponent<PlayerController>().GravityIndex + 1) % 4;
                
                // increment gravity index (which direction are we facing essentially)
                gameObject.GetComponent<PlayerController>().GravityIndex = (localGravityIndex);

                // set gravity
                Physics2D.gravity = gameObject.GetComponent<PlayerController>().GravityDirs[localGravityIndex];
                Debug.Log("new gravity: " + Physics2D.gravity + " with index " + localGravityIndex);

                // rotate camera
                gameObject.GetComponent<Player>().getCamController().rotateCameraRight();

                // rotate player graphic
                gameObject.GetComponent<Player>().RotatePlayerRight();
            }
        }

        public void IsAdjusting(bool val)
        {
            this.isAdjusting = val;
            Debug.Log("reached gravityright");

        }
    }
}


