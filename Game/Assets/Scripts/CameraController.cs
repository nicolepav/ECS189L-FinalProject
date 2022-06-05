using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject target;

    private float totalRotationTime = 0.2f;
    private float degreesPerSecond;
    private int rotationDirection;
    private float degRotated = 0;

    private bool isRotating = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
        
        this.degreesPerSecond = 90 / this.totalRotationTime;
        // this.degreesPerSecond = Mathf.Lerp(0f, 90f, this.totalRotationTime);
        Debug.Log("degreesPerSecond: " + degreesPerSecond);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        GameObject target = GameObject.Find("MainPlayer");
        if (target)
        {
            var targetPosition = target.transform.position;
            var cameraPosition = transform.position;
            // set camera position to target's position
            cameraPosition = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);

            transform.position = cameraPosition;

            // TO DO: need to rotate exact 90
            if (this.isRotating)
            {
                if (this.degRotated < 90.0f)
                {   
                    float degs = this.degreesPerSecond * Time.deltaTime;
                    Vector3 rotVec = new Vector3(0, 0, this.rotationDirection * this.degreesPerSecond * Time.deltaTime);
                    if (90.0f - this.degRotated < this.degreesPerSecond * Time.deltaTime)
                    {
                        degs = (90.0f - this.degRotated);
                        rotVec = new Vector3(0, 0, this.rotationDirection * (90.0f - this.degRotated));
                    }
                    // rotate camera
                    transform.Rotate(rotVec);
                    // rotate player graphic to speed of camera
                    target.GetComponent<Player>().transform.GetChild(0).transform.Rotate(rotVec);
                    this.degRotated += degs;
                    Debug.Log("degRotated: " + degRotated);

                }
                else
                {
                    Debug.Log("Done rotating");
                    this.isRotating = false;

                    //can adjust
                    target.GetComponent<PlayerController>().IsAdjusting = false;
                }
            }
        }
    }

    public void rotateCameraRight()
    {
        // transform.Rotate(0,0,90);
        if (!this.isRotating)
        {
            Debug.Log("Can rotate");
            this.isRotating = true;
            this.rotationDirection = 1;
            this.degRotated = 0.0f;
        }
    }
    public void rotateCameraLeft()
    {
        // transform.Rotate(0,0,-90);
        if (!this.isRotating)
        {
            Debug.Log("Can rotate");
            this.isRotating = true;
            this.rotationDirection = -1;
            this.degRotated = 0.0f;
        }
    }

    public void ResetCamera()
    {
        
    }
}

 