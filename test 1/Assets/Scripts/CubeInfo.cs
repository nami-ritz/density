using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeInfo : MonoBehaviour
{
    public Spawner SpawnerScript;
    public GameObject Cube;
    public Water WaterScript;
    public TMP_Text InfoText;
    public Image CubeImage;
    public int ID;
    public float mass;
    public float volume;
    public Color color;

    void Start(){
        SpawnerScript = GameObject.Find("Spawner").GetComponent<Spawner>();
        Cube = GameObject.Find("Cube " + ID.ToString());
        WaterScript = GameObject.Find("Water").GetComponent<Water>();
        TMP_Text text = Instantiate(InfoText, transform);
        text.text = $"Mass: {mass.ToString("0.00")}    Volume: {volume.ToString("0.00")}    Density: {(mass/volume).ToString("0.00")}";
        Image image = Instantiate(CubeImage, transform);
        image.color = color;          
    }

    public void OnClickRemove(){
        Destroy(gameObject);
        SpawnerScript.Colors.Add(Cube.GetComponent<Renderer>().material.color);   
        Destroy(Cube);
        SpawnerScript.CubeIDs.Add(ID);
        SpawnerScript.CubeIDs.Sort();
        SpawnerScript.cubeCount -= 1;
        SpawnerScript.EnableGenerateButton();
        SpawnerScript.CubeCountText.text = "Cubes: " + SpawnerScript.cubeCount.ToString() + "/5";
        WaterScript.collidingCubes.Remove(Cube);
    }
}
