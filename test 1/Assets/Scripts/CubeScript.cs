using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{   
    public GameObject FocalPoint;
    public bool held = false;
    public bool underwater = false;
    private Vector3 mousePosPrevious;
    private Vector3 mouseVelocity;
    private float areaScale = Mathf.Pow((Screen.width*Screen.height/471740f), 0.5f);
    private float dragSpeed = 3f;
    private float airResistance = 0.05f;
    public float zoomScale = 1f;
    public int ID;

    void Start(){
        gameObject.name = "Cube " + ID.ToString();
        FocalPoint = GameObject.Find("Focal Point");
    }

    void OnMouseDown(){
        held = true;
        if(!underwater){gameObject.GetComponent<Rigidbody>().useGravity = false;} 
        mousePosPrevious = Input.mousePosition;
        Debug.Log(FocalPoint.GetComponent<CameraControl>().zoomQuotient);
    }

    void OnMouseUp(){
        held = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    void FixedUpdate(){
        if(!underwater && !held){
            gameObject.GetComponent<Rigidbody>().drag = 
            gameObject.GetComponent<Rigidbody>().velocity.magnitude*airResistance; // more drag as speed increases
        }
        if(!held){
            return;
        } 
        Vector3 mousePositionCurrent = Input.mousePosition;
        mouseVelocity = mousePositionCurrent - mousePosPrevious;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(
            mouseVelocity.x/areaScale, 
            mouseVelocity.y/areaScale,
            0)*dragSpeed*FocalPoint.GetComponent<CameraControl>().zoomQuotient; // scaling the velocity of cube according to screen size
        mousePosPrevious = mousePositionCurrent;
    }
       
}
