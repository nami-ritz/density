using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public bool Zooming = true;
    public float zoomLowerLimit = 5;
    public float zoomUpperLimit = 10;
    public float zoomScale = 50.0f;
    

    void Update()
    {
    
        if (Zooming)
        {
            Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }

    }


    private void Zoom(float zoomDiff)
    {
        if (zoomDiff != 0)
        {
            
            var check = transform.position + transform.forward * (zoomDiff*zoomScale);
            Debug.Log(transform.forward*(zoomDiff*zoomScale));
            var mainCamY = Camera.main.transform.rotation.x;
            if ((check.z > zoomLowerLimit && check.z < zoomUpperLimit))
            {
                transform.position = transform.position + (transform.forward * zoomDiff* zoomScale);
            }
        }
    }
}
