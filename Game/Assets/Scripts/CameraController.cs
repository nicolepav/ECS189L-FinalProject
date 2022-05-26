using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0,0,speed * Time.deltaTime);
    }
    public void rotateCamera()
    {
        transform.Rotate(0,0,90);
    }
}
