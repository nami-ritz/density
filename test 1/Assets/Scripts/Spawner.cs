using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawner : MonoBehaviour
{
    public List <Color> Colors = new List<Color>() {
     Color.green,       
     Color.red,          
     Color.blue,         
     Color.yellow,        
     Color.white         
     };
    public List<int> CubeIDs = new List<int>(){1, 2, 3, 4, 5};
    public GameObject Cube;
    public GameObject CubeList;
    public GameObject CubeInfo;
    public GameObject CubeInfoParent;
    public Slider VolumeSlider;
    public Slider MassSlider;
    public Button GenerateButton;
    private Color GenerateButtonColor = new Color(0, 0.651f, 0.341f); //Forest Green
    public TMP_Text CubeCountText;
    public TMP_InputField MassInput;
    public TMP_InputField VolumeInput;
    public TMP_Text DensityText;
    private float volume = 1;
    private float mass = 500;
    public int cubeCount = 0;

    public void GenerateCube(){
        GameObject spawn = Instantiate(Cube, new Vector3(12.5f, 30, -5), Quaternion.identity);
        cubeCount += 1;
        CubeList.GetComponent<CubeList>().Cubes.Add(spawn);
        CubeCountText.text = "Cubes: " + cubeCount.ToString() + "/5"; 
        spawn.transform.localScale = 
        new Vector3(Mathf.Pow(volume, 1.0f/3), Mathf.Pow(volume, 1.0f/3), Mathf.Pow(volume, 1.0f/3));
        spawn.GetComponent<Rigidbody>().mass = mass;
        spawn.GetComponent<Renderer>().material.color = Colors[0];
        
        // Sends data to other scripts
        spawn.GetComponent<CubeScript>().ID = CubeIDs[0];
        CubeInfo.GetComponent<CubeInfo>().ID = CubeIDs[0];
        CubeInfo.GetComponent<CubeInfo>().mass = mass;
        CubeInfo.GetComponent<CubeInfo>().volume = volume;
        CubeInfo.GetComponent<CubeInfo>().color = Colors[0];

        CubeIDs.Remove(CubeIDs[0]); 
        Colors.Remove(Colors[0]);

        if(cubeCount >= 5){
            DisableGenerateButton();
        }

        //Creates info in Cube list
        GameObject info = Instantiate(CubeInfo, CubeInfoParent.transform);
        info.transform.SetParent(CubeInfoParent.GetComponent<RectTransform>(), false);
        info.GetComponent<RectTransform>().sizeDelta = new Vector2(800,80);
    }

    public void OnVolumeSliderChange(){
        volume = VolumeSlider.GetComponent<Slider>().value;
        VolumeInput.text = volume.ToString("0.00");
        DensityText.text = (mass/volume).ToString("0.00");
    }

    public void OnVolumeChange(){
        volume = float.Parse(VolumeInput.text);
        VolumeSlider.GetComponent<Slider>().value = volume;
    }

    public void OnMassSliderChange(){
        mass = MassSlider.GetComponent<Slider>().value;
        MassInput.text = mass.ToString("0.00");
        DensityText.text = (mass/volume).ToString("0.00");
    }

    public void OnMassChange(){
        mass = float.Parse(MassInput.text);
        MassSlider.GetComponent<Slider>().value = mass;
    }

    public void EnableGenerateButton(){
        GenerateButton.enabled = true;
        GenerateButton.image.color = GenerateButtonColor;
    }

    public void DisableGenerateButton(){
        GenerateButton.enabled = false;
        GenerateButton.image.color = Color.gray;
    }
    
}

