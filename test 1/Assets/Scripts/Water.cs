using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Water : MonoBehaviour
{
    public List<GameObject> collidingCubes = new List<GameObject>();
    public GameObject WaterBody;
    public GameObject WaterHeightPlane;
    public TMP_Text WaterHeightText;
    public TMP_InputField DensityInput;
    public Slider DensitySlider;
    private float density = 100;
    public float waterHeight = 8;
    public float waterArea = 150;
    public float waterYPosition = 4;

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Cube"){
            GameObject Cube = collider.gameObject;
            Cube.GetComponent<CubeScript>().underwater = true;
            collidingCubes.Add(Cube);
            Cube.GetComponent<Rigidbody>().drag += density/1000;  // drag due to viscosity of water
            if(!Cube.GetComponent<CubeScript>().held){
                Cube.GetComponent<Rigidbody>().velocity /= Mathf.Pow(density/100, 1/3f) + 0.2f;
            }
        }     
    }

    void OnTriggerExit(Collider collider){
        if(collider.gameObject.tag == "Cube"){
            GameObject Cube = collider.gameObject;
            Cube.GetComponent<CubeScript>().underwater = false;
            if(Cube.GetComponent<CubeScript>().held){
                Cube.GetComponent<Rigidbody>().useGravity = false;
            }    
            collidingCubes.Remove(Cube);
            Cube.GetComponent<Rigidbody>().drag = 0;
            if (!Cube.GetComponent<CubeScript>().held) {
                Cube.GetComponent<Rigidbody>().velocity /= Mathf.Pow(density/100, 1/3f) + 0.2f;
            }
        }
    } 

    public void OnDensitySliderChange(){
        density = DensitySlider.GetComponent<Slider>().value;
        DensityInput.text = density.ToString("0.00");
    }

    public void OnDensityChange(){
        density = float.Parse(DensityInput.text);
        DensitySlider.GetComponent<Slider>().value = density;
    }

    float GetSubmergedVolume(GameObject cube){
        float scale = cube.GetComponent<Transform>().localScale.y;
        float heightDifference = 
        (waterYPosition + waterHeight/2)-(cube.GetComponent<Transform>().position.y - scale/2);
        if(heightDifference > scale){heightDifference = scale;}
        float submergedVolume = scale*scale*heightDifference;
        if(submergedVolume < 0){submergedVolume = 0;}
        return submergedVolume;
    }

    void FixedUpdate(){
        float initialWaterHeight = 8;
        foreach(GameObject cube in collidingCubes){
            float submergedVolume = GetSubmergedVolume(cube);
            if(!cube.GetComponent<CubeScript>().held){
                cube.GetComponent<Rigidbody>()
                .AddForce(new Vector3(0, submergedVolume*density*50, 0));
            } else{
                float weight = cube.GetComponent<Rigidbody>().mass * 50;
                cube.GetComponent<Rigidbody>()
                .AddForce(new Vector3(0, weight, 0));
            }
            initialWaterHeight += submergedVolume/waterArea;   
        }
        waterHeight = initialWaterHeight;
        WaterHeightText.text = waterHeight.ToString("0.000") + " m";
        WaterBody.transform.localScale = new Vector3(1, waterHeight/8, 1);
        WaterHeightPlane.transform.position = new Vector3(-23, waterHeight, -10.01f);

    }
}
