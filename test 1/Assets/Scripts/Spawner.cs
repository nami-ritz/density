using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject Cube;
    public Slider VolumeSlider;
    private float volume = 0.5f;

    void Update()
    {
        
    }
    
    public void GenerateCube(){
        GameObject spawner = Instantiate(Cube, new Vector3(0, 8, 0), Quaternion.identity);
        spawner.transform.localScale = new Vector3(volume, volume, volume);    
    }

    public void OnVolumeChange(){
        volume = VolumeSlider.GetComponent<Slider>().value;
    }
}
