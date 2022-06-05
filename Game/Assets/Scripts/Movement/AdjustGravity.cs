using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

namespace PlayerCommand 
{
    // [RequireComponent(typeof(PlayerController))]

    public class AdjustGravity : ScriptableObject, IPlayerCommand
    {
       
        public void Execute(GameObject gameObject) {

            int localGravityIndex = (gameObject.GetComponent<PlayerController>().GravityIndex + 1) % 4;
            
            // increment gravity index (which direction are we facing essentially)
            gameObject.GetComponent<PlayerController>().GravityIndex = (localGravityIndex);

            // set gravity
            Physics2D.gravity = gameObject.GetComponent<PlayerController>().GravityDirs[localGravityIndex];
            Debug.Log("new gravity: " + Physics2D.gravity + " with index " + localGravityIndex);

            // rotate camera
            gameObject.GetComponent<Player>().GetCamController().GetComponent<CameraController>().rotateCamera(1);

        }
    }
}


