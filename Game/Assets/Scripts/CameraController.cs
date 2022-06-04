using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    [SerializeField] GameObject target;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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
    }
    public void rotateCameraRight()
    {
        transform.Rotate(0,0,90);
    }
    public void rotateCameraLeft()
    {
        transform.Rotate(0,0,-90);
    }
}
