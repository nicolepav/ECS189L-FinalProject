using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject target;

    private float totalRotationTime = 1.0f;
    private float degreesPerSecond;
    private int rotationDirection;
    private float timeElapsed = 0;
    private bool isRotating = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        this.degreesPerSecond = 90 / this.totalRotationTime;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        GameObject target = GameObject.Find("MainPlayer");
        var targetPosition = target.transform.position;
        var cameraPosition = transform.position;
        // set camera position to target's position
        cameraPosition = new Vector3(targetPosition.x, targetPosition.y, cameraPosition.z);

        transform.position = cameraPosition;

        if (this.isRotating)
        {
            if (this.timeElapsed <= this.totalRotationTime)
            {
                transform.Rotate(new Vector3(0, 0, this.rotationDirection * this.degreesPerSecond * Time.deltaTime));
                this.timeElapsed += Time.deltaTime;
            }
            else
            {
                this.isRotating = false;
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
            this.timeElapsed = 0.0f;
        }
        // transform.Rotate(new Vector3(0, 0, degreesPerSecond * Time.deltaTime));
    }
    public void rotateCameraLeft()
    {
        // transform.Rotate(0,0,-90);
        if (!this.isRotating)
        {
            Debug.Log("Can rotate");
            this.isRotating = true;
            this.rotationDirection = -1;
            this.timeElapsed = 0.0f;
        }
        // transform.Rotate(new Vector3(0, 0, -degreesPerSecond * Time.deltaTime));
    }
}

 