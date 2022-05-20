using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerCommand;

namespace PlayerCommand
{
    public class PlayerMovement : MonoBehaviour, IPlayerCommand
    {
        private float modifiedSpeed;
        private Vector3 movementDirection; 

        private void Awake()
        {
            this.modifiedSpeed = 8.0f;
        }
        public void Execute(GameObject gameObject)
        {

        }
        public void MoveHorizontally(GameObject gameObject, int[] gravityDir)
        {
            this.movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            gameObject.transform.Translate(this.movementDirection * Time.deltaTime * this.modifiedSpeed);
        }
        public void Jump(GameObject gameObject, int[] gravityDir)
        {
            Debug.Log(gravityDir[0] + ", " + gravityDir[1]);
        }
        
    }
}
