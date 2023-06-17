using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject Cube;
    public Slider VolumeSlider;
    private float volume = 1;

    void Update()
    {
        
    }
    
    public void GenerateCube(){
        GameObject spawner = Instantiate(Cube, new Vector3(0, 15, -5), Quaternion.identity);
        spawner.transform.localScale = new Vector3(volume, volume, volume);    
    }

    public void OnVolumeChange(){
        volume = VolumeSlider.GetComponent<Slider>().value;
    }
}
