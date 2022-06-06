using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

namespace PlayerCommand 
{

    public class AdjustGravityLeft : ScriptableObject, IPlayerCommand
    {
        public void Execute(GameObject gameObject) {
            if (!gameObject.GetComponent<PlayerController>().IsAdjusting)
            {
                // Debug.Log("Updating Left");
                // update is adjusting
                gameObject.GetComponent<PlayerController>().IsAdjusting = true;

                int localGravityIndex = gameObject.GetComponent<PlayerController>().nfmod(gameObject.GetComponent<PlayerController>().GravityIndex - 1,4);
                // Debug.Log("localGravityIndex " + localGravityIndex);

                // increment gravity index (which direction are we facing essentially)
                gameObject.GetComponent<PlayerController>().GravityIndex = (localGravityIndex);

                // set gravity
                Physics2D.gravity = gameObject.GetComponent<PlayerController>().GravityDirs[localGravityIndex];
                // Debug.Log("new gravity: " + Physics2D.gravity + " with index " + localGravityIndex);

                // rotate camera
                gameObject.GetComponent<Player>().GetCamController().rotateCamera(-1);

                // Play sound effect.
                SoundManager.Instance.PlaySoundEffect("Rotation");
            }
        }
    }
}


