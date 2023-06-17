using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    List<GameObject> collidingCubes = new List<GameObject>();

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Cube"){
            collidingCubes.Add(collider.gameObject);
        }     
    }

    void OnTriggerExit(Collider collider){
        collidingCubes.Remove(collider.gameObject);
    }

    void Update(){
        foreach(GameObject cube in collidingCubes){
            cube.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0));
        }      
    }
}
